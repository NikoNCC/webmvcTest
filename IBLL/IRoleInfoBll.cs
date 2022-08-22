using Entiy;
using Entiy.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// 角色管理Bll接口
    /// </summary>
    public interface IRoleInfoBll
    {
        IQueryable<RoleInfoDtos> GetRoleInfo();
        bool DalRoleInfo(string[] iD, out string msg);
        RoleInfo GetRoleInfoById(string iD);
        bool UpdateRoleInfo(RoleInfoDtos roleInfoDtos, out string msg);
        bool AddRoleInfo(RoleInfoDtos roleInfoDtos, out string msg);
    }
}
