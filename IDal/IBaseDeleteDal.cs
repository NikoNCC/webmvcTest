using Entiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDal
{
    /// <summary>
    /// 软删除基类接口
    /// </summary>
    public interface IBaseDeleteDal<T> : IBaseDal<T> where T : DelEntity
    {
        
        public bool DelEntity(List<T> list);
    }
}
