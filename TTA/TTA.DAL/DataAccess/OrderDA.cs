using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TTA.Model;
using System.Configuration;

namespace TTA.DAL.DataAccess
{
    public class OrderDA
    {
        #region field
        private const string ColumnNameOrderId = "OrderId";
        private const string ColumnNameCreatedDate = "CreatedDate";
        private const string ColumnNameCustomerId = "CustomerId";
        private const string ColumnNameStatusId = "StatusId";

        private readonly string[] SearchCondition = { " = "," >= "," <= " };

        private const int initialData = -1;

        /// <summary>
        /// ConnectionString
        /// </summary>
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MyDataDB"].ConnectionString;

        /// <summary>
        /// Insert Script used in Insert method
        /// </summary>
        private readonly string InsertScript = string.Format(@"Insert into [Order] ({0},{1},{2}) values (@{0},@{1},@{2}) select SCOPE_IDENTITY()", ColumnNameCreatedDate, ColumnNameCustomerId, ColumnNameStatusId);

        /// <summary>
        /// Update Script used in Update method
        /// </summary>
        private readonly string UpdateScript = string.Format(@"Update [Order] set {0} = @{0},{1} = @{1}, {2} = @{2}  where {3} = @{3}", ColumnNameCreatedDate, ColumnNameCustomerId, ColumnNameStatusId, ColumnNameOrderId);

        /// <summary>
        /// Delete Method used in delete Method
        /// </summary>
        //private readonly string DeleteScript = string.Format("Delete from Order where {0} = @{0}",ColumnNameOrderId);
        private readonly string DeleteScript = string.Format(@"Update [Order] set {0} = 3 where {1} = @{1}", ColumnNameStatusId, ColumnNameOrderId);

        /// <summary>
        /// Select by order id script.
        /// </summary>
        private readonly string SelectByIdScript = string.Format(@"select * from [Order] where {0} = @{0}", ColumnNameOrderId);

        /// <summary>
        /// 
        /// </summary>
        private readonly string SelectByCustomerIdScript = string.Format(@"select * from [Order] where {0} = @{0}", ColumnNameCustomerId);
        /// <summary>
        /// add by will 2012-8-12 18:51:49
        /// </summary>
        private readonly string CloseScript = string.Format(@"Update [Order] set {0} = 2 where {1} = @{1}", ColumnNameStatusId, ColumnNameOrderId);

        

        #endregion

        
        #region private method
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns></returns>
        private SqlConnection CreateConnection() 
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Converts dataTable into OrderDE list.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        private List<OrderBE> ConvertToOrderDEList(DataTable table) 
        {
            List<OrderBE> orderList = new List<OrderBE>();
            foreach (DataRow row in table.Rows)
            {
                OrderBE order = new OrderBE()
                {
                    OrderId = Convert.ToInt32(row[ColumnNameOrderId]),
                    CreateTime = Convert.ToDateTime(row[ColumnNameCreatedDate]),
                };
                CustomerDA customerDA = new CustomerDA();
                order.Customer = customerDA.GetById(Convert.ToInt32(row[ColumnNameCustomerId])); //

                OrderStatusDA orderStatusDA = new OrderStatusDA();
                order.OrderStatus = orderStatusDA.GetById(Convert.ToInt32(row[ColumnNameStatusId]));

                orderList.Add(order);
            }
            return orderList;
        }

        #endregion

        #region public method

       

        /// <summary>
        /// Inserts the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        public OrderBE Insert( SqlConnection connection, OrderBE order)
        {
            if (order != null)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = InsertScript;

                command.Parameters.AddWithValue(ColumnNameCreatedDate, order.CreateTime);
                command.Parameters.AddWithValue(ColumnNameCustomerId, order.Customer.CustomerId);
                command.Parameters.AddWithValue(ColumnNameStatusId, order.OrderStatus.OrderStatusId);

                order.OrderId = Convert.ToInt32(command.ExecuteScalar());
            }
            return order;
        }

        /// <summary>
        /// Saves the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public OrderBE Insert(OrderBE order)
        {
            if (order != null)
            {
                SqlConnection connection = CreateConnection();
                order = this.Insert(connection, order);
                connection.Close();
            }
            return order;
        }

        /// <summary>
        /// Updates the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public bool Update(SqlConnection connection, OrderBE order ) 
        {
            
            int result = initialData;
            bool success = false;

            if (order != null)
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = UpdateScript;
                    command.Parameters.AddWithValue(ColumnNameCreatedDate, order.CreateTime);
                    command.Parameters.AddWithValue(ColumnNameCustomerId, order.Customer.CustomerId);
                    command.Parameters.AddWithValue(ColumnNameStatusId, order.OrderStatus.OrderStatusId);
                    command.Parameters.AddWithValue(ColumnNameOrderId, order.OrderId);

                    result = Convert.ToInt32(command.ExecuteScalar());
                    if (result != initialData) { success = true; }
                }
            }

            return success;
        }

        /// <summary>
        /// Updates the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public bool Update(OrderBE order) 
        {
            SqlConnection connection = CreateConnection();
            bool result = false;
            result = this.Update( connection,order);
            connection.Close();
            return result;
        }
        /// <summary>
        /// Close the specified order.
        /// </summary>
        /// <param name="connection">The order.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Close(SqlConnection connection, int id) //add by will 2012-8-12 18:50:10
        {
            int result = initialData;
            bool success = false;

            if (id > 0)
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = CloseScript;
                    command.Parameters.AddWithValue(ColumnNameOrderId, id);

                    result = Convert.ToInt32(command.ExecuteScalar());
                    if (result != initialData) { success = true; }
                }
            }

            return success;
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Delete(SqlConnection connection, int id ) 
        {
            int result = initialData;
            bool success = false;

            if (id > 0)
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = DeleteScript;
                    command.Parameters.AddWithValue(ColumnNameOrderId, id);

                    result = Convert.ToInt32(command.ExecuteScalar());
                    if (result != initialData) { success = true; }
                }
            }

            return success;
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public OrderBE GetById(int id, SqlConnection connection) 
        {
            List<OrderBE> orderList = new List<OrderBE>();
            OrderBE orderResult = new OrderBE();

            if (id > 0)
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = SelectByIdScript;
                    command.Parameters.AddWithValue(ColumnNameOrderId, id);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if(table!= null){ orderList = ConvertToOrderDEList(table);}
                    orderResult = orderList.First();
                }
            }
            return orderResult;
        }

        public OrderBE GetById(int id) 
        {
            SqlConnection connection = CreateConnection();
            OrderBE orderResult = new OrderBE();
            orderResult = this.GetById(id, connection);
            connection.Close();
            return orderResult;
        }

        /// <summary>
        /// Updates the in batch.
        /// </summary>
        /// <param name="orderList">The order list.</param>
        /// <returns></returns>
        public bool UpdateInBatch(SqlConnection connection, List<OrderBE> orderList)
        {
            bool failed = true;

            if (orderList != null)
            {
                foreach (OrderBE order in orderList) 
                {
                    failed = failed && Update(connection,order);
                }
            }
            return failed;
        }

        /// <summary>
        /// Gets the by condition.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="name">The name.</param>
        /// <param name="date">The date.</param>
        /// <param name="compare">The compare.</param>
        /// <returns></returns>
        public List<OrderBE> GetByCondition(SqlConnection connection, string name, DateTime date, string compare )  //?
        {
            //string selectScript = "select * from [Order] where CreatedDate @Compare @Date and OrderId in (select OrderId from Customer where CustomerName like @Name)";
            string selectScript = "select * from [Order] where CreatedDate " + compare + " @Date and CustomerId in (select CustomerId from Customer where CustomerName like @Name)";

            List<OrderBE> list = new List<OrderBE>();

            name = "%" + name + "%";

            if (name != null) 
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectScript;                
                //command.Parameters.AddWithValue("Compare", compare); //??
                command.Parameters.AddWithValue("Date", date);
                command.Parameters.AddWithValue("Name", name);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                list = ConvertToOrderDEList(table);
            }
            return list;
        }
        #endregion
    }
}
