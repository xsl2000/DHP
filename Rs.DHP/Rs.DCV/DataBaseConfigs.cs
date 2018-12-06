using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Rs.DCV
{
    public class DataBaseConfigs : IDatabaseConfiguring
    {
        private readonly DatabaseOption _databaseOption;

        public DataBaseConfigs(DatabaseOption option)
        {
            this._databaseOption = option;
        }
        public void OnConfiguring(DbContextOptionsBuilder optionsBuilder, DbConnection dbConnectionForReusing)
        {
            switch (this._databaseOption.Dbtype)
            {
                case Dbtypes.MsSql:
                    if (dbConnectionForReusing != null)
                        optionsBuilder.UseSqlServer(dbConnectionForReusing);
                    else
                        optionsBuilder.UseSqlServer(this._databaseOption.ConnectionString);
                    break;
                case Dbtypes.MySql:
                    if (dbConnectionForReusing != null)
                        optionsBuilder.UseMySQL(dbConnectionForReusing);
                    else
                        optionsBuilder.UseMySQL(this._databaseOption.ConnectionString);
                    break;
                case Dbtypes.Oracle:
                    //if(dbConnectionForReusing!=null)
                    //    optionsBuilder.or
                    break;
                case Dbtypes.PgSql:
                    if (dbConnectionForReusing != null)
                        optionsBuilder.UseNpgsql(dbConnectionForReusing);
                    else
                        optionsBuilder.UseNpgsql(this._databaseOption.ConnectionString);
                    break;
                case Dbtypes.Mgdb:
                    break;
                default:
                    break;
            }
            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }
    }
}
