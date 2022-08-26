using Entiy.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// 工作实力表BLL
    /// </summary>
    public interface IWorkFlow_InstanceBll
    {

        object AddWorkFlow_InstanceOptins();

        public List<WorkFlow_InstanceDtos> GetWorkFlow_Instance(int page, int limit, out int count);
    }
}
