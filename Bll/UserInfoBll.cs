using Dal;
using Entiy;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;

namespace Bll
{
    public class UserInfoBll
    {


        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserInfos()
        {
            UserInfoDal userInfoDal = new UserInfoDal();

            return userInfoDal.GetUserInfos();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        public bool AddUserInfos(UserInfoDtos userInfoDtos)
        {
            UserInfoDal userInfoDal = new UserInfoDal();
            return userInfoDal.AddUserInfos(userInfoDtos);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DelUserInfo(string[] iD)
        {
            UserInfoDal userInfoDal = new UserInfoDal();
        
            return userInfoDal.DelUserInfo(iD);
        }
    }
}
