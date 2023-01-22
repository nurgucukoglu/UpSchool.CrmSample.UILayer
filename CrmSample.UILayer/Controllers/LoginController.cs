using CrmSample.EntityLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrmSample.UILayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager; //login işlemi için signInManager kullandık. //gen const yaptık.
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.PasswordHash, false, true);
                //PasswordSignInAsync parametreleri: username, password, kişi cookilere kaydolsun mu, kilitleme...bunlar metotdan sonra çıkıyor zaten istediği parametreler diye)
                if(result.Succeeded)
            {
                return RedirectToAction("Index", "Announcement");
                //var user = await _userManager.FindByNameAsync(User.Identity.Name);
                //var userRoles = await _userManager.GetRolesAsync(user);//gönderilen kullanıcının rolünü getirsin metotu
                //var isUserAdmin = userRoles.Contains("admin");
                      //if(userRoles==Contains."admin")
                      //   {

                      //   }

            }
            return View();
        }
    }
}
