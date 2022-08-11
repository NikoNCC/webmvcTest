using Entiy;
using Entiy.Dtos;
using IBLL;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class RoleInfoBll : IRoleInfoBll
    {
        IRoleInfoDal _IRoleInfoDal;
        public RoleInfoBll(IRoleInfoDal iRoleInfoDal)
        {
            _IRoleInfoDal = iRoleInfoDal;
        }

    

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool DalRoleInfo(string[] iD,out string msg)
        {
            msg = null;
            List<RoleInfo> listRoleInfo = new List<RoleInfo>();
            ///查询数据是否存在 
            foreach (var i in iD)
            {
                RoleInfo RoleInfo = _IRoleInfoDal.GetRoleInfoById(i);
                
                if (RoleInfo == null)
                {
                    msg = "选中的用户不存在";
                    return false;
                }
                RoleInfo.IsDelete = true;
                RoleInfo.DeleteTime = DateTime.Now;
                listRoleInfo.Add(RoleInfo);
            }
            //进行软删除
            bool res = _IRoleInfoDal.DalRoleInfo(listRoleInfo);
            if (res)
            {
                msg = "删除成功";
                return true;
            }
            else
            {
                msg = "删除失败";
                return false;
            }

        }

        /// <summary>
        /// 获取角色表
        /// </summary>
        /// <returns></returns>
        public IQueryable<RoleInfoDtos> GetRoleInfo()
        {   //将角色表数据放入实体类
            IQueryable<RoleInfoDtos> roleInfoDtos = _IRoleInfoDal.GetRoleInfo().Where(a=> !a.IsDelete).Select(a=> new RoleInfoDtos { 
            
                CreateTime =a.CreateTime.ToString("yyyy--MM-dd HH"),
                DeleteTime =a.DeleteTime.ToString("yyyy--MM-dd HH"),
                Id = a.Id,
                Description = a.Description,
                RoleName=a.RoleName,
            });
            
            return roleInfoDtos;
        }


        /// <summary>
        /// 根据ID获取角色数据
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public RoleInfo GetRoleInfoById(string iD)
        {
            RoleInfo roleInfo = _IRoleInfoDal.GetRoleInfoById(iD);
            return roleInfo;
        }
        /// <summary>
        /// 添加用户数据
        /// </summary>
        /// <param name="RoleInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddRoleInfo(RoleInfoDtos roleInfoDtos, out string msg)
        {

            //将数据打包
            RoleInfo roleInfo = new RoleInfo() {

                RoleName = roleInfoDtos.RoleName,
                Id = Guid.NewGuid().ToString(),
                Description =roleInfoDtos.Description,
                CreateTime = DateTime.Now,
            };
            //数据给予Dal层
              bool res = _IRoleInfoDal.AddRoleInfo(roleInfo);
            if (res)
            {
                msg = "添加成功";
                return res;
            }
                msg = "添加失败";
                return res;

        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="RoleInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateRoleInfo(RoleInfoDtos roleInfoDtos, out string msg)
        {
            RoleInfo roleInfo = _IRoleInfoDal.GetRoleInfoById(roleInfoDtos.Id);
            if (roleInfo != null)
            {
                roleInfo.Description=roleInfoDtos.Description;
                roleInfoDtos.RoleName = roleInfoDtos.RoleName;
            }
            bool res = _IRoleInfoDal.UpdateRoleInfo(roleInfo);
            if(res)
            {
                msg = "修改成功";
                return res;
            }
            msg = "修改失败";
            return res;
        }
    }
    
}
