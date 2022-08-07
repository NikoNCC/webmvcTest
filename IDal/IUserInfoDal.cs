using Entiy;
using Microsoft.EntityFrameworkCore;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    /// <summary>
    /// UserInfoDal接口
    /// </summary>
    public interface IUserInfoDal
    {

        IQueryable<UserInfoDtos> GetUserInfos();

        bool AddUserInfos(UserInfo userInfo);

        bool DelUserInfo(string[] iD);

        UserInfo Login(string account);

        UserInfo GetUserInfoById(string id);

        bool UpdateUserInfo(UserInfo userInfo);

    }
}
