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

			//Automapper için yapýlandýrmayý buraya yazýyoruz
			//Type of Startup

			services.AddAutoMapper(typeof(Startup));

			services.CustomizeValidator();//DI içindek, atomapper için yazdýðýmýz method

			services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));


			services.AddDbContext<Context>(); 

            services.AddIdentity<AppUser,AppRole>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
			//AddEntityFrameworkStore: entity fr. içinde kullan ve içine parametre olarak: bizim yazdýðýmýz Context alýcak. VE üstteki DbContext.i de ekledik.
			services.AddControllersWithViews().AddFluentValidation();
			//AddControllers with view'in sonuna AddFluentValidation() metodunu ekliyoruz. Bunu ekleme sebebimiz validasyonlarý gösterebilmesi



			services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()//bu kýsým tüm sayfalarda yetkilendirme yani kullanýcý login olmadan hiçbir sayfaya eriþememesini saðlar
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";//kullanýcý login olmadan eriþmeye çalýþýrsa login sayfasýna yönlendirilmesini saðlar
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
