using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _ContactPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _ContactPartial(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _contactService.GetListAll();
            return View(values);
        }
    }
}
