using CrmSample.EntityLayer.Concrete;
using CrmSample.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmSample.UILayer.Controllers
{
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        //DEP INJ UYGULADIK YUKARDA

        public IActionResult Index() //ROLLERİ LİSTELEME
        {
            ViewBag.isUserAdmin = User.Claims.Any(x => x.Value == "admin");


            var values = _roleManager.Roles.ToList(); //role manager.da direkt tolist gelmedi. roles.tolist yaptık.
            return View(values);
        }


        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model) //rol tablosuna eklemek istediğimiz propertyleri tutacak metodun içi(RoleViewModel) model yerine p de yazılabilirdi.
        {
            if (ModelState.IsValid) //eğer model geçerliyse
            {
                AppRole appRole = new AppRole() //rol sınıfı içindeki propertylere erişip atama yapıcaz:
                {
                    Name = model.RoleName //roleviewe.deki role namei approle.e atadık
                };
                var result = await _roleManager.CreateAsync(appRole);

                if (result.Succeeded) 
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id) //identity.de silme işlemi
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result=await _roleManager.DeleteAsync(role);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppRole appRole)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == appRole.Id);
            values.Name = appRole.Name;

            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            //rol atadan kullanıcılar listesinden seçilen kişi id
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["UserId"] = user.Id; //. başka actionlarda da kullanılabilir. Ama ViewBag de sadece assignrole gönderilebilir.
            var userRoles = await _userManager.GetRolesAsync(user);//gönderilen kullanıcının rolünü getirsin metotu


            List<RoleAssignModel> models = new List<RoleAssignModel>();

            foreach (var item in roles)  //rol atama yapar. Roles listesinden gelen rolü
            {
                RoleAssignModel roleAssignModel = new RoleAssignModel();
                roleAssignModel.Name = item.Name;
                roleAssignModel.RoleID = item.Id;
                roleAssignModel.Exists = userRoles.Contains(item.Name); //kullanıcının bulunduğu roller=userroles 
                models.Add(roleAssignModel);
            }
            return View(models);


        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignModel> model) //list çünkü birden fazla rolde gelebilir.
        {

            var userid = (int)TempData["UserId"];//Controller'dan UI'a TempData ile gönderdiğimiz veriyi burada controller'da çağırıp kullanıyoruz.

            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);

            foreach (var item in model) //bu kısımda ilgili rol seçilmişse db de full satır eklenir(2sütun vardı birbiriyle ilişkili aspneyuserroles), seçilmemişse full satır silinir.
            {
                if (item.Exists)//rol varsa checkbox da bunları yap:
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                    //checkboxda seçili ise rolü ekle
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                    //checkboxda seçili değilse o rolü sil 
                }
            }
            return RedirectToAction("UserList");
        }

    }
}
