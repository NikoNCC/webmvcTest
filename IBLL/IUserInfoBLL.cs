using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// UserInfoBLL接口
    /// </summary>
    public interface IUserInfoBLL
    {

        List<UserInfoDtos> GetUserInfos();


        bool Login(string account, string passWord, out string msg, out string userName,out string Id);

        bool AddUserInfos(UserInfoDtos userInfoDtos, out string msg);

        UserInfoDtos GetUserInfoById(string Id);

        bool UpdateUserInfo(UserInfoDtos userInfoDtos);

        bool DelUserInfo(string[] Id,out string msg);
        bool UpdateUserPassWord(string old_password,string new_password,string userId,out string msg);
    }
}
