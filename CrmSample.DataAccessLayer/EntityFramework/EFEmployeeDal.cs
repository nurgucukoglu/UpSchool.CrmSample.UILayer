using CrmSample.DataAccessLayer.Abstract;
using CrmSample.DataAccessLayer.Concrete;
using CrmSample.DataAccessLayer.Repository;
using CrmSample.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.EntityFramework
{
    public class EFEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        public void ChangeEmployeeStatusToFalse(int id)
        {
          using(var context= new Context())
            {
                var values = context.Employees.Find(id); //find id.den gelen değeri ir değişkene atadık.
                values.EmployeeStatus = false;
                context.SaveChanges();
            }
        }

        public void ChangeEmployeeStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var values = context.Employees.Find(id); 
                values.EmployeeStatus = true;
                context.SaveChanges();
            }
        }

        public List<Employee> GetEmployeesByCategory()
        {
           using(var context=new Context())
            {
                return context.Employees.Include(x=> x.Category).ToList();//category tablosunu eklemiş olduk.
            }
        }

        //YUKARIDAKİ 3 METHOD SADECE EMPLOYE SINFINA AİT METOTLAR. BUNLARIN İMZALARINI DA IEMPLOYEEDAL'DA TUTTUK.
    }
}
