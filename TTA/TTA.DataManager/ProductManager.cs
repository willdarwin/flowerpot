using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DataEntity;
using System.Data.Entity;
using TTA.Model;

namespace TTA.DataManager
{
    public class ProductManager
    {
        #region property
        public TTAEntityContainer DBEntity { get; set; }
        #endregion
        #region public method
        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> GetAllProducts()
        {
            this.DBEntity = new TTAEntityContainer();
            ProductTranslator productTranslator = new ProductTranslator();

            List<Product> list = (from Product Product in DBEntity.Products select Product).ToList<Product>();
            List<ProductBE> listProductBE = new List<ProductBE>();
            foreach (Product productDE in list)
            {

                ProductBE productBE = productTranslator.Translate(productDE);
                listProductBE.Add(productBE);
            }
            return listProductBE;
        }
        /// <summary>
        /// Insert a product
        /// </summary>
        /// <param name="dbEntity">The db entity.</param>
        /// <param name="Product">The product.</param>
        public bool Insert(TTAEntityContainer dbEntity, ProductBE Product)
        {
            ProductTranslator productTranslator = new ProductTranslator();
            Product productDE = productTranslator.Translate(Product);
            dbEntity.AddToProducts(productDE);
            dbEntity.SaveChanges();
            return true;
        }
        /// <summary>
        /// overload insert
        /// </summary>
        /// <param name="Product">The product.</param>
        public bool Insert(ProductBE Product)
        {
            this.DBEntity = new TTAEntityContainer();

            return this.Insert(this.DBEntity, Product);
        }
        /// <summary>
        /// delete a product by productid
        /// </summary>
        /// <param name="dbEntity">The db entity.</param>
        /// <param name="id">The id.</param>
        public bool Delete(TTAEntityContainer dbEntity, int id)
        {
            Product product = (from Product p in dbEntity.Products where p.ProductId == id select p).SingleOrDefault<Product>();
            dbEntity.Products.DeleteObject(product);
            dbEntity.SaveChanges();
            return true;
        }
        /// <summary>
        /// overload Delete
        /// </summary>
        /// <param name="id">The id.</param>
        public bool Delete(int id)
        {
            this.DBEntity = new TTAEntityContainer();
            return this.Delete(this.DBEntity, id);
        }
        /// <summary>
        /// update product
        /// </summary>
        /// <param name="dbEntity">The db entity.</param>
        /// <param name="pro">The pro.</param>
        public bool Update(TTAEntityContainer dbEntity, ProductBE pro)
        {
            ProductTranslator productTranslator = new ProductTranslator();
            Product productDE = productTranslator.Translate(pro);

            Product product = (from Product p in dbEntity.Products where p.ProductId == productDE.ProductId select p).SingleOrDefault<Product>();

            product.ProductName = productDE.ProductName;
            product.ProductPrice = productDE.ProductPrice;
            product.CategoryId = productDE.CategoryId;

            dbEntity.SaveChanges();
            return true;
        }
        /// <summary>
        /// overload update
        /// </summary>
        /// <param name="pro">The pro.</param>
        public bool Update(ProductBE pro)
        {
            this.DBEntity = new TTAEntityContainer();
            return this.Update(this.DBEntity, pro);
        }
        /// <summary>
        /// get product by productid
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetById(int id)
        {
            this.DBEntity = new TTAEntityContainer();
            ProductTranslator productTranslator = new ProductTranslator();

            Product product = (from Product p in DBEntity.Products where p.ProductId == id select p).SingleOrDefault<Product>();
            return productTranslator.Translate(product);

        }
        /// <summary>
        /// Gets the order details by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public int CountOrderDetailsByProductId(int id)
        {
            this.DBEntity = new TTAEntityContainer();

            int orderDetailsNum = (from OrderDetails p in DBEntity.OrderDetails where p.ProductId == id select p).Count();
            return orderDetailsNum;

        }
        #endregion
    }
}
