using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class BaseDeleteDal<T> : BaseDal<T> where T : DelEntity
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
        public bool DelEntity(string Id)
        {
            T entity = _dbContext.Set<T>().Find(Id);
            entity.IsDelete = true;
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
