using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.DCV
{
    public sealed class DataBaseContext: DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        

        public IEnumerable<IOnModelCreating> ModelCreatings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (ModelCreatings != null)
            {
                foreach (var item in ModelCreatings)
                {
                    item.OnModelCreating(builder);
                }
            }
        }
    }
}
