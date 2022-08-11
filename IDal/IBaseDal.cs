using Entiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    public interface IBaseDal<T> where T : class
    {
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(T entity);
        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelEntity(string Id);
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
        public void FindEntity(string Id);
        /// <summary>
        /// 获取一个数据集
        /// </summary>
        void GetEntity();
    }
}
