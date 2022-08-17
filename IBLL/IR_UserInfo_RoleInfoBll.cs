using Entiy;
using Entiy.Dtos;
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
        IQueryable<R_UserInfo_RoleInfoDtos> GetRoleInfo();
        //bool DalRoleInfo(string[] iD, out string msg);
        //R_UserInfo_RoleInfo GetRoleInfoById(string iD);
        //bool UpdateRoleInfo(R_UserInfo_RoleInfoDtos roleInfoDtos, out string msg);
        /// <summary>
        /// 绑定角色数据
        /// </summary>
        /// <param name="roleInfoDtos"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool AddRoleInfo(R_UserInfo_RoleInfoDtos roleInfoDtos, out string msg);
    }
}
