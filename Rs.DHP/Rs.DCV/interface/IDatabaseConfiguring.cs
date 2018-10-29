using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Rs.DCV
{
    public interface IDatabaseConfiguring
    {
        void OnConfiguring(DbContextOptionsBuilder optionsBuilder, DbConnection dbConnectionForReusing);
    }
}
