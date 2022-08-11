using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    public class EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }
    }
}
