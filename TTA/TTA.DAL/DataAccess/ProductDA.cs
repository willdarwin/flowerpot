using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using TTA.Model;

namespace TTA.DAL.DataAccess
{
    public class ProductDA
    {
        /// <summary>
        /// connection string
        /// </summary>
        private String connectstring = ConfigurationManager.ConnectionStrings["MyDataDB"].ConnectionString;

        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        public List<ProductDE> selectAll()
        {
            List<ProductDE> productList = new List<ProductDE>();
            ProductDE productResult = new ProductDE();

            SqlConnection connection = new SqlConnection(connectstring);
            connection.Open();
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "select * from Product";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                ProductDE product = new ProductDE()
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = Convert.ToString(row["ProductName"]),
                    ProductPrice = Convert.ToDecimal(row["ProductPrice"]),
                    CategoryId = Convert.ToInt32(row["CategoryId"])
                };
                CategoryDA categoryDA = new CategoryDA();
                product.Category = categoryDA.GetById(Convert.ToInt32(row["CategoryId"]));
                productList.Add(product);
            }
            connection.Close();

            return productList;
        }

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public ProductDE GetById(int productid)
        {
            List<ProductDE> productList = new List<ProductDE>();
            ProductDE productResult = new ProductDE();
            if (productid >= 0)
            {
                SqlConnection connection = new SqlConnection(connectstring);
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select * from Product where ProductId = @ProductId";

                    command.Parameters.AddWithValue("ProductId", productid);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        ProductDE product = new ProductDE()
                        {
                            ProductId = Convert.ToInt32(row["ProductId"]),
                            ProductName = Convert.ToString(row["ProductName"]),
                            ProductPrice = Convert.ToDecimal(row["ProductPrice"]),
                            CategoryId = Convert.ToInt32(row["CategoryId"])
                        };
                        CategoryDA categoryDA = new CategoryDA();
                        product.Category = categoryDA.GetById(Convert.ToInt32(row["CategoryId"]));

                        productList.Add(product);
                        productResult = productList.First();
                    }
                }
            }
            return productResult;
        }

        /// <summary>
        /// insert a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductDE Insert(ProductDE product)
        {
            if (product != null)
            {
                SqlConnection connection = new SqlConnection(connectstring);
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Product(ProductName,ProductPrice,CategoryId) values (@ProductName,@ProductPrice,@CategoryId) select SCOPE_IDENTITY()";

                    command.Parameters.AddWithValue("ProductName", product.ProductName);
                    command.Parameters.AddWithValue("ProductPrice", product.ProductPrice);
                    command.Parameters.AddWithValue("CategoryId", product.Category.CategoryId);

                    product.ProductId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return product;
        }

        /// <summary>
        /// update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Update(ProductDE product)
        {
            int result = -1;
            bool success = false;
            if (product != null)
            {
                SqlConnection connection = new SqlConnection(connectstring);
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "update Product set ProductName=@ProductName,ProductPrice=@ProductPrice,CategoryId=@CategoryId where ProductId=@ProductId";

                    command.Parameters.AddWithValue("ProductId", product.ProductId);
                    command.Parameters.AddWithValue("ProductName", product.ProductName);
                    command.Parameters.AddWithValue("ProductPrice", product.ProductPrice);
                    command.Parameters.AddWithValue("CategoryId", product.CategoryId);

                    result = Convert.ToInt32(command.ExecuteScalar());
                    if (result != -1)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// delete a product by id
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public bool Delete(int productid)
        {
            int result = -1;
            bool success = false;
            if (productid >= 0)
            {
                SqlConnection connection = new SqlConnection(connectstring);
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Product where ProductId=@ProductId";

                    command.Parameters.AddWithValue("ProductId", productid);
                    result = Convert.ToInt32(command.ExecuteScalar());
                    if (result != -1)
                    {
                        success = true;
                    }
                    connection.Close();
                }
            }
            return success;
        }


    }

}