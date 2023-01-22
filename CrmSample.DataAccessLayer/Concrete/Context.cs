using CrmSample.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser, AppRole,int> // burda kendi özelleştirdiğim parametleri girdim.gelmesini istediğim
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=ENES; Database=DbCRM; integrated Security=True;");

            //optionsBuilder.UseSqlServer("Server=mysqlserversamplenur.database.windows.net;Database=DbCRM;User ID=azureuser;Password=Eminenur01;");

            optionsBuilder.UseSqlServer("Server=DESKTOP-0LTDDDI\\SQLEXPRESS01; Database=DbCRM; integrated Security=True;");


        }

        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<EmployeeTaskDetail> EmployeeTaskDetails { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Announcement> Announcements { get; set; } 
        public DbSet<Supplier> Suppliers { get; set; } 
        public DbSet<Contact> Contacts { get; set; } 


    }
}
