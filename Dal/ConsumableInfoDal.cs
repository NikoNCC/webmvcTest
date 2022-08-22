using Entity;
using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    /// <summary>
    /// 耗材信息Dal
    /// </summary>
    public class ConsumableInfoDal: BaseDeleteDal<ConsumableInfo>, IConsumableInfoDal
    {
        private StorehouseSysDbContext _db;

        public ConsumableInfoDal(StorehouseSysDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
