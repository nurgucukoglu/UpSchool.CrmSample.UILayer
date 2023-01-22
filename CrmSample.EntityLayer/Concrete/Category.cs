using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.EntityLayer.Concrete
{

    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ICollection<Employee> Employees{ get; set; } //employee.dan koleksiyon oluşturduk.

    }
}
