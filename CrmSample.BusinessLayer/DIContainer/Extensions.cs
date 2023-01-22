using CrmSample.BusinessLayer.Abstract;
using CrmSample.BusinessLayer.Concrete;
using CrmSample.BusinessLayer.ValidationRules.AppUserValidation;
using CrmSample.BusinessLayer.ValidationRules.ContactValidation;
using CrmSample.DataAccessLayer.Abstract;
using CrmSample.DataAccessLayer.EntityFramework;
using CrmSample.DTOLayer.AppUserDTOs;
using CrmSample.DTOLayer.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSample.BusinessLayer.DIContainer
{
    public static class Extensions //extension metot static yazılır çünkü hem bu class new.lenemesin hme d her yerde adını çağırıp kullanabiliyim.
    {

        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EFEmployeeDal>();

            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDal, EfEmployeeTaskDal>();

            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDal, EfEmployeeTaskDetail>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EFMessageDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EFCustomerDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();
        }

		//Automapper için 
		public static void CustomizeValidator(this IServiceCollection services)
		{
			//DTO ve onun ilgili validator eşleştirmelerini burada yazıp tanımlıyoruz
			services.AddTransient<IValidator<ContactAddDTO>, ContactAddValidator>();
			services.AddTransient<IValidator<ContactUpdateDTO>, ContactUpdateValidator>();
			services.AddScoped<IValidator<AppUserLoginDTO>, AppUserLoginValidator>();



		}
	}
}
