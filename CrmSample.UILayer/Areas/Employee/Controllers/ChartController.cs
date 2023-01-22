using CrmSample.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmSample.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmentSalary> departmentSalaries = new List<DepartmentSalary>();

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult DepartmentChart()
        {
            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Muhasebe",
                salaryavg = 10000

            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "IT",
                salaryavg = 20000

            });
            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Satıs",
                salaryavg = 12000

            });


            return Json(new { jsonList = departmentSalaries }); //retun view yerine json döncek, google chartta bizi json karşılıcak. JsonList biz verdik.
        }
    }
}
