using CrmSample.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmSample.UILayer.ViewComponents.Dashboard
{
    public class _OverviewDashboardPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                
                ViewBag.EmployeeCount = context.Employees.Count(); //eklnen son kullanıcı bilgisi aldık
                ViewBag.EmployeeWomanGenderCount = context.Users.Where(x => x.Gender == "Kadın").Count(); //gender bilgisi aldık

                ViewBag.EmployeeTaskCount= context.EmployeeTasks.Count(); 
                
                int id = context.Users.Max(x => x.Id); //max id.yi bulup bi değişkene atadık int id
                ViewBag.LastUser = context.Users.Where(x => x.Id == id).Select(x => x.Name + " " + x.SurName).FirstOrDefault();
            }
            return View();
        }
    }
}
