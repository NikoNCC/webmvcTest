using System;

namespace StorehouseSys.Models.Dtos
{
    public class UserInfoDtos
    {
        /// <summary>
        /// 用户主键ID    
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户账号  
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        ///用户名  
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///用户手机号码
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// //部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 用户字符串性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 用户管理员判断
        /// </summary>
        public string IsAdmin { get; set; }
        /// <summary>
        /// 用户删除判断
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 用户创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
