using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TestController : Controller
    {
        private readonly IServiceService _serviceService;

        public TestController(IServiceService serviceService)
        {
            this._serviceService = serviceService;
        }

        //Listeleme İşlemi
        public IActionResult Index()
        {
            var values = _serviceService.GetListAll();
            return View(values);
        }

        //Ekleme İşlemi
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceService.Insert(service);
            return RedirectToAction("Index");
        }
    }
}
