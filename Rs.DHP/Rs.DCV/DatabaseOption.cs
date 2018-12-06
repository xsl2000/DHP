using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.DCV
{
    public class DatabaseOption
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public Dbtypes Dbtype { get; set; } = Dbtypes.MsSql;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
