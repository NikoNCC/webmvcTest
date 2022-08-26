using Entiy;
using IDal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class WorkFlow_ModelDal:BaseDeleteDal<WorkFlow_Model>, IWorkFlow_ModelDal
    {
        private StorehouseSysDbContext _db;

        public WorkFlow_ModelDal(StorehouseSysDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
