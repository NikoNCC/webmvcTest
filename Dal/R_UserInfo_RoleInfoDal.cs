using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class R_UserInfo_RoleInfoDal: BaseDal<R_UserInfo_RoleInfo>,IR_UserInfo_RoleInfoDal
    {
        private readonly StorehouseSysDbContext _DbContext;
        public R_UserInfo_RoleInfoDal(StorehouseSysDbContext dbContext):base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
