using CrmSample.BusinessLayer.Abstract;
using CrmSample.DTOLayer.ContactDTOs;
using CrmSample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrmSample.UILayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult AddContact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddContact(ContactAddDTO contactAddDTO)
		{
			//artık dto kullandığımız için contactadddto'yu parametre olarak alır
			if (ModelState.IsValid)
			{
				_contactService.TInsert(new Contact()
				{
					Name = contactAddDTO.Name,
					Mail = contactAddDTO.Mail,
					Content = contactAddDTO.Content,
					Subject = contactAddDTO.Subject,
					Date = DateTime.Parse(DateTime.Now.ToShortDateString())

				});
				return RedirectToAction("Employee", "Dashboard", "Index");

			}
			return View();
		}
	}
}
