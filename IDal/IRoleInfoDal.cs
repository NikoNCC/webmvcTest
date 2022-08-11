using Entiy;
using Entiy.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    public interface IRoleInfoDal
    {
        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        IQueryable<RoleInfo> GetRoleInfo();
        
        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        bool DalRoleInfo(List<RoleInfo> roleInfos);
        /// <summary>
        /// 根据ID查找角色名
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        RoleInfo GetRoleInfoById(string iD);
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        bool UpdateRoleInfo(RoleInfo roleInfo);
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        bool AddRoleInfo(RoleInfo roleInfo);
    }
}
