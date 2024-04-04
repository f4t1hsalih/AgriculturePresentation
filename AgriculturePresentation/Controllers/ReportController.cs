using AgriculturePresentation.Models;
using ClosedXML.Excel; // ClosedXML kütüphanesi eklendi.
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml; // OfficeOpenXml kütüphanesi eklendi.

namespace AgriculturePresentation.Controllers
{
    // ReportController sınıfı, raporlama işlemlerini yöneten bir MVC denetleyicisidir.
    public class ReportController : Controller
    {
        // Index eylemi, varsayılan olarak bir görünüm döndürür.
        public IActionResult Index()
        {
            return View();
        }

        // StaticReport eylemi, statik bir rapor oluşturur ve Excel dosyası olarak indirme işlemi gerçekleştirir.
        public IActionResult StaticReport()
        {
            // ExcelPackage, OfficeOpenXml kütüphanesinden bir nesnedir ve Excel işlemleri için kullanılır.
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Yeni bir Excel çalışma sayfası oluşturulur ve adı "Dosya1" olarak belirlenir.
                var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

                // Başlık satırı için hücrelere değerler atanır.
                workBook.Cells[1, 1].Value = "Ürün Adı";
                workBook.Cells[1, 2].Value = "Ürün Kategorisi";
                workBook.Cells[1, 3].Value = "Ürün Stok";

                // Veri satırları için hücrelere değerler atanır.
                workBook.Cells[2, 1].Value = "Mercimek";
                workBook.Cells[2, 2].Value = "Bakliyat";
                workBook.Cells[2, 3].Value = "785 KG";

                workBook.Cells[3, 1].Value = "Buğday";
                workBook.Cells[3, 2].Value = "Bakliyat";
                workBook.Cells[3, 3].Value = "1.986 KG";

                workBook.Cells[4, 1].Value = "Havuç";
                workBook.Cells[4, 2].Value = "Sebze";
                workBook.Cells[4, 3].Value = "167 KG";

                // Excel dosyasını bir byte dizisine dönüştürür.
                var bytes = excelPackage.GetAsByteArray();

                // Excel dosyasını indirme için File metodunu kullanarak döndürür.
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bakliyat_Raporu.xlsx");
            }
        }

        // ContactList metodu, veritabanından iletişim bilgilerini almak için kullanılır.
        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactID = x.ContactID,
                    ContactName = x.Name,
                    ContactMail = x.Mail,
                    ContactMassage = x.Message,
                    ContactDate = x.Date
                }).ToList();
            }
            return contactModels;
        }

        // ContactReport eylemi, iletişim bilgilerini içeren bir Excel raporu oluşturur ve indirme işlemi gerçekleştirir.
        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMassage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Mesaj_Rapor.xlsx");
                }
            }
        }

        // AnnouncementReport eylemi, duyuru raporu için bir görünüm döndürür.
        public IActionResult AnnouncementReport()
        {
            return View();
        }
    }
}
