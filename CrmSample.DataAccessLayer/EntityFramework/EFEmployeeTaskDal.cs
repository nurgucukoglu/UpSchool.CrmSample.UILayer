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
    public class EfEmployeeTaskDal : GenericRepository<EmployeeTask>, IEmployeeTaskDal
    {
        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
            //INCLUDE İŞLEMİ
            using (var context = new Context())//context.i örnekledim
            {
                var values = context.EmployeeTasks.Include(x => x.AppUser).ToList(); //include işlemi yaptım.
                return values;
            }
        }

        public List<EmployeeTask> GetEmployeeTaskById(int id)
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Where(x => x.AppUserID == id).ToList();
                return values;
            }
        }
    }
}
