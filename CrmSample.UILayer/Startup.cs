using CrmSample.BusinessLayer.Abstract;
using CrmSample.BusinessLayer.Concrete;
using CrmSample.BusinessLayer.DIContainer;
using CrmSample.DataAccessLayer.Abstract;
using CrmSample.DataAccessLayer.Concrete;
using CrmSample.DataAccessLayer.EntityFramework;
using CrmSample.EntityLayer.Concrete;
using CrmSample.UILayer.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmSample.UILayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            services.ContainerDependencies();

			//Automapper i�in yap�land�rmay� buraya yaz�yoruz
			//Type of Startup

			services.AddAutoMapper(typeof(Startup));

			services.CustomizeValidator();//DI i�indek, atomapper i�in yazd���m�z method

			services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));


			services.AddDbContext<Context>(); 

            services.AddIdentity<AppUser,AppRole>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
			//AddEntityFrameworkStore: entity fr. i�inde kullan ve i�ine parametre olarak: bizim yazd���m�z Context al�cak. VE �stteki DbContext.i de ekledik.
			services.AddControllersWithViews().AddFluentValidation();
			//AddControllers with view'in sonuna AddFluentValidation() metodunu ekliyoruz. Bunu ekleme sebebimiz validasyonlar� g�sterebilmesi



			services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()//bu k�s�m t�m sayfalarda yetkilendirme yani kullan�c� login olmadan hi�bir sayfaya eri�ememesini sa�lar
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";//kullan�c� login olmadan eri�meye �al���rsa login sayfas�na y�nlendirilmesini sa�lar
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();    

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "employeTask",
                  pattern: "{controller=EmployeeTask}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );
            });
        }
    }
}
