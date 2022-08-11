﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy
{
    /// <summary>
    /// 含有删除字段实体类
    /// </summary>
    public class DelEntity:EntityBase
    {
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
