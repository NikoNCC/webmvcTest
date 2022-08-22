using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    public class R_UserInfo_RoleInfo : BaseEntity
    {
        
        /// <summary>
        /// 用户ID
        /// </summary>//
        [Column(TypeName = "varchar(36)")]
        public string UserId
        {get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string RoleId
        {get; set; }
           public DateTime CreateTime
        { get; set; }

        }
    }
