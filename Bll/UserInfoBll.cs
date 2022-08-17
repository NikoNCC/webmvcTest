using Dal;
using Entiy;
using IBLL;
using IDal;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bll
{
    public class UserInfoBll : IUserInfoBLL
    {

        IUserInfoDal _userInfoDal;
        IDepartmentInfoDal _departmentInfoDal;
        public UserInfoBll(IUserInfoDal userInfoDal, IDepartmentInfoDal departmentInfoDal)
        {
            _userInfoDal = userInfoDal;
            _departmentInfoDal=departmentInfoDal;
    }


        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public List<UserInfoDtos> GetUserInfos()
        {
            var list = from a in _userInfoDal.GetEntity().Where(a => !a.IsDelete).OrderByDescending(a => a.CreateTime)
                       join b in _departmentInfoDal.GetEntity().Where(a => !a.IsDelete)
                       on a.DepartmentId equals b.Id
                       select new UserInfoDtos
                       {
                            Account= a.Account,
                            CreateTime = a.CreateTime.ToShortTimeString(),
                            DepartmentName =b.DepartmentName,
                            Email =a.Email,
                            Id =a.Id,
                            PhoneNum =a.PhoneNum,
                            Sex = a.Sex  ==1 ?"男":"女",
                            UserName =a.UserName,
                            IsAdmin = a.IsAdmin ==true? "YES":"NO",
                       };
            return list.ToList();
        }

        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool Login(string account, string passWord,out string msg,out string userName,out string Id)
        {
         UserInfo userInfo = _userInfoDal.Login(account);
            userName = null;
            Id = null;
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
                Id = userInfo.Id;
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
            UserInfo userInfos = _userInfoDal.GetEntity().FirstOrDefault(u => u.Account == userInfoDtos.Account);
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
            return _userInfoDal.AddEntity(userInfo);
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
            UserInfo userInfo = _userInfoDal.FindEntity(id);

            UserInfoDtos userInfoDtos = new UserInfoDtos()
            {
                Id = userInfo.Id,
                UserName = userInfo.UserName,
                Sex = userInfo.Sex == 1 ? "男" : "女",
                Email = userInfo.Email,
                Account = userInfo.Account,
                DepartmentId = userInfo.DepartmentId,
                PassWord = userInfo.PassWord,
                PhoneNum = userInfo.PhoneNum,
                IsAdmin = userInfo.IsAdmin == true ? "是" : "否",
                CreateTime = userInfo.CreateTime.ToString("yyyy-MM-dd HH-mm-ss"),
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
            //根据ID查询用户
            UserInfo userInfo = _userInfoDal.FindEntity(userInfoDtos.Id);
            if (userInfo != null)
            {       //填写用户修改信息
                    userInfo.Id = userInfoDtos.Id;
                    userInfo.Account = userInfoDtos.Account;
                    userInfo.DepartmentId = userInfoDtos.DepartmentId;
                    userInfo.PhoneNum = userInfoDtos.PhoneNum;
                    userInfo.UserName = userInfoDtos.UserName;
                    userInfo.Sex = userInfoDtos.Sex.Equals("男") ? 1 : 0;
                    userInfo.Email = userInfoDtos.Email;
            }
            return _userInfoDal.UpdateEntiry(userInfo);
        }
        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="old_password"></param>
        /// <param name="new_password"></param>
        /// <param name="userId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateUserPassWord(string old_password, string new_password, string userId,out string msg)
        {
            //根据ID查找用户
            UserInfo userInfo = _userInfoDal.FindEntity(userId);
            msg = null;
            if (userInfo == null)
            {
                msg = "用户不存在";
                return false;
            }
            //加密旧密码比对
            string Md5old_password = Comm.MD5Str.MD5(old_password);
            if (userInfo.PassWord != Md5old_password)
            {
                msg = "密码错误";
                return false;

            }
            //加密新密码更改
            string Md5new_password = Comm.MD5Str.MD5(new_password);
            userInfo.PassWord = Md5new_password;
           bool res = _userInfoDal.UpdateEntiry(userInfo);
            if (res)
            {
                msg = "修改密码成功";
                return true;
            }
            else {
                msg = "修改密码失败";
                return false;
            }
        }
    }
}
