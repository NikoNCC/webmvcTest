using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class BaseDeleteDal<T> : BaseDal<T>, IBaseDeleteDal<T> where T : DelEntity
    {
        StorehouseSysDbContext _dbContext;
        public BaseDeleteDal(StorehouseSysDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelEntity(List<T> list)
        {

            _dbContext.Set<T>().UpdateRange(list);
            return _dbContext.SaveChanges() > 0;
        }
   
    }
}
