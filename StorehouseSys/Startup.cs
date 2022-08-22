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
            //注册UserInfoBLL 用户
            services.AddScoped<IUserInfoBLL, UserInfoBll>();
            //注册UserInfoDal
            services.AddScoped<IUserInfoDal, UserInfoDal>();
            //DepartmentInfoBll 部门
            services.AddScoped<IDepartmentInfoBll, DepartmentInfoBll>();
            //DepartmentInfoDal
            services.AddScoped<IDepartmentInfoDal, DepartmentInfoDal>();
            //注册IRoleInfoBll 角色表
            services.AddScoped<IRoleInfoBll, RoleInfoBll>();
            //注册IRoleInfoDal 
            services.AddScoped<IRoleInfoDal, RoleInfoDal>();
            //注册角色绑定表BLL
            services.AddScoped<IR_UserInfo_RoleInfoBll, R_UserInfo_RoleInfoBll>();
            //注册角色绑定表DAL
            services.AddScoped <IR_UserInfo_RoleInfoDal, R_UserInfo_RoleInfoDal>();
            //菜单管理Dal
            services.AddScoped<IMenuInfoDal, MenuInfoDal>();
            //菜单管理bll
            services.AddScoped<IMenuInfoBll, MenuInfoBll>();

            //注册数据库上下文
            services.AddDbContext<StorehouseSysDbContext>(options =>
                                    options.UseSqlServer("name=ConnectionStrings:UseSqlServer"));
            //注册全局过滤器
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
            //注册session
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
