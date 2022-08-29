using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy.Dtos
{
    /// <summary>
    /// 工作流步骤Dtos
    /// </summary>
    public class WorkFlow_InstanceStepDtos
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 工作流实例Id
        /// </summary>
        
        public string InstanceId { get; set; }

        /// <summary>
        /// 审核人ID
        /// </summary>
    
        public string ReviewerId { get; set; }

        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string ReviewerName { get; set; }

        /// <summary>
        /// 审核理由
        /// </summary>
        public string ReviewReason { get; set; }

        /// <summary>
        /// 申请数量
        /// </summary>
        public int OutNum { get; set; }

        /// <summary>
        /// 申请耗材
        /// </summary>
        public string ConsumableName { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public string ReviewStatus { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public string ReviewTime { get; set; }

        /// <summary>
        /// 上一个步骤ID
        /// </summary>
        public string BeforeStepId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 模板标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加入ID
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 添加人姓名
        /// </summary>
        public string CreatorName { get; set; }
        /// <summary>
        /// 申请理由
        /// </summary>
        public string Reason { get; set; }
    }
}
