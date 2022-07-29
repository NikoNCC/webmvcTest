using Entiy;
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
        public List<UserInfo> GetUserInfos()
        {
            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
              return db.UserInfo.ToList();
            }
        }

        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="userInfoDtos"></param>
        /// <returns></returns>
        public bool AddUserInfos(UserInfoDtos userInfoDtos)
        {
            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
                UserInfo userInfo = new UserInfo() {
                    UserName = userInfoDtos.UserName,
                    Id = Guid.NewGuid().ToString(),
                    DepartmentId = userInfoDtos.DepartmentId,
                    CreateTime = DateTime.Now,
                    Email = userInfoDtos.Email,
                    Account = userInfoDtos.Account,
                    Sex = userInfoDtos.Sex,
                    PassWord = userInfoDtos.PassWord,
                    PhoneNum = userInfoDtos.PhoneNum,
                    IsAdmin = userInfoDtos.IsAdmin,
                };
               db.UserInfo.Add(userInfo);
               return db.SaveChanges() > 0;
            }
            
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DelUserInfo(string iD)
        {
            using (StorehouseSysDbContext db = new StorehouseSysDbContext())
            {
                UserInfo userInfos = db.UserInfo.Find(iD);
                if (userInfos == null)
                {
                    return false;
                }
                if (userInfos.IsDelete)
                {
                    return false;
                }
                userInfos.IsDelete = true;
                db.UserInfo.Update(userInfos);
                return  db.SaveChanges() > 0;
            }
         }
    }
}
