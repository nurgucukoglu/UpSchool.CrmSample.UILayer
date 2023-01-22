using CrmSample.BusinessLayer.Abstract;
using CrmSample.BusinessLayer.ValidationRules;
using CrmSample.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmSample.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager; //alta cons oluşturduk bunu yazdıktan sonra
        private readonly RoleManager<AppRole> _roleManager;


        public EmployeeController(IEmployeeService employeeService, ICategoryService categoryService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)//categorileri listelemk istediğim için önce yukarda bu listeye ait metotları dahil ettim (priv readon), sonra bu satıra dep inj aldım.
        {
            _employeeService = employeeService;
            _categoryService = categoryService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.isUserAdmin = User.Claims.Any(x => x.Value == "admin");

            var values = _employeeService.TGetEmployeeByCategory();
            return View(values);
        }

        //public IActionResult Index() //ROLLERİ LİSTELEME
        //{
        //    var values = _roleManager.Roles.ToList(); //role manager.da direkt tolist gelmedi. roles.tolist yaptık.
        //    return View(values);
        //}


        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName, // drowdownlist.de 2 parametre kullanılır,1.si metnin kendisi
                                                       Value = x.CategoryID.ToString() //2.si id.si
                                                   }).ToList(); //bunu bi liste olarak istediğin için sonuna tolist
            
            ViewBag.v = categoryValues; //Yukarıdakileri DropDown.a taşıdık.

            //TÜM BUNLAR BİR MODELİN İÇİNE ATILIP DA ÇAĞIRILABİLİR VEYA BUNLAR İÇİM BİR METOT AÇILIP DA İSTENİLEN YERLERDE ÇAĞIRILABİLİR.

            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee) 
        {
           EmployeeValidator validationRules= new EmployeeValidator();
            ValidationResult result = validationRules.Validate(employee); //valirules tan gelen değerleri kontrol et. parametreden gelen
            if(result.IsValid) // result geçerse bu işlemleri yap
            {
                _employeeService.TInsert(employee);
                return RedirectToAction("Index");
            }
            else//geçmezse benim yazdığım hata mesajları döner:
            {
                foreach (var item in result.Errors)
                {
                    //ModelState: modelden gelen hata mesajlarını göstermek için kullandık.
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteEmployee(int id)
        {
            var values= _employeeService.TGetById(id);//id.ye göre bul
            _employeeService.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToFalse(int id)
        {
            _employeeService.TChangeEmployeeStatusToFalse(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            _employeeService.TChangeEmployeeStatusToTrue(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var values = _employeeService.TGetById(id);//güncellenecek veriyi buldur.
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var values= _employeeService.TGetById(employee.EmployeeID); //parametreden gelen id.yi güncelleyeceği ekrana gönderecek:
            employee.EmployeeStatus = values.EmployeeStatus; //status default olarak false geliyordu. bunu yazarak employee.da nasılsa öyle gelmesini sağladık.
            _employeeService.TUpdate(employee);
            return RedirectToAction("Index");
        }
    }
}
