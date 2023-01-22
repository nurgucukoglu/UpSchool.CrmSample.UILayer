using CrmSample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//AMAÇ SİSTEME AUTHENTİKE OLAN KULLANICI KİMSE BU KULLANICIYA AİT GÖREEVLERİ LİSTELEMEK
namespace CrmSample.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //kullanıcının giriş yaptığı isim.username aslında
            ViewBag.v1 = values.Name; //sisteme kimle giriş yaptıysam adını ve soyadını getir.
            ViewBag.v2 = values.SurName;
            return View();
        }
    }
}
