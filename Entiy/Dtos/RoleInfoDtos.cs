using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy.Dtos
{
    public class RoleInfoDtos
    {  /// <summary>
       /// 主键ID  
       /// </summary>
     
        public string Id { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
       
        public string RoleName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public string DeleteTime { get; set; }

    }
}
