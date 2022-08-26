using Entiy;
using Entiy.Dtos;
using StorehouseSys.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLL
{
    public interface IR_UserInfo_RoleInfoBll
    {
        /// <summary>
        /// 获取绑定角色数据集
        /// </summary>
        /// <returns></returns>
        public List<UserInfoDtos> GetUserInfoDtos();

        /// <summary>
        /// 获取用户已绑定角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<string> GetBindUserInfo(string roleId);
        //bool DalRoleInfo(string[] iD, out string msg);
        //R_UserInfo_RoleInfo GetRoleInfoById(string iD);
        //bool UpdateRoleInfo(R_UserInfo_RoleInfoDtos roleInfoDtos, out string msg);
        /// <summary>
        /// 绑定角色数据
        /// </summary>
        /// <param name="roleInfoDtos"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool BindRoleInfo(string roleId, string[] userId, out string msg);
    }
}
