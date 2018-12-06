using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.DCV
{
    /// <summary>
    /// 定义数据库类型
    /// </summary>
    public enum Dbtypes
    {
        /// <summary>
        /// MS Sql数据库
        /// </summary>
        MsSql=          1,
        /// <summary>
        /// My SQL数据库
        /// </summary>
        MySql=          2,
        /// <summary>
        /// Oracle数据库
        /// </summary>
        Oracle=         3,
        /// <summary>
        /// PostGre SQL数据库
        /// </summary>
        PgSql=          4,
        /// <summary>
        /// MongoDB数据库
        /// </summary>
        Mgdb=           5
    }
}
