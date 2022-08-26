using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy.Dtos
{

    /// <summary>
    /// 耗材工具类
    /// </summary>
    public class ConsumableInfoDtos
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
       /// <summary>
       /// 描述
       /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 耗材类型ID
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 耗材名称
        /// </summary>
        public string ConsumableName { get; set; }
        /// <summary>
        /// 耗材规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 耗材数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 单位  
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 耗材金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 警告库存
        /// </summary>
        public int WarningNum { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
