using CrmSample.EntityLayer.Concrete;
using CrmSample.UILayer.Areas.Employee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;

//SADECE İHTİYACIM OLAN PROP.LARI GETİRMEK İÇİN

namespace CrmSample.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //kullanıcı adını name.i
            UserEditProfileViewModel userEditProfileViewModel = new UserEditProfileViewModel();

            //atama işlemleri
            userEditProfileViewModel.Name = values.Name;
            userEditProfileViewModel.Surname = values.SurName;
            userEditProfileViewModel.PhoneNumber = values.PhoneNumber;
            userEditProfileViewModel.Email = values.Email;

            return View(userEditProfileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditProfileViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory(); //bulunduğumuz konumu alıcak: Directory.GetCurrentDirectory()
                var extension = Path.GetExtension(p.Image.FileName); //gönderilen resmi uzantısını aldık
                var imageName = Guid.NewGuid() + extension; //guid.newguid ile resme bir isim verdik ve extension ile uazntı eklettirdik.
                var SaveLocation = resource + "/wwwroot/UserImages/" + imageName; //resmin kaydedileceği konum
                //kaydetme akışı
                var stream = new FileStream(SaveLocation, FileMode.Create); //(resmin kaydedileceği yer,ve oluşturma metodu  
                await p.Image.CopyToAsync(stream); //akıştaki değeri kopyalıcaz
                values.ImageURL = imageName; //güncellemek istenilen veriye ımgurl değeri atıcaz.
            }

            //atamalar
            values.Name = p.Name;
            values.SurName = p.Surname;
            values.Email = p.Email;
            values.PhoneNumber = p.PhoneNumber;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password); //şifreyi aldık.
            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded) //başarılı bir şekilde gğncellenmişe:
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
