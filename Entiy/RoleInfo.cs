using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    public class RoleInfo
    {
        /// <summary>
        /// 主键ID  
        /// </summary>
         [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        public string RoleName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string Description { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
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

