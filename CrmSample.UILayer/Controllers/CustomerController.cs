using CrmSample.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmSample.UILayer.Controllers
{
    public class CustomerController : Controller
    {
        Context C = new Context();
        public IActionResult Index()
        {
            ViewBag.isUserAdmin = User.Claims.Any(x => x.Value == "admin");


            var values = C.Customers.ToList();
            return View(values);
        }
    }
}
