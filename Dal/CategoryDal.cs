using Entity;
using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    /// <summary>
    /// 耗材类型
    /// </summary>
    public class CategoryDal : BaseDal<Category>, ICategoryDal
    {
        private StorehouseSysDbContext _db;

        public CategoryDal(StorehouseSysDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
