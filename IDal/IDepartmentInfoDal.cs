using Entiy;
using Entiy.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    public interface IDepartmentInfoDal
    {
        IQueryable<DepartmentInfoDtos>  GetDepartment();
        bool DalDepartment(string[] iD);
        DepartmentInfo GetDepartmentById(string iD);
        bool UpdateDepartment(DepartmentInfo departmentInfo);
        bool AddDepartment(DepartmentInfo departmentInfo);
    }
}
