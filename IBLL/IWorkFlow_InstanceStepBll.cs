using Entiy;
using Entiy.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBLL
{
    /// <summary>
    /// 工作流步骤表bll接口
    /// </summary>
    public interface IWorkFlow_InstanceStepBll
    {
        WorkFlow_InstanceStepDtos GetWorkFlow_InstanceStepById(string id, out string msg);
        List<WorkFlow_InstanceStepDtos> GetWorkFlow_InstanceStepList(int page,  int limit, string userId, out int count);
        bool UpdateWorkFlow_InstanceStep(string id, string reviewReason, WorkFlow_InstanceStepStatusEnum status,int outNum, string userId ,out string msg);
    }
}
