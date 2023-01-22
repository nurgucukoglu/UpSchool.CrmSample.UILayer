using CrmSample.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSample.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTaskDetailController : Controller
    {
        private readonly IEmployeeTaskDetailService _employeeTaskDetailService; //IEmployeeTaskDetailService.den data çekicez.

        public EmployeeTaskDetailController(IEmployeeTaskDetailService employeeTaskDetailService)
        {
            _employeeTaskDetailService = employeeTaskDetailService;
        }

        public IActionResult Index(int id)
        {
            var values = _employeeTaskDetailService.TGetEmployeeTaskDetailById(id);
            return View(values);
        }
    }
}
