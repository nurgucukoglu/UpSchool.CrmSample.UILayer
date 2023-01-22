using CrmSample.DataAccessLayer.Abstract;
using CrmSample.DataAccessLayer.Concrete;
using CrmSample.DataAccessLayer.Repository;
using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.EntityFramework
{
    public class EfEmployeeTaskDetail : GenericRepository<EmployeeTaskDetail>, IEmployeeTaskDetailDal

    {
        public List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id)
        {
            using (var context = new Context())
            {
                return context.EmployeeTaskDetails.Where(x => x.EmployeeTaskId == id).ToList();
            }
        }
    }
}
