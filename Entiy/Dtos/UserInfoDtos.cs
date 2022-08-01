using System;

namespace StorehouseSys.Models.Dtos
{
    public class UserInfoDtos
    {
        public string Id { get; set; }

        public string Account { get; set; }

        public string UserName { get; set; }

        public string PhoneNum { get; set; }

        public string PassWord { get; set; }

        public string Email { get; set; }

        public string DepartmentId { get; set; }

        public string Sex { get; set; }

        public string IsAdmin { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
