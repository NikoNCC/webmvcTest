using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy.Dtos
{
    /// <summary>
    /// 绑定用户角色表
    /// </summary>
    public class R_UserInfo_RoleInfoDtos
    {
        /// <summary>
        /// 主键ID
        /// </summary>
       
        public string Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>

        public string UserId
        { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
      
        public string RoleId
        { get; set; }
        public DateTime CreateTime
        { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }
    }
}

