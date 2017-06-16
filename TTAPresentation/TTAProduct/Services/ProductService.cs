using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.IService;
using TTA.Model;
using TTA.ServiceProxy;

namespace TTAPresentation.TTAProduct.Services
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Selects all product.
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAllProduct()
        {
            Proxy proxy = new Proxy();
            return proxy.SelectAllProduct();
        }

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetProductById(int id)
        {
            Proxy proxy = new Proxy();
            return proxy.GetProductById(id);
        }

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        public bool InsertProduct(ProductBE productBE)
        {
            Proxy proxy = new Proxy();
            return proxy.InsertProduct(productBE);
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        public bool UpdateProduct(ProductBE productBE)
        {
            Proxy proxy = new Proxy();
            return proxy.UpdateProduct(productBE);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteProduct(int id)
        {
            Proxy proxy = new Proxy();
            return proxy.DeleteProduct(id);
        }

        /// <summary>
        /// Selects all category.
        /// </summary>
        /// <returns></returns>
        public List<CategoryBE> SelectAllCategory()
        {
            Proxy proxy = new Proxy();
            return proxy.SelectAllCategory();
        }

        /// <summary>
        /// Counts the order details by product id.
        /// </summary>
        /// <param name="productid">The productid.</param>
        /// <returns></returns>
        public int CountOrderDetailsByProductId(int productid)
        {
            Proxy proxy = new Proxy();
            return proxy.CountOrderDetailsByProductId(productid);
        }
    }
}
