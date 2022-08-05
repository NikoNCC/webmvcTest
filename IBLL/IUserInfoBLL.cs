using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// UserInfoBLL接口
    /// </summary>
    public interface IUserInfoBLL
    {

        List<UserInfoDtos> GetUserInfos();

        bool Login(string account, string passWord, out string msg, out string userName);

        bool AddUserInfos(UserInfoDtos userInfoDtos, out string msg);

        UserInfoDtos GetUserInfoById(string id);

        bool UpdateUserInfo(UserInfoDtos userInfoDtos);

        bool DelUserInfo(string[] iD);


    }
}
