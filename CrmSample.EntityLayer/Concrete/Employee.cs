using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.EntityLayer.Concrete
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurName { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeeImage{ get; set; }
        public int CategoryID { get; set; }   //employee tablosunun içinde categoryıd diye bir sütun olacak
        public  Category Category { get; set; } // cateıd sütunu da categoryden türetilen bir category propertysi aracılığıyla ilişkiyi kuracak.
        public bool EmployeeStatus { get; set; } //aktif/pasif propertysi
       
    }
}
