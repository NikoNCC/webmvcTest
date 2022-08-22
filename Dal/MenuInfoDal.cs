using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    /// <summary>
    /// 菜单管理DAL
    /// </summary>
    public class MenuInfoDal:BaseDeleteDal<MenuInfo> ,IMenuInfoDal
    {
        private readonly StorehouseSysDbContext _dbContext;
        public MenuInfoDal(StorehouseSysDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
