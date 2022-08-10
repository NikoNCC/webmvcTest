using Entiy;
using Entiy.Dtos;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class DepartmentInfoDal : IDepartmentInfoDal
    {
        private StorehouseSysDbContext _db;

        public DepartmentInfoDal(StorehouseSysDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public bool AddDepartment(DepartmentInfo departmentInfo)
        {
            
            _db.DepartmentInfo.Add(departmentInfo);
            return _db.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DalDepartment(string[] iD)
        {
           List<DepartmentInfo> departments = new List<DepartmentInfo>();
            foreach (string i in iD)
            {
                DepartmentInfo departmentInfos = _db.DepartmentInfo.FirstOrDefault(a =>a.Id ==i);
                departmentInfos.IsDelete = true;
                departments.Add(departmentInfos);
            }
            _db.UpdateRange(departments);
            return _db.SaveChanges() > 0;
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<DepartmentInfoDtos> GetDepartment()
        {
            IQueryable<DepartmentInfoDtos> departmentInfoDtos = from a in _db.DepartmentInfo.Where(a => !a.IsDelete).OrderByDescending(a => a.CreateTime)
                                                                join b in _db.UserInfo on a.LeaderId equals b.Id
                                                                into aa2 from temp in aa2.DefaultIfEmpty()
                                                                join c in _db.DepartmentInfo.Where(c => !c.IsDelete)
                                                                on a.ParentId equals c.Id
                                                                into c2 from temp2 in c2.DefaultIfEmpty()
                                                                select new DepartmentInfoDtos
                                                                {
                                                Id = a.Id,
                                                LeaderId = a.LeaderId,
                                                LeaderName = temp.UserName,
                                                ParentId = a.ParentId,
                                                ParentName =temp2.DepartmentName,
                                                DepartmentName = a.DepartmentName,
                                                IsDelete = a.IsDelete,
                                                CreateTime = a.CreateTime.ToString("yyyy-MM-dd HH-mm-ss"),
                                                DeleteTime = a.DeleteTime.ToString("yyyy-MM-dd HH-mm-ss"),
                                                Description = a.Description,
         };
            return departmentInfoDtos;
        }

        /// <summary>
        /// 根据ID获取用户数据
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DepartmentInfo GetDepartmentById(string iD)
        {

            DepartmentInfo departmentInfos = _db.DepartmentInfo.FirstOrDefault(a => a.Id == iD);
            if (departmentInfos != null)
            {
                return departmentInfos;
            }
           return null;
        }
        /// <summary>
        /// 修改部门信息表
        /// </summary>
        /// <param name="departmentInfo"></param>
        /// <returns></returns>
        public bool UpdateDepartment(DepartmentInfo departmentInfo)
        {

            _db.DepartmentInfo.Update(departmentInfo);
            return _db.SaveChanges() > 0;
        }
    }
}
