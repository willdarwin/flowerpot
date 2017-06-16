using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TTA.DAL.DataAccess
{
    public class OrderStatusDA
    {
        private const string ColumnNameStatusID = "StatusId";
        private readonly string selectScript = string.Format("select * from [OrderStatus] where {0} = @{0}", ColumnNameStatusID);
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MyDataDB"].ConnectionString;

        public OrderStatusBE GetById(int id) 
        {
            OrderStatusBE orderStatus = new OrderStatusBE();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = selectScript;
            command.Parameters.AddWithValue(ColumnNameStatusID, id);

            DataTable table = new DataTable();
            List<OrderStatusBE> statusList = new List<OrderStatusBE>();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            foreach(DataRow row in table.Rows) 
            {
                OrderStatusBE status = new OrderStatusBE()
                {
                    OrderStatusId = Convert.ToInt32(row[0]),
                    StatusName = row[1].ToString(),
                };
                statusList.Add(status);
            }

            if (statusList != null) { orderStatus = statusList.First(); }

            connection.Close();

            return orderStatus;
        }
    }
}
