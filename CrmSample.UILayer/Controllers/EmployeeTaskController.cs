using CrmSample.BusinessLayer.Abstract;
using CrmSample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrmSample.UILayer.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private readonly IEmployeeTaskService _employeeTaskService;
        private readonly UserManager<AppUser> _userManager; //user tablosuyla çalışıcağımız içiçn ekledik. personel seçerken(olan const.içine bunu eklemek için _userManager ctrl. add parameter to..)
        private readonly IEmployeeService _employeeService;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, UserManager<AppUser> userManager, IEmployeeService employeeService)
        {
            _employeeTaskService = employeeTaskService;
            _userManager = userManager;
            _employeeService = employeeService;
        }

        public IActionResult Index(int id) //önce kendi metodumuzla verileri görüntülücez.
        {
            ViewBag.isUserAdmin = User.Claims.Any(x => x.Value == "admin");


            var values = _employeeTaskService.TGetEmployeeTaskByEmployee();
            ViewBag.Id = id;
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            //DROPDOWN İÇİNDE PERSONEL SEÇİCEZ:
            List<SelectListItem> userValues = (from x in _employeeService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.EmployeeName + " " + x.EmployeeSurName,
                                                   Value = x.EmployeeID.ToString()
                                               }).ToList();
            ViewBag.v = userValues;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddTaskAsync(EmployeeTask employeeTask)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            employeeTask.Status = "Görev atandı"; //görevin başlangıçtaki statüsü
            employeeTask.AppUserID = values.Id;
            employeeTask.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //görev atandığı zaman default olarak tarih gelicek o anın 
            //statusu ve dadtei gönderddik.diğerleri inputlar içinde geliyor olacak.
            _employeeTaskService.TInsert(employeeTask);
            return RedirectToAction("Index");
        }
    }
}
