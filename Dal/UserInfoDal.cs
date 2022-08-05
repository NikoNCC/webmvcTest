using Entiy;
using IDal;
using Microsoft.EntityFrameworkCore;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    public class UserInfoDal: IUserInfoDal
    {
        private StorehouseSysDbContext _db;

        public UserInfoDal(StorehouseSysDbContext db)
        {
            _db = db;
        }


        /// <summary>
        /// 用户数据
        /// </summary>
        /// <returns></returns>
        public DbSet<UserInfo> GetUserInfos()
        {
           
            
                return _db.UserInfo;
            
        }

        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        public bool AddUserInfos(UserInfo userInfo)
        {
            
                _db.UserInfo.Add(userInfo);
                return _db.SaveChanges() > 0;
            

        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DelUserInfo(string[] iD)
        {
            
                List<UserInfo> userInfolist = new List<UserInfo>();
                foreach (var i in iD)
                {
                    UserInfo userInfos = _db.UserInfo.Find(i);
                    if (userInfos == null)
                    {
                        return false;
                    }
                    if (userInfos.IsDelete)
                    {
                        return false;
                    }
                    userInfos.IsDelete = true;
                    userInfos.DeleteTime = DateTime.Now;
                    userInfolist.Add(userInfos);
                }
            _db.UserInfo.UpdateRange(userInfolist);
                return _db.SaveChanges() > 0;
            
        }

        /// <summary>
        /// 登录功能
        /// </summary>
        /// <returns></returns>
        public UserInfo Login(string account)
        {
            
            UserInfo userInfo = _db.UserInfo.Where(u => u.Account ==account).FirstOrDefault();
            return userInfo;
        }

        /// <summary>
        /// 获取修改用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(string id)
        {

            
                return _db.UserInfo.FirstOrDefault(x => x.Id == id);

            
        }
        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfo userInfo)
        {

                _db.UserInfo.Update(userInfo);
                return _db.SaveChanges() > 0;

            
        }
    }
}