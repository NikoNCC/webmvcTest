using Entiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 角色菜单实体
    /// </summary>
    public class R_RoleInfo_MenuInfo : BaseEntity
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string MenuId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RoleId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
