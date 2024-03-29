﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = _contactService.GetById(id);
            return View(value);
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _contactService.GetById(id);
            _contactService.Delete(value);
            return View();
        }
    }
}
