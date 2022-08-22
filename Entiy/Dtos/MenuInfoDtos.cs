using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entiy.Dtos
{
    /// <summary>
    /// 菜单Dto类
    /// </summary>
    public class MenuInfoDtos
    {
        /// <summary>
        /// 主键ID
        /// </summary>
      
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
       
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
   
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
     
        public string Href { get; set; }
        /// <summary>
        /// 父菜单ID
        /// </summary>
    
        public string ParentId { get; set; }
        /// <summary>
        /// 图标样式
        /// </summary>
  
        public string Icon { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
      
        public string Target { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
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
