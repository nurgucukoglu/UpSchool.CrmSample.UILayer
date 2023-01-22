using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.Abstract
{
    public interface IEmployeeService:IGenericService<Employee>
    {
        List<Employee> TGetEmployeeByCategory();
        void TChangeEmployeeStatusToTrue(int id);
        void TChangeEmployeeStatusToFalse(int id); //IEmpDal.da yazılan metotları burda çağırdık. DataAccess katmanına karışmasın diye başına T koyduk.
    }
}
