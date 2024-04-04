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
                // İletişim bilgileri veritabanından alınır ve ContactModel nesnelerine dönüştürülür.
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
                    // Her bir iletişim bilgisi, Excel tablosuna eklenir.
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMassage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    // Excel dosyası bir akışa kaydedilir ve akış içeriği byte dizisine dönüştürülür.
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    // Excel dosyası indirme için File metodunu kullanarak döndürülür.
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Mesaj_Rapor.xlsx");
                }
            }
        }

        // AnnouncementList metodu, veritabanından duyuru bilgilerini almak için kullanılır.
        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                // Duyuru bilgileri veritabanından alınır ve AnnouncementModel nesnelerine dönüştürülür.
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    ID = x.AnnouncementID,
                    Title = x.Title,
                    Description = x.Description,
                    Date = x.Date,
                    Status = x.Status
                }).ToList();
            }
            return announcementModels;
        }

        // AnnouncementReport eylemi, duyuru bilgilerini içeren bir Excel raporu oluşturur ve indirme işlemi gerçekleştirir.
        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 3).Value = "Duyuru Açıklaması";
                workSheet.Cell(1, 4).Value = "Duyuru Tarihi";
                workSheet.Cell(1, 5).Value = "Durum";

                int announcementRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    // Her bir duyuru bilgisi, Excel tablosuna eklenir.
                    workSheet.Cell(announcementRowCount, 1).Value = item.ID;
                    workSheet.Cell(announcementRowCount, 2).Value = item.Title;
                    workSheet.Cell(announcementRowCount, 3).Value = item.Description;
                    workSheet.Cell(announcementRowCount, 4).Value = item.Date;
                    workSheet.Cell(announcementRowCount, 5).Value = item.Status;
                    announcementRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    // Excel dosyası bir akışa kaydedilir ve akış içeriği byte dizisine dönüştürülür.
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    // Excel dosyası indirme için File metodunu kullanarak döndürülür.
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Duyuru_Rapor.xlsx");
                }
            }
        }
    }
}
