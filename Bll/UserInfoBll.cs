using Dal;
using Entiy;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bll
{
    public class UserInfoBll
    {

        UserInfoDal _userInfoDal = new UserInfoDal();

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public List<UserInfoDtos> GetUserInfos()
        {
           List<UserInfo> userInfos =  _userInfoDal.GetUserInfos().ToList();
          List<UserInfoDtos> userInfoDtos = new List<UserInfoDtos>();
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
        /// 登录功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool Login(string account, string passWord,out string msg,out string userName)
        {
         UserInfo userInfo = _userInfoDal.Login(account);
            userName = null;
            if (userInfo == null)
            {
              msg = "账号不存在";
              return false;
            }
            string newPassWord = Comm.MD5Str.MD5(passWord);
            if (userInfo.PassWord == newPassWord)
            {
                msg = "登录成功";
                userName = userInfo.UserName;
                return true;
            }
                msg = "密码错误";
                return false;
        }



        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        public bool AddUserInfos(UserInfoDtos userInfoDtos,out string msg)
        {
            string newpassword = Comm.MD5Str.MD5(userInfoDtos.PassWord);
            UserInfo userInfos = _userInfoDal.GetUserInfos().FirstOrDefault(u => u.Account == userInfoDtos.Account);
            //判断用户是否存在
           
            if (userInfos != null)
            {
                msg = "用户不存在";
                return false;
              
            }
            UserInfo userInfo = new UserInfo()
            {
                UserName = userInfoDtos.UserName,
                Id = Guid.NewGuid().ToString(),
                DepartmentId = userInfoDtos.DepartmentId,
                CreateTime = DateTime.Now,
                Email = userInfoDtos.Email,
                Account = userInfoDtos.Account,
                Sex = userInfoDtos.Sex == "男" ? 1 : 0,
                PassWord = newpassword,
                PhoneNum = userInfoDtos.PhoneNum,
                IsAdmin = userInfoDtos.IsAdmin == "是" ? true : false,
            };
            msg = "添加成功";
            return _userInfoDal.AddUserInfos(userInfo);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DelUserInfo(string[] iD)
        {
               
                return _userInfoDal.DelUserInfo(iD);
        }

        /// <summary>
        /// 查询修改用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfoDtos GetUserInfoById(string id)
        {
            UserInfo userInfo = _userInfoDal.GetUserInfoById(id);

            UserInfoDtos userInfoDtos = new UserInfoDtos()
            {
                Id = userInfo.Id,
                UserName = userInfo.UserName,
                Sex = userInfo.Sex == 1 ? "男" : "女",
                Email = userInfo.Email,
                Account = userInfo.Account,
                DepartmentId = userInfo.DepartmentId,
                PhoneNum = userInfo.PhoneNum,
                IsAdmin = userInfo.IsAdmin == true ? "是" : "否",
                CreateTime = userInfo.CreateTime
            };
            return userInfoDtos;
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfoDtos userInfoDtos)
        {
            UserInfo userInfo = _userInfoDal.GetUserInfoById(userInfoDtos.Id);
            if (userInfo != null)
            { 
                    userInfo.Id = userInfoDtos.Id;
                    userInfo.Account =userInfoDtos.Account;
                    userInfo.DepartmentId = userInfoDtos.DepartmentId;
                    userInfo.PhoneNum = userInfoDtos.PhoneNum;
                    userInfo.UserName = userInfoDtos.UserName;
                    userInfo.Sex = userInfoDtos.Sex.Equals("男") ?  1 : 0;
                    userInfo.Email = userInfoDtos.Email;
                    userInfo.CreateTime = DateTime.Now;
            }
            return _userInfoDal.UpdateUserInfo(userInfo);
        }
    }
}
