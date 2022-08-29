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
        /// <summary>
        /// 
        /// </summary>
        /// <param 模板="modelId"></param>
        /// <param 描述="description"></param>
        /// <param 出库数量="outNum"></param>
        /// <param 耗材ID="consumableId"></param>
        /// <param 申请理由="reason"></param>
        /// <param 当前登录人ID="userId"></param>
        /// <returns></returns>
        bool AddWorkFlow_Instance(string modelId, string description, int outNum, string consumableId, string reason, string userId,out string msg);
       /// <summary>
       /// 下拉框
       /// </summary>
       /// <returns></returns>
        object AddWorkFlow_InstanceOptins();
        /// <summary>
        /// 展示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<WorkFlow_InstanceDtos> GetWorkFlow_Instance(int page, int limit, out int count);
    }
}
