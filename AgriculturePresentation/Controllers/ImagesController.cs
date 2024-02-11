using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            ImageValidator validator = new ImageValidator();
            ValidationResult result = validator.Validate(image);

            if (result.IsValid)
            {
                _ımageService.Insert(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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
            ImageValidator validator = new ImageValidator();
            ValidationResult result = validator.Validate(image);

            if (result.IsValid)
            {
                _ımageService.Insert(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
