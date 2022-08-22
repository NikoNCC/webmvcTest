using Entiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 耗材实体
    /// </summary>
    public class ConsumableInfo : DelEntity
    {
        /// <summary>
        /// 耗材名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        [Required]
        public string ConsumableName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }
        /// <summary>
        /// 耗材类型id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string CategoryId { get; set; }
        /// <summary>
        /// 耗材规格
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string Specification { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string Unit { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 警告库存
        /// </summary>
        public int WarningNum { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }


    }
}
