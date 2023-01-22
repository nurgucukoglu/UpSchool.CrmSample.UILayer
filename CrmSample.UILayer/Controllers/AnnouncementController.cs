using CrmSample.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmSample.UILayer.Controllers
{
    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            ViewBag.isUserAdmin = User.Claims.Any(x => x.Value == "admin");

            var values = _announcementService.TGetList();
            return View(values);
           
        }
    }
}
