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
    public class ProductManager : IProductService
    {
        IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void TDelete(Product t)
        {
            productDal.Delete(t);
        }

        public Product TGetById(int id)
        {
            return productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
            return productDal.GetList();
        }

        public void TInsert(Product t)
        {
            productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
           productDal.Update(t);
        }
    }
}
