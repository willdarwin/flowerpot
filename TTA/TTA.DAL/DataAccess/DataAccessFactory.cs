using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TTA.DAL.DataAccess
{
    public class DataAccessFactory
    {
        public static IDataAccess CreateDataAccess()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            string databaseType = ConfigurationManager.ConnectionStrings["databaseType"].ToString();
            switch (databaseType)
            {
                case "MSSQLSERVER": return new SQLServerDataAccess(connectionString);
                default: throw new Exception("不支持的数据库类型");
            }
        }
    }
}
