using CrmSample.BusinessLayer.Abstract;
using CrmSample.DataAccessLayer.Abstract;
using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        //Dependency Injection
        //amaç bağımlılıkları min indirmek
        //new ne kadar az olursa o kadar min olur
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetById(int id)// metot void türünde değil başına return ekle
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetList()
        {
           return _categoryDal.GetList();
        }

        public void TInsert(Category t)
        {
            _categoryDal.Insert(t); 
            //if(t.CategoryName!=null && t.CategoryName.Length>=5 && t.CategoryDescription.StartsWith("A"))
            //{
            //       _categoryDal.Insert(t);
            //}
            //else
            //{
            //    //hata mesajı
            //}
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
