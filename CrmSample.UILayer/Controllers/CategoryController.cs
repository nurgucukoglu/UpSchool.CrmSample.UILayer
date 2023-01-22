using CrmSample.BusinessLayer.Abstract;
using CrmSample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmSample.UILayer.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService; //IPrService den Igenserv deki metotlaar var ınsert...

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.isUserAdmin = User.Claims.Any(x => x.Value == "admin");

            var values = _categoryService.TGetList();
            return View(values);
        }

        //Ekleme İşlemi Yapıcaz
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction ("Index");
          
        }

        public IActionResult DeleteCategory(int id)
        {
            var values=_categoryService.TGetById(id); //önce id.yi buldurduk.

            _categoryService.TDelete(values);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id) //güncellenecek kayda ulaşmak için id alır
        {
            var values = _categoryService.TGetById(id);
            _categoryService.TUpdate(values);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
