using BusinessLayer.Abstract;
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

        public IActionResult Index()
        {
            var values = _serviceService.GetListAll();
            return View(values);
        }
    }
}
