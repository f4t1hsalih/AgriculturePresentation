using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
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

        //Silme İşlemi
        public IActionResult DeleteService(int id)
        {
            var value = _serviceService.GetById(id);
            _serviceService.Delete(value);
            return RedirectToAction("Index");
        }

        //Güncelleme İşlemi
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _serviceService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }
    }
}
