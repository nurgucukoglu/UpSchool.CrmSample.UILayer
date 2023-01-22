using CrmSample.BusinessLayer.Abstract;
using CrmSample.DataAccessLayer.Abstract;
using CrmSample.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.Concrete
{
    public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
    {
        private readonly IEmployeeTaskDetailDal _employeeTaskDetailDal;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetailDal)
        {
            _employeeTaskDetailDal = employeeTaskDetailDal;
        }
        public void TDelete(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTaskDetail TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTaskDetail> TGetEmployeeTaskDetailById(int id)
        {
            return _employeeTaskDetailDal.GetEmployeeTaskDetailById(id);
        }

        public List<EmployeeTaskDetail> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(EmployeeTaskDetail t)
        {
            throw new NotImplementedException();
        }
    }
}
