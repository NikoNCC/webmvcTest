using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    /// <summary>
    /// 工作流步骤Dal
    /// </summary>
    public class WorkFlow_InstanceDal:BaseDal<WorkFlow_Instance>,IWorkFlow_InstanceDal
    {
        private readonly StorehouseSysDbContext _DbContext;
        public WorkFlow_InstanceDal(StorehouseSysDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
