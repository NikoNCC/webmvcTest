
using Entiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 耗材记录
    /// </summary>
    public class ConsumableRecord: BaseEntity
    {
        /// <summary>
        /// 耗材id
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ConsumableId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 类型 1:入库  2：出库
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人id
        /// </summary>
        public string Creator { get; set; }
    }
}
