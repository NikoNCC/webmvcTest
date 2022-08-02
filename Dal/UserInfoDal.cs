using Entiy;
using Microsoft.EntityFrameworkCore;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    public class UserInfoDal
    {
        /// <summary>
        /// 用户数据
        /// </summary>
        /// <returns></returns>
        public DbSet<UserInfo> GetUserInfos()
        {
            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
                return db.UserInfo;
            }
        }

        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        public bool AddUserInfos(UserInfo userInfo)
        {
            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
                db.UserInfo.Add(userInfo);
                return db.SaveChanges() > 0;
            }

        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DelUserInfo(string[] iD)
        {
            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
                List<UserInfo> userInfolist = new List<UserInfo>();
                foreach (var i in iD)
                {
                    UserInfo userInfos = db.UserInfo.Find(i);
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
                db.UserInfo.UpdateRange(userInfolist);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 获取修改用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(string id)
        {

            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
                return db.UserInfo.FirstOrDefault(x => x.Id == id);

            }
        }
        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfo userInfo)
        {
            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
                db.UserInfo.Update(userInfo);
                return db.SaveChanges() > 0;

            }
        }
    }
}