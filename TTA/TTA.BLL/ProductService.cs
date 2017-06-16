using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TTA.Model;
using TTA.DataManager;
using TTA.DataEntity;
using System.Data.Entity;

namespace TTA.BLL
{
    public class ProductService
    {
        #region public method
        /// <summary>
        /// get a product by productid
        /// </summary>
        /// <param name="productid">The productid.</param>
        /// <returns></returns>
        public ProductBE GetById(int productid)
        {
            ProductManager _productManager = new ProductManager();
            ProductBE productBE = _productManager.GetById(productid);
            return productBE;
        }
        /// <summary>
        /// insert a new product
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        public bool Insert(ProductBE productBE)
        {
            ProductManager _productManager = new ProductManager();
            return _productManager.Insert(productBE);
        }
        /// <summary>
        /// update a product
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        public bool Update(ProductBE productBE)
        {
            ProductManager _productManager = new ProductManager();
            return _productManager.Update(productBE);
        }
        /// <summary>
        /// delete a product by productid
        /// </summary>
        /// <param name="productid">The productid.</param>
        public bool Delete(int productid)
        {
            ProductManager _productManager = new ProductManager();
            return _productManager.Delete(productid);
        }
        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAll()
        {
            ProductManager _productManager = new ProductManager();
            List<ProductBE> listProductBE = _productManager.GetAllProducts();
            return listProductBE;
        }
        /// <summary>
        /// get all category
        /// </summary>
        /// <returns></returns>
        public List<CategoryBE> SelectAllCategory()
        {
            CategoryManager _categoryManager = new CategoryManager();
            List<CategoryBE> listCategoryBE = _categoryManager.GetAllCategories();
            return listCategoryBE;
        }
        /// <summary>
        /// Gets the order details by id.
        /// </summary>
        /// <param name="productid">The productid.</param>
        /// <returns></returns>
        public int CountOrderDetailsByProductId(int productid)
        {
            ProductManager _productManager = new ProductManager();
            int orderDetailsNum = _productManager.CountOrderDetailsByProductId(productid);
            return orderDetailsNum;
        }
        #endregion
    }
}
