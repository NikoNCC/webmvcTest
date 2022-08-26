using Entity;
using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    /// <summary>
    /// 耗材记录
    /// </summary>
    public class ConsumableRecordDal:BaseDal<ConsumableRecord>,IConsumableRecordDal
    {
        private StorehouseSysDbContext _db;

        public ConsumableRecordDal(StorehouseSysDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
