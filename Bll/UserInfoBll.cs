using Dal;
using Entiy;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;

namespace Bll
{
    public class UserInfoBll
    {

        UserInfoDal userInfoDal = new UserInfoDal();

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public List<UserInfoDtos> GetUserInfos()
        {
           
            List<UserInfo> userInfos =  userInfoDal.GetUserInfos();
          List< UserInfoDtos> userInfoDtos = new List<UserInfoDtos>();
            foreach (var i in userInfos)
            {
                userInfoDtos.Add(new UserInfoDtos
                {
                    IsDelete = i.IsDelete,
                    Id = i.Id,
                    DepartmentId = i.DepartmentId,
                    Account = i.Account,
                    Email = i.Email,
                    CreateTime = i.CreateTime,
                    PhoneNum = i.PhoneNum,
                    IsAdmin = i.IsAdmin == true ? "是" : "否",
                    PassWord = i.PassWord,
                    Sex = i.Sex == 1 ? "男" : "女",
                    UserName = i.UserName,
                   
                });
              
            }
            return userInfoDtos;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        public bool AddUserInfos(UserInfoDtos userInfoDtos)
        {
                 
              return userInfoDal.AddUserInfos(userInfoDtos);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DelUserInfo(string[] iD)
        {
               
                return userInfoDal.DelUserInfo(iD);
        }
    }
}
