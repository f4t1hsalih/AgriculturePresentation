using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _MapPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            AgricultureContext context = new AgricultureContext();
            var value = context.Addresses.Select(x => x.MapInfo).FirstOrDefault();
            ViewBag.v = value;
            return View();
        }
    }
}
