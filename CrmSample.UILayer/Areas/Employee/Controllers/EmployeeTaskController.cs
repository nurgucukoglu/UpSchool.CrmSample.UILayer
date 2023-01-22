using CrmSample.BusinessLayer.Abstract;
using CrmSample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//SİSTEME GİRİŞ YAPAN KULLANICININ GÖREVLERİNİ GETİRECEK.

namespace CrmSample.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTaskController : Controller
    {
        private readonly UserManager<AppUser> _userManager;//Sisteme authentike olan kullanıcıyı bulucaz.
        private readonly IEmployeeTaskService _employeeTaskService;

        public EmployeeTaskController(UserManager<AppUser> userManager, IEmployeeTaskService employeeTaskService)
        {
            _userManager = userManager;
            _employeeTaskService = employeeTaskService;
        }

        public async Task<IActionResult> EmployeeTaskListByProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //entitye özgü metot yazıcaz sonra
            var taskList = _employeeTaskService.TGetEmployeeTaskById(values.Id); //taskList değişkenine atadım metottan gelen değeri

            return View(taskList);
        }


    }
}
