using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.Abstract
{
    public interface IEmployeeTaskDetailDal:IGenericDal<EmployeeTaskDetail>
    {
        List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id); //görevin detayları id.ye göre gelicek.
    }
}
