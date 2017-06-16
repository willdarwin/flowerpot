using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTA.Model;


namespace TTA.DAL.DataAccess
{
    public class OrderDetailsDA
    {
        public IDataAccess dataAccess = null;
        public static decimal productPrice;


        /// <summary>
        /// get dataconnection
        /// </summary>
        public OrderDetailsDA()
        {
            dataAccess = DataAccessFactory.CreateDataAccess();
        }


        /// <summary>
        /// bind CustomerName to CustomerList
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerName()
        {
            //OrderDetailsDA OrderDetails = new OrderDetailsDA();
            dataAccess.Open();
            string sql = "select * from Customer";
            DataTable table = dataAccess.GetTable(sql);
            return table;
        }

        public DataTable EmptyTable()
        {
            dataAccess.Open();
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ProductName", typeof(string)));
            table.Columns.Add(new DataColumn("Quantity", typeof(int)));
            table.Columns.Add(new DataColumn("ProductPrice", typeof(decimal)));
            return table;
        }


        public DataTable NewEmptyRow(DataTable table)
        {
            dataAccess.Open();
            DataRow dr = table.NewRow();
            table.Rows.InsertAt(dr, 0);
            return table;
        }

        public DataTable GetProduct()
        {
            dataAccess.Open();
            string sql = "select * from Product";
            DataTable table = dataAccess.GetTable(sql);
            return table;
        }

        public decimal GetProductPrice(int id)
        {
            dataAccess.Open();
            //string sql = "select ProductPrice from Product where ProductId=" + id;
            //SqlCommand cmd = new SqlCommand(sql);
            //decimal productPrice = Convert.ToDecimal(cmd.ExecuteScalar().ToString()) ;
            decimal pp=0;
            string sql = "select ProductPrice from Product where ProductId='"+ id +"'";
            IDataReader reader = dataAccess.GetReader(sql);
            while (reader.Read())
            {
                pp = reader.GetDecimal(0);
            }
            return pp;
        }

        //public int GetProductId(string name)
        //{
        //    dataAccess.Open();
        //    string sql = "select ProductId from Product where ProductName=@ProductName";
        //    QueryParameter p = new QueryParameter("ProductName", name, DbType.String);
        //    int id=dataAccess.ExecuteScalar
        //    //string sql = "select ProductId from Product where Productname=" + id.ToString();
        //    //decimal productPrice = (decimal)dataAccess.ExecuteScalar(sql);
        //    return productPrice;
        //}


        public DataTable GetOrderDetails()
        {
            dataAccess.Open();
            string sql = "SELECT dbo.OrderDetails.OrderDetailId, dbo.OrderDetails.OrderId, dbo.Product.ProductName, dbo.OrderDetails.Quantity, dbo.OrderDetails.TotalPrice FROM dbo.OrderDetails INNER JOIN dbo.Product ON dbo.OrderDetails.ProductId = dbo.Product.ProductId";
            DataTable table = dataAccess.GetTable(sql);
            return table;
        }

        public DataTable GetOrderDetails(int oid)
        {
            dataAccess.Open();
            string sql = "SELECT dbo.OrderDetails.OrderDetailId, dbo.OrderDetails.OrderId, dbo.Product.ProductName, dbo.OrderDetails.Quantity, dbo.OrderDetails.TotalPrice FROM dbo.OrderDetails INNER JOIN dbo.Product ON dbo.OrderDetails.ProductId = dbo.Product.ProductId and OrderId='" + oid + "'";
            DataTable table = dataAccess.GetTable(sql);
            return table;
        }


        public List<OrderDetailsDE> GetAllOrderDetails()
        {
            List<OrderDetailsDE> list = new List<OrderDetailsDE>();
            dataAccess.Open();
            try
            {
                string sql = "select * from OrderDetails";
                IDataReader reader = dataAccess.GetReader(sql);
                while (reader.Read())
                {
                    OrderDetailsDE OrderDetails = new OrderDetailsDE();
                    OrderDetails.OrderDetailsId = reader.GetInt32(0);
                    OrderDetails.OrderId = reader.GetInt32(1);
                    //Product.ProductId = OrderDetails.ProductDE.ProductId;
                    //OrderDetails.ProductDE.ProductName = reader.GetString(2);
                    OrderDetails.Quantity = reader.GetInt32(3);
                    OrderDetails.TotalPrice = reader.GetDecimal(4);
                    int productId = reader.GetInt32(2);
                    //OrderDetails.ProductDE.ProductId = reader.GetInt32(2);
                    //string sql1 = "select ProductName from Product where ProductId=" + productId;
                    //dataAccess.Open();
                    //SqlCommand cmd = new SqlCommand(sql1);
                    ProductDE product = GetById(productId);

                    //product.ProductName = cmd.ExecuteScalar().ToString();
                    //ProductDE Product = GetById(productId);
                    OrderDetails.ProductDE = product;
                    list.Add(OrderDetails);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataAccess.Close();
            }
            return list;
        }


        public ProductDE GetById(int id)
        {
            ProductDE Product = new ProductDE();
            dataAccess.Open();
            try
            {

                string sql = "select ProductName from Product where ProductId=" + id;
                SqlCommand cmd = new SqlCommand(sql);
                Product.ProductName = cmd.ExecuteScalar().ToString();
                //string sql = "select ProductName from Product where ProductId=@ProductId";
                //QueryParameter p = new QueryParameter("ProductId", id, DbType.Int32);
                //Product.ProductName = dataAccess.ExecuteScalar(sql, p).ToString();
                //IDataReader reader = dataAccess.GetReader(sql, p);
                //while (reader.Read())
                //{
                //    Product.ProductId = id;
                //    Product.ProductName = reader.GetString(1);

                //}
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                dataAccess.Close();
            }
            return Product;

        }

        public int GetOrderId()
        {
            dataAccess.Open();
            int i=0;
            try
            {
                string sql = "select max(OrderID) from dbo.[Order]";
                IDataReader reader = dataAccess.GetReader(sql);
                while (reader.Read())
                {
                    i = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                dataAccess.Close();
            }
            return i;

        }


        public OrderBE Insert(OrderBE Order)
        {
            dataAccess.Open();
            dataAccess.BeginTran();
            try
            {
                QueryParameter[] list = new QueryParameter[4];
                list[0] = new QueryParameter("OrderId", Order.OrderId, DbType.Int32);
                list[1] = new QueryParameter("CreateTime", Order.CreateTime, DbType.DateTime);
                list[2] = new QueryParameter("CustomerId", Order.CustomerId, DbType.Int32);
                list[3] = new QueryParameter("OrderStatusId", Order.OrderStatusId, DbType.Int32);
                string sql = "insert into dbo.[Order] values(@CreateTime,@CustomerId,@OrderStatusId)";
                dataAccess.ExecuteNonQuery(sql, list);    
                dataAccess.CommitTran();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataAccess.Close();
            }
            return Order;
        }

        public DataTable Insert(OrderDetailsDE OrderDetails)
        {
            dataAccess.Open();
            dataAccess.BeginTran();
            DataTable table;
            try
            {
                QueryParameter[] list = new QueryParameter[5];
                list[0] = new QueryParameter("OrderDetailsId", OrderDetails.OrderDetailsId, DbType.Int32);
                list[1] = new QueryParameter("OrderId", OrderDetails.OrderId, DbType.Int32);
                list[2] = new QueryParameter("ProductId", OrderDetails.ProductId, DbType.Int32);
                list[3] = new QueryParameter("Quantity", OrderDetails.Quantity, DbType.Int32);
                list[4] = new QueryParameter("TotalPrice", OrderDetails.TotalPrice, DbType.Decimal);
                string sql = "insert into OrderDetails values(@OrderId,@ProductId,@Quantity,@TotalPrice)";
                dataAccess.ExecuteNonQuery(sql, list);
                dataAccess.CommitTran();
                string sql1 = "SELECT dbo.OrderDetails.OrderDetailId, dbo.OrderDetails.OrderId, dbo.Product.ProductName, dbo.OrderDetails.Quantity, dbo.OrderDetails.TotalPrice FROM dbo.OrderDetails INNER JOIN dbo.Product ON dbo.OrderDetails.ProductId = dbo.Product.ProductId and OrderId='" + OrderDetails.OrderId + "'";
                table = dataAccess.GetTable(sql1);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataAccess.Close();
            }
            return table;
        }

        public bool Update(OrderDetailsDE OrderDetails)
        {
            bool result = true;
            dataAccess.Open();
            try
            {
                QueryParameter[] list = new QueryParameter[5];
                list[0] = new QueryParameter("OrderDetailId", OrderDetails.OrderDetailsId, DbType.Int32);
                list[1] = new QueryParameter("OrderId", OrderDetails.OrderId, DbType.Int32);
                list[2] = new QueryParameter("ProductId", OrderDetails.ProductId, DbType.Int32);
                list[3] = new QueryParameter("Quantity", OrderDetails.Quantity, DbType.Int32);
                list[4] = new QueryParameter("TotalPrice", OrderDetails.TotalPrice, DbType.Decimal);
                string sql = "update OrderDetails set ProductId=@ProductId, Quantity=@Quantity, TotalPrice=@TotalPrice where OrderId=@OrderId and OrderDetailId=@OrderDetailId";
                int i = dataAccess.ExecuteNonQuery(sql, list);
                if (i == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataAccess.Close();
            }
            return result;
        }

        public bool Update(int id)
        {
            bool result = true;
            dataAccess.Open();
            try
            {
                string sql = "update from OrderDetails where OrderDetailId=@OrderDetailId";
                QueryParameter p = new QueryParameter("OrderDetailId", id, DbType.UInt32);
                int i = dataAccess.ExecuteNonQuery(sql, p);
                if (i == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataAccess.Close();
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = true;
            dataAccess.Open();
            try
            {
                string sql = "delete from OrderDetails where OrderDetailId=@OrderDetailId";
                QueryParameter p = new QueryParameter("OrderDetailId", id, DbType.UInt32);
                int i = dataAccess.ExecuteNonQuery(sql, p);
                if (i == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataAccess.Close();
            }
            return result;
        }
    }
}
