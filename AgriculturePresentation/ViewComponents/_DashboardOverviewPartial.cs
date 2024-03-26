using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = 3;

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.madenBakicisi = c.Teams.Where(x => x.Title == "Doğal Madenler Bakıcısı").Select(x => x.Name).FirstOrDefault();
            ViewBag.tarimBaakani = c.Teams.Where(x => x.Title == "Tarım Bakanı").Select(x => x.Name).FirstOrDefault();
            ViewBag.sutUrunleriUreticisi = c.Teams.Where(x => x.Title == "Süt Ürünleri Üreticisi").Select(x => x.Name).FirstOrDefault();
            ViewBag.otBakani = c.Teams.Where(x => x.Title == "Ot Bakanı").Select(x => x.Name).FirstOrDefault();
            return View();
        }
    }
}
