using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    /// <summary>
    /// 工作流步骤表
    /// </summary>
    public class WorkFlow_InstanceStep:BaseEntity
    {
        /// <summary>
        /// 工作流实例Id
        /// </summary>
        [Column(TypeName ="varchar(36)")]
        public string InstanceId { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ReviewerId { get; set; }
        /// <summary>
        /// 审核理由
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ReviewReason { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int ReviewStatus { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime ReviewTime { get; set; }
        /// <summary>
        /// 上一个步骤ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string BeforeStepId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
