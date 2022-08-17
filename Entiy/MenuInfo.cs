using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy
{
    public class MenuInfo : DelEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string Description { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [Column(TypeName = "varchar(128)")]
        public string Href { get; set; }
        /// <summary>
        /// 父菜单ID
        /// </summary>
        [Column(TypeName = "varchar(36)")]
        public string ParentId { get; set; }
        /// <summary>
        /// 图标样式
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string Icon { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        [Column(TypeName = "varchar(32)")]
        public string Target { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
