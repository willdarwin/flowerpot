using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TTA.DAL
{
    public class QueryParameter
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private DbType type;

        public DbType Type
        {
            get { return type; }
            set { type = value; }
        }

        public QueryParameter(string name, object value, DbType type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
        }
    }
}
