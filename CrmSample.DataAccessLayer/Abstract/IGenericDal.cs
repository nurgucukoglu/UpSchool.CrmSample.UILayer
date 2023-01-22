using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t); //burdaki metotların tanımlaması opsiyonel. fakat managerda.da o isimle çağırılması gerekir 
        List<T> GetList();
        T GetById(int id);
    }
}
