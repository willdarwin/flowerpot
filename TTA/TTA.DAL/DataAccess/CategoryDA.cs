using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TTA.DAL.DataAccess
{
    public class CategoryDA
    {
        
        IDataAccess dataAcess = null;

        public CategoryDA()
        {
            dataAcess = DataAccessFactory.CreateDataAccess();
        }

        //public CategoryDE Insert(CategoryDE category)
        //{
        //    dataAcess.Open();
        //    dataAcess.BeginTran();
        //    QueryParameter[] list = new QueryParameter[2];
        //    list[0] = new QueryParameter("CategoryId", category.CategoryId, DbType.Int32);
        //    list[1] = new QueryParameter("CategoryName", category.CategoryName, DbType.String);
        //    string sql = "insert into Category values(@CategoryName)";
        //    dataAcess.ExecuteNonQuery(sql, list);
        //    dataAcess.CommitTran();
        //    dataAcess.Close();
        //    return category;
        //}

        //public bool Update(CategoryDE category)
        //{
        //    return true;
        //}

        //public bool Delete(int id)
        //{
        //    return true;
        //}

        public CategoryDE GetById(int id)
        {
            String connectstring = ConfigurationManager.ConnectionStrings["MyDataDB"].ConnectionString;
            List<CategoryDE> categoryList = new List<CategoryDE>();
            CategoryDE categoryResult = new CategoryDE();
            if (id >= 0)
            {
                SqlConnection connection = new SqlConnection(connectstring);
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "select * from Category where CategoryId = @id";

                command.Parameters.AddWithValue("id", id);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    CategoryDE category = new CategoryDE()
                    {
                        CategoryName = Convert.ToString(row["CategoryName"]),
                        CategoryId = Convert.ToInt32(row["CategoryId"])
                    };

                    categoryList.Add(category);
                    categoryResult = categoryList.First();
                }
                connection.Close();
            }
            return categoryResult;
        }

        public List<CategoryDE> selectAll()
        {
            String connectstring = ConfigurationManager.ConnectionStrings["MyDataDB"].ConnectionString;
            List<CategoryDE> categorylist = new List<CategoryDE>();
            CategoryDE categoryResult = new CategoryDE();

            SqlConnection connection = new SqlConnection(connectstring);
            connection.Open();
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "select * from Category";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                CategoryDE category = new CategoryDE()
                {
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    CategoryName = Convert.ToString(row["CategoryName"]),
                };
                categorylist.Add(category);
            }
            connection.Close();

            return categorylist;
        }

        /// <summary>
        /// According to user's inputs, concat the sql strings and return the sql.
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="oper"></param>
        /// <param name="orderDate"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public string GetSqlString(string customerName, string oper, string orderDate, string productName)
        {
            string sqlStr = "SELECT dbo.[Order].OrderId, dbo.[Order].CreatedDate, dbo.Customer.CustomerName, dbo.OrderDetails.TotalPrice,dbo.Product.ProductName ";
            sqlStr += "FROM dbo.[Order] INNER JOIN dbo.Customer ON dbo.[Order].CustomerId = dbo.Customer.CustomerId INNER JOIN dbo.OrderDetails ON dbo.[Order].OrderId = dbo.OrderDetails.OrderId INNER JOIN dbo.Product ON dbo.OrderDetails.ProductId = dbo.Product.ProductId where ";

            if (!string.IsNullOrEmpty(customerName))
            {
                sqlStr += "(dbo.Customer.CustomerName like '%" + customerName + "%') ";
            }
            if (!string.IsNullOrEmpty(oper) && !string.IsNullOrEmpty(orderDate))
            {
                if (!string.IsNullOrEmpty(customerName))
                    sqlStr += "and ";
                switch (oper)
                {
                    case ">":
                        sqlStr += "(dbo.[Order].CreatedDate > CONVERT(DATETIME,'" + orderDate + "', 102)) ";
                        break;
                    case "=":
                        sqlStr += "(dbo.[Order].CreatedDate = CONVERT(DATETIME,'" + orderDate + "', 102)) ";
                        break;
                    case "<":
                        sqlStr += "(dbo.[Order].CreatedDate < CONVERT(DATETIME,'" + orderDate + "', 102)) ";
                        break;
                    case ">=":
                        sqlStr += "(dbo.[Order].CreatedDate >= CONVERT(DATETIME,'" + orderDate + "', 102)) ";
                        break;
                    case "<=":
                        sqlStr += "(dbo.[Order].CreatedDate <= CONVERT(DATETIME,'" + orderDate + "', 102)) ";
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(productName))
            {
                if (!string.IsNullOrEmpty(customerName) || (!string.IsNullOrEmpty(oper) && !string.IsNullOrEmpty(orderDate)))
                    sqlStr += "and ";
                sqlStr += "dbo.OrderDetails.ProductId = dbo.Product.ProductId and (dbo.Product.ProductName like '%" + productName + "%')";
            }
            return sqlStr;
        }

        /// <summary>
        /// Execute sql query and return the result.
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public DataTable RetrieveByConditions(string sqlStr)
        {
            DataTable result = new DataTable();

            dataAcess.Open();
            result = dataAcess.ExecuteSql(sqlStr);
            dataAcess.Close();

            return result;
        }
    }
}
