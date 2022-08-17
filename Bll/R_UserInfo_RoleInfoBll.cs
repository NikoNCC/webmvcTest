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
        /// <summary>
        /// Dal
        /// </summary>
        /// <param name="r_UserInfo_RoleInfoDal"></param>
        public R_UserInfo_RoleInfoBll(IR_UserInfo_RoleInfoDal r_UserInfo_RoleInfoDal)
        {
            _R_UserInfo_RoleInfoDal = r_UserInfo_RoleInfoDal;
        }






        public bool AddRoleInfo(R_UserInfo_RoleInfoDtos roleInfoDtos, out string msg)
        {
            throw new NotImplementedException();
        }

        public IQueryable<R_UserInfo_RoleInfoDtos> GetRoleInfo()
        {
            throw new NotImplementedException();
        }
        public IQueryable<UserInfoDtos> GetUser()
        {
            _R_UserInfo_RoleInfoDal.GetEntity();
            return null;
        }
    }
}
