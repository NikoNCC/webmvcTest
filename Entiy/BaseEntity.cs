using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    public class BaseEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }

    }
}
