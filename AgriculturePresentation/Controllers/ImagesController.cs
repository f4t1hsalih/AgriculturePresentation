using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IImageService _ımageService;

        public ImagesController(IImageService ımageService)
        {
            _ımageService = ımageService;
        }

        public IActionResult Index()
        {
            var values = _ımageService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            _ımageService.Insert(image);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteImage(int id)
        {
            var value = _ımageService.GetById(id);
            _ımageService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var value = _ımageService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditImage(Image image)
        {
            _ımageService.Update(image);
            return RedirectToAction("Index");
        }
    }
}
