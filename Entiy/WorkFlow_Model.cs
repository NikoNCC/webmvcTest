using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    /// <summary>
    /// 工作流模板表
    /// </summary>
    public class WorkFlow_Model:DelEntity
    {   
        /// <summary>
        /// 标题
        /// </summary>
        [Column(TypeName="varchar(36)")]
        public string Title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "nvarchar(64)")]
        public string Description { get; set; }

    }
}
