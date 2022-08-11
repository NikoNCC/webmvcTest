using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiy
    
{
    /// <summary>
    /// 部门实体表
    /// </summary>
     
    public class DepartmentInfo : DelEntity
    {
          
        /// <summary>
        /// 部门描述
        /// </summary>
        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column(TypeName = "nvarchar(16)")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 主管ID
        /// </summary>
        [Column(TypeName = "nvarchar(36)")]
        public string LeaderId { get; set; }
        /// <summary>
        /// 父部门ID
        /// </summary>
        [Column(TypeName = "nvarchar(36)")]
        public string ParentId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
      

    }
}
