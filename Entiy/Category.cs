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
    /// 类型
    /// </summary>
    public class Category:BaseEntity
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string CategoryName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }
    }
}
