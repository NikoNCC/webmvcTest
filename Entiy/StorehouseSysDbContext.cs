using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy
{
    public class StorehouseSysDbContext: DbContext
    {
        public StorehouseSysDbContext(DbContextOptions<StorehouseSysDbContext> options) : base(options)
        {
        }

        public StorehouseSysDbContext()
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer($"Data Source=.;Initial Catalog=StorehouseSys;User ID=sa;Password=123");
        //}


        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<DepartmentInfo> DepartmentInfo { get; set; }
    }
}
