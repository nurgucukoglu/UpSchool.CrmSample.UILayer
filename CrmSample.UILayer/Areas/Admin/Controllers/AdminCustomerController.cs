using CrmSample.BusinessLayer.Abstract;
using CrmSample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;


//AMACIM: MÜŞTERİYLE İLGİLİ İŞLEMLERİ BURADA GERÇEKLEŞTİREBİLMEK.
namespace CrmSample.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList() //json dosya formatındaa alıyoruz.
        {
            var jsonCustomers = JsonConvert.SerializeObject(_customerService.TGetList()); //customer classın içindeki verileri json formatına dönüştürücez.
            return Json(jsonCustomers);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer) 
        {
            _customerService.TInsert(customer); //customer tablosunda olanlar eklenicek. //BU İŞLEM DB.YE YANSITACAK.

            //ajax kullanmak için birleştirioruz(serialize)
            var values = JsonConvert.SerializeObject(customer);  //NU 2 SATIR DA DB.YE AJAX ÜZERİNDE GÖRDERMEMİ SAĞLAYACAK.
            return Json(values);
        }

        public IActionResult GetById(int CustomerID) //Idye göre getirme metodu
        {
            var values = _customerService.TGetById(CustomerID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = _customerService.TGetById(id);
            _customerService.TDelete(values);          
            return Json(values);
        }
        public IActionResult UpdateCustomer(Customer customer) //id alıcak modelden, model yok direkt entityden alıcak. bütün verilerde işlem yapmak istemiyorsak model açıp onu kullanırız. Direkt entityi çağırmak hatalı bir kullanım değil aslında. CQRS de entitiy içindeki propertyler parçalanarak kullanılır bunun için. 
        {
            _customerService.TUpdate(customer);
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);
        }
    }
}
