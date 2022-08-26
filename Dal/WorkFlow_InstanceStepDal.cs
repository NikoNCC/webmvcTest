using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class WorkFlow_InstanceStepDal:BaseDal<WorkFlow_InstanceStep>, IWorkFlow_InstanceStepDal
    {
        private readonly StorehouseSysDbContext _DbContext;
        public WorkFlow_InstanceStepDal(StorehouseSysDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
