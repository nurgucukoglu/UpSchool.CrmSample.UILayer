using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.EntityLayer.Concrete
{
    public class EmployeeTask
    {
        public int EmployeeID { get; set; }
        public int EmployeeTaskID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }  //görevin detayları için
        public string Status { get; set; }  //görev tamamlandı,tamamlanmadı vs
        public DateTime Date { get; set; }
        public int AppUserID { get; set; } //görevin verildiği kişi
        public AppUser AppUser{ get; set; }
         public List<EmployeeTaskDetail> EmployeeTaskDetails { get; set; }
    }
}
