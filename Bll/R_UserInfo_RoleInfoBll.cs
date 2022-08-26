using Dal;
using Entiy;
using Entiy.Dtos;
using IBLL;
using IDal;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class R_UserInfo_RoleInfoBll : IR_UserInfo_RoleInfoBll
    {
        private readonly IR_UserInfo_RoleInfoDal _R_UserInfo_RoleInfoDal;
        private readonly IUserInfoDal _userInfoDal;
        /// <summary>
        /// Dal
        /// </summary>
        /// <param name="r_UserInfo_RoleInfoDal"></param>
        public R_UserInfo_RoleInfoBll(IR_UserInfo_RoleInfoDal r_UserInfo_RoleInfoDal, IUserInfoDal userInfoDal)
        {
            _R_UserInfo_RoleInfoDal = r_UserInfo_RoleInfoDal;
            _userInfoDal = userInfoDal;
        }

        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="roleInfoDtos"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool BindRoleInfo(string roleId, string[] userId, out string msg)
        {
            msg = null;
            //获取该角色列表
            List<R_UserInfo_RoleInfo> rolelist = _R_UserInfo_RoleInfoDal.GetEntity().Where(a => a.RoleId == roleId).ToList();

            List<string> rightList = _R_UserInfo_RoleInfoDal.GetEntity().Where(r => r.RoleId == roleId).Select(r => r.UserId).ToList();
            ///解绑

            if (userId.Length == 0)
            {
                foreach (var cleaRoleList in rolelist)
                {
                    _R_UserInfo_RoleInfoDal.DelRemoveEntity(cleaRoleList.Id);
                }
                msg = "角色清除完成，请重新绑定";
                return true;
            }


            foreach (var role in rolelist)
            {
                bool isHas = false;
                foreach (var userById in rightList)
                {
                    if (role.UserId == userById)
                    {
                        isHas = true;
                    }

                    if (!isHas)
                    {
                        _R_UserInfo_RoleInfoDal.DelRemoveEntity(role.Id);
                        msg = "解绑成功";
                    }
                }

            }





            //绑定
            List<R_UserInfo_RoleInfo> list = new List<R_UserInfo_RoleInfo>();
            foreach (var i in userId)
            {
                R_UserInfo_RoleInfo role = new R_UserInfo_RoleInfo();

                if (rolelist.Where(a => a.UserId == i).Count() == 0)
                {
                    role.RoleId = roleId;
                    role.UserId = i;
                    role.CreateTime = DateTime.Now;
                    role.Id = Guid.NewGuid().ToString();
                    list.Add(role);

                }
            }
            bool res = _R_UserInfo_RoleInfoDal.AddEntityRange(list);
            if (res)
            {
                msg = "绑定成功";
                return res;
            }
            
            return res;

            
        }
        /// <summary>
        /// 获取用户信息用于绑定角色
        /// </summary>
        /// <returns></returns>
        public List<UserInfoDtos> GetUserInfoDtos()
        {
            List<UserInfoDtos> list = _userInfoDal.GetEntity().Where(a => !a.IsDelete).Select(a => new UserInfoDtos
            {
                Id = a.Id,
                UserName = a.UserName
            }
               ).ToList();
            return list;


        }
        /// <summary>
        /// 获取已绑定角色的用户数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<string> GetBindUserInfo(string roleId)
        {


            List<string> rightList = _R_UserInfo_RoleInfoDal.GetEntity().Where(r => r.RoleId == roleId).Select(r => r.UserId).ToList();
            return rightList;


        }

    }
}
