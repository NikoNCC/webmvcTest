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

        public char Sex { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
