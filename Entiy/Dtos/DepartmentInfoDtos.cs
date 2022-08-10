using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy.Dtos
{
    public class DepartmentInfoDtos
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 部门描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary> 
        public string DepartmentName { get; set; }
        /// <summary>
        /// 主管ID
        /// </summary>
        public string LeaderId { get; set; }
        /// <summary>
        /// 主管名字
        /// </summary>
        public string LeaderName { get; set; }
        /// <summary>
        /// 父部门ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 父部门名字
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public string DeleteTime { get; set; }
    }
}
