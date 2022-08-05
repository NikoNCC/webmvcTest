using Entiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDal
{
    /// <summary>
    /// UserInfoDal接口
    /// </summary>
    public interface IUserInfoDal
    {

        DbSet<UserInfo> GetUserInfos();

        bool AddUserInfos(UserInfo userInfo);

        bool DelUserInfo(string[] iD);

        UserInfo Login(string account);

        UserInfo GetUserInfoById(string id);

        bool UpdateUserInfo(UserInfo userInfo);

    }
}
