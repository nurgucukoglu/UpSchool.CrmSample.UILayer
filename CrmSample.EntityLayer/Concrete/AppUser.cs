using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int> //içine key.i karşılayacak değer girmemiz gerek. default olarak nvarchar,string gelir. bizde id.oto artan olacağından int verdik.
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
        public string EmailConfirmedControlCode { get; set; }

        public List<EmployeeTask> EmployeeTasks { get; set; } //görev vermek için emptaskteki bağlantı list.i
    }
}
