using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.Abstract
{
    public interface IEmployeeTaskService:IGenericService<EmployeeTask>
    {
        List<EmployeeTask> TGetEmployeeTaskByEmployee(); //entitye özel metot.
        List<EmployeeTask> TGetEmployeeTaskById(int id); //TaskDal.da yazdığımız metot

    }
}
