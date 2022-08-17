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
    public class DepartmentInfoBll : IDepartmentInfoBll
    {
        IUserInfoDal _userInfoDal;
        IDepartmentInfoDal _departmentInfoDal;
        public DepartmentInfoBll(IUserInfoDal userInfoDal, IDepartmentInfoDal DepartmentInfoDal)
        {
            _userInfoDal = userInfoDal;
            _departmentInfoDal = DepartmentInfoDal;
        }
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="departmentInfoDtos"></param>
        /// <returns></returns>
        public bool AddDepartment(DepartmentInfoDtos departmentInfoDtos)
        {

            DepartmentInfo departmentInfo = new DepartmentInfo()
            {
                CreateTime = DateTime.Now,
                DepartmentName = departmentInfoDtos.DepartmentName,
                Id = Guid.NewGuid().ToString(),
                LeaderId = departmentInfoDtos.LeaderId,
                ParentId = departmentInfoDtos.ParentId,
                Description = departmentInfoDtos.Description,
            };
            return _departmentInfoDal.AddEntity(departmentInfo);
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public bool DalDepartment(string[] iD)
        {
            return _departmentInfoDal.DalDepartment(iD);
        }
        /// <summary>
        /// 获取部门数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<DepartmentInfoDtos> GetDepartment()
        {
            var list = from a in _departmentInfoDal.GetEntity().Where(a => !a.IsDelete).OrderByDescending(a => a.CreateTime)
                       join b in _userInfoDal.GetEntity() on a.LeaderId equals b.Id
                       into aa2
                       from temp in aa2.DefaultIfEmpty()
                       join c in _departmentInfoDal.GetEntity().Where(c => !c.IsDelete)
                       on a.ParentId equals c.Id
                       into c2
                       from temp2 in c2.DefaultIfEmpty()
                       select new DepartmentInfoDtos
                       {
                           Id = a.Id,
                           LeaderId = a.LeaderId,
                           LeaderName = temp.UserName,
                           ParentId = a.ParentId,
                           ParentName = temp2.DepartmentName,
                           DepartmentName = a.DepartmentName,
                           IsDelete = a.IsDelete,
                           CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH-mm-ss"),
                           DeleteTime = a.DeleteTime.ToString("yyyy-MM-dd HH-mm-ss"),
                           Description = a.Description,
                       };
            return list;
        }
        /// <summary>
        /// 根据ID获取部门数据
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DepartmentInfoDtos GetDepartmentById(string iD)
        {
            DepartmentInfo department = _departmentInfoDal.FindEntity(iD);
            if (department != null)
             {
                DepartmentInfoDtos departmentInfoDtos = new DepartmentInfoDtos()
                { 
                    DepartmentName =department.DepartmentName,
                    Id = department.Id,
                    Description =department.Description,
                    LeaderId =department.ParentId,
                    ParentId =department.ParentId
                };
                return departmentInfoDtos;
            }
            return null;
            
        }
        /// <summary>
        /// 修改部门功能
        /// </summary>
        /// <param name="departmentInfoDtos"></param>
        /// <returns></returns>
        public bool UpdateDepartment(DepartmentInfoDtos departmentInfoDtos)
        {
            DepartmentInfo departmentInfo = new DepartmentInfo() {
                        DepartmentName = departmentInfoDtos.DepartmentName,
                        Description = departmentInfoDtos.Description,
                        LeaderId =departmentInfoDtos.LeaderId,
                        ParentId = departmentInfoDtos.ParentId,
                        Id = departmentInfoDtos.Id

            };
           return _departmentInfoDal.UpdateEntiry(departmentInfo);
        }
    }
}
