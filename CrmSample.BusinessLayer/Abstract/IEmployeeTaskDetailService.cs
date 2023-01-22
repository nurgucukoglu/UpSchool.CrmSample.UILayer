using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.Abstract
{
    public interface IEmployeeTaskDetailService:IGenericService<EmployeeTaskDetail>
    {
        List<EmployeeTaskDetail> TGetEmployeeTaskDetailById(int id);
    }
}
