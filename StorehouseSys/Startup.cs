using Bll;
using Comm;
using Dal;
using Entiy;
using IBLL;
using IDal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorehouseSys
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
            services.AddControllersWithViews();
            services.AddSession();
            //ע��UserInfoBLL
            services.AddScoped<IUserInfoBLL, UserInfoBll>();
            //ע��UserInfoDal
            services.AddScoped<IUserInfoDal, UserInfoDal>();
            //DepartmentInfoBll
            services.AddScoped<IDepartmentInfoBll, DepartmentInfoBll>();
            //DepartmentInfoDal
            services.AddScoped<IDepartmentInfoDal, DepartmentInfoDal>();
            //ע�����ݿ�������
            services.AddDbContext<StorehouseSysDbContext>(options =>
                                    options.UseSqlServer("name=ConnectionStrings:UseSqlServer"));
            //ע��ȫ�ֹ�����
            services.AddMvc(options =>
                          {
                              options.Filters.Add(typeof(LoginFiter));
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //ע��session
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=LoginView}/{id?}");
            });
        }
    }
}
