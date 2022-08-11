using Entiy;
using Entiy.Dtos;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class RoleInfoDal : IRoleInfoDal
    {
        private StorehouseSysDbContext _db;

        public RoleInfoDal(StorehouseSysDbContext db)
        {
            _db = db;
        }






        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="RoleInfo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddRoleInfo(RoleInfo roleInfo)
        {
            _db.RoleInfo.Add(roleInfo);
            return _db.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除角色数据
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DalRoleInfo(List<RoleInfo> roleInfos)
        {
            _db.RoleInfo.UpdateRange(roleInfos);
            return _db.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<RoleInfo> GetRoleInfo()
        {
            return _db.RoleInfo;
        }

        /// <summary>
        ///  根据ID查询角色数据
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public RoleInfo GetRoleInfoById(string iD)
        {
            RoleInfo RoleInfo = _db.RoleInfo.Where(a => a.Id == iD &&!a.IsDelete).FirstOrDefault();
            return RoleInfo;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(RoleInfo roleInfo)
        {
            _db.RoleInfo.Update(roleInfo);
            return _db.SaveChanges() > 0;
        }
    }
}
