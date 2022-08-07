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
        IDepartmentInfoDal _departmentInfoDal;

        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal)
        {
            _departmentInfoDal = departmentInfoDal;
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
            return _departmentInfoDal.AddDepartment(departmentInfo);
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
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public List<DepartmentInfoDtos> GetDepartment()
        {
            return _departmentInfoDal.GetDepartment().ToList(); 
        }
        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DepartmentInfoDtos GetDepartmentById(string iD)
        {
            DepartmentInfo department = _departmentInfoDal.GetDepartmentById(iD);
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
        /// 修改功能
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
           return _departmentInfoDal.UpdateDepartment(departmentInfo);
        }
    }
}
