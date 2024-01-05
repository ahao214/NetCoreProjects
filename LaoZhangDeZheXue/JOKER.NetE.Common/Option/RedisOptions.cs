﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOKER.NetE.Common.Option
{
    /// <summary>
    /// Redis缓存配置选项
    /// </summary>
    public class RedisOptions: IConfigurableOptions
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// Redis链接
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 键值前缀
        /// </summary>
        public string InstanceName { get; set; }

    }
}
