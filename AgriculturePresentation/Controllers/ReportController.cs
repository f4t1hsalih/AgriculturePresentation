using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;

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

        // MessageReport eylemi, mesaj raporu için bir görünüm döndürür.
        public IActionResult MessageReport()
        {
            return View();
        }

        // AnnouncementReport eylemi, duyuru raporu için bir görünüm döndürür.
        public IActionResult AnnouncementReport()
        {
            return View();
        }
    }
}
