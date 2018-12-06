using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rs.DCV
{
    /// <summary>
    /// 值域代码表名
    /// </summary>
    
    public sealed class TValueSetTable
    {
        /// <summary>
        /// 序号
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 码表对应的OID
        /// </summary>
        [Required]
        public string Oid { get; set; }
        /// <summary>
        /// 对应的码表名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 对应的代码
        /// </summary>
        public string Code { get; set; }
    }
    /// <summary>
    /// 值域代码表
    /// </summary>
    public sealed class TValueSet
    {
    }
}
