using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.Abstract
{
    public  interface IEmployeeDal:IGenericDal<Employee>
    {
        //BU METHOD SADECE EMPLOYEE SINIFINA ÖZELDİR. SO EMP İNTF İÇİNE TANIMLANADI.
        List<Employee> GetEmployeesByCategory(); // Amacı: employeeları kategorileriyle beraber getirmek.

        void ChangeEmployeeStatusToTrue(int id);
        void ChangeEmployeeStatusToFalse(int id);
    }
}
