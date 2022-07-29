using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiy
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserInfo
    {


        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column(TypeName = "varchar(16)")]
        public string Account { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(16)")]
        public string PhoneNum { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(36)")]
        public string DepartmentId { get; set; }

        public int Sex { get; set; }

        [Column(TypeName = "varchar(32)")]


        public string PassWord { get; set; }



        public bool IsAdmin { get; set; }



        public  DateTime CreateTime { get; set; }



        public bool IsDelete { get; set; }



        public DateTime DeleteTime { get; set; }



    }
}
