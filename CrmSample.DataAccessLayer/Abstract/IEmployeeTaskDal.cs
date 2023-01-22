using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.Abstract
{
    public interface IEmployeeTaskDal:IGenericDal<EmployeeTask>
    {
        List<EmployeeTask> GetEmployeeTaskByEmployee(); //entitye özgü metodu tanımladık.
        List<EmployeeTask> GetEmployeeTaskById(int id); //giriş yapan kullanıcının bilgilerini getirmek için metot yazdık ent.ye özel
    }
}
