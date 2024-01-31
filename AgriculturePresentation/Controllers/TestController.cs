using AgriculturePresentation.Models;
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
            return View(new ServiceAddViewModel());
        }

        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            //Model çalışıyor ise modelin şartları sağlanıyor ise
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
