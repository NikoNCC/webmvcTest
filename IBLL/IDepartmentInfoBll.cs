using Entiy;
using Entiy.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBLL
{
    public interface IDepartmentInfoBll
    {
        IQueryable<DepartmentInfoDtos> GetDepartment();
        bool DalDepartment(string[] iD);
        DepartmentInfoDtos GetDepartmentById(string iD);
        bool UpdateDepartment(DepartmentInfoDtos departmentInfoDtos);
        bool AddDepartment(DepartmentInfoDtos departmentInfoDtos);
    }
}
