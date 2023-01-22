using CrmSample.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSample.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class DashBoardController : Controller
    {
       

        private readonly IEmployeeTaskService _employeeTaskService;

        public DashBoardController(IEmployeeTaskService employeeTaskService)
        {
            _employeeTaskService = employeeTaskService;
        }

    
        public IActionResult Index() //önce kendi metodumuzla verileri görüntülücez.
        {
            var values = _employeeTaskService.TGetEmployeeTaskByEmployee();
            return View(values);
        }



    }
}
