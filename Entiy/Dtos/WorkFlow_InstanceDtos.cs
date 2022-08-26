using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy.Dtos
{
    /// <summary>
    /// 工作实例表Dtoss
    /// </summary>
    public class WorkFlow_InstanceDtos
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 模板ID
        /// </summary>
        public string ModelId { get; set; }
        /// <summary>
        /// 模板标题
        /// </summary>
       public string  Title { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public WorkFlow_InstanceEnum Status { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 申请理由
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 添加入ID
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 添加人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        public int OutNum { get; set; }
        /// <summary>
        /// 出库物资Id
        /// </summary>
        public string OutGoodsId { get; set; }

        /// <summary>
        /// 耗材名称
        /// </summary>
        public string ConsumableName { get; set; }

    }
}
