using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    internal class BaseDal
    {
        /// <summary>
        /// 创建上下文对象
        /// </summary>
        private readonly StorehouseSysDbContext _storehouseSysDbContext;
        public IBaseDal(StorehouseSysDbContext storehouseSysDbContext)
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
        /// 软删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelEntity(string Id)
        {
            T entity = _storehouseSysDbContext.Set<T>().Find(Id);
            entity.

        }
        /// <summary>
        /// 硬删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelRemoveEntity(string Id)
        {

        }
        /// <summary>
        /// 查询单个实体信息
        /// </summary>
        /// <param name="Id"></param>
        public void FindEntity(string Id)
        {

        }
        /// <summary>
        /// 获取一个数据集
        /// </summary>
        public void GetEntity()
        {

        }
    }
}
