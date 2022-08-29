using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    /// <summary>
    /// 工作流实例表
    /// </summary>
    public class WorkFlow_Instance : BaseEntity
    {
        /// <summary>
        /// 工作流模板Id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ModelId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public WorkFlow_InstanceEnum Status { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(64)")]
        public string Description { get; set; }
        /// <summary>
        /// 申请理由
        /// </summary>
        [Column(TypeName = "nvarchar(64)")]
        public string Reason { get; set; }
        /// <summary>
        /// 申请理由时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Creator { get; set; }
        /// <summary>
        /// 出口数量
        /// </summary>
        public int OutNum { get; set; }
        /// <summary>
        /// 出库物资ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string OutGoodsId { get; set; }

    }
}
