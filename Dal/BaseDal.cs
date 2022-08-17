using Entiy;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class BaseDal<T>:IBaseDal<T> where T : BaseEntity
    {
        /// <summary>
        /// 创建上下文对象
        /// </summary>
        private readonly StorehouseSysDbContext _storehouseSysDbContext;
        public BaseDal(StorehouseSysDbContext storehouseSysDbContext)
        {
            this._storehouseSysDbContext = storehouseSysDbContext;
        }
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity)
        {
            _storehouseSysDbContext.Set<T>().Add(entity);
            return _storehouseSysDbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 硬删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelRemoveEntity(string Id)
        {
            T entity = _storehouseSysDbContext.Set<T>().Find(Id);
            _storehouseSysDbContext.Remove(entity);
            return _storehouseSysDbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 查询单个实体信息
        /// </summary>
        /// <param name="Id"></param>
        public T FindEntity(string Id)
        {
          return  _storehouseSysDbContext.Set<T>().Find(Id);
        }

        /// <summary>
        /// 获取一个数据集
        /// </summary>
        public DbSet<T> GetEntity()
        {
            return _storehouseSysDbContext.Set<T>();
        }

        public bool UpdateEntiry(T entity)
        {
            _storehouseSysDbContext.Set<T>().Update(entity);
            return _storehouseSysDbContext.SaveChanges() > 0;
        }
    }
}
