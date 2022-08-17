using Entiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    public interface IBaseDal<T> where T : BaseEntity
    {
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity);
        /// <summary>
        /// 硬删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelRemoveEntity(string Id);
        /// <summary>
        /// 查询单个实体信息
        /// </summary>
        /// <param name="Id"></param>
        public T FindEntity(string Id);
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DbSet<T> GetEntity();
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntiry(T entity);
    }
}
