using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiy
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserInfo:DelEntity
    {
       
        /// <summary>
        /// 账号
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        public string Account { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string UserName { get; set; }
        /// <summary>
        ///  电话号码
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        public string PhoneNum { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string Email { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string PassWord { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime CreateTime { get; set; }
     
    }
}
