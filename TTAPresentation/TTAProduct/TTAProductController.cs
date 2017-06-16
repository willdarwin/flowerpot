using System;
using TTAPresentation.TTAProduct.Services;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;
using System.Collections.Generic;
namespace TTAPresentation.TTAProduct
{
    public class TTAProductController : ITTAProductController
    {
        private IProductService _productService;

        [ServiceDependency]
        public IProductService ProductService
        {
            set { _productService = value; }
        }

        /// <summary>
        /// Selects all product.
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAllProduct()
        {
            return _productService.SelectAllProduct();
        }

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        public bool InsertProduct(ProductBE productBE)
        {
            return _productService.InsertProduct(productBE);
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        public bool UpdateProduct(ProductBE productBE)
        {

            return _productService.UpdateProduct(productBE);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }

        /// <summary>
        /// Selects all category.
        /// </summary>
        /// <returns></returns>
        public List<CategoryBE> SelectAllCategory()
        {
            return _productService.SelectAllCategory();
        }

        /// <summary>
        /// Counts the order details by product id.
        /// </summary>
        /// <param name="productid">The productid.</param>
        /// <returns></returns>
        public int CountOrderDetailsByProductId(int productid)
        {
            return _productService.CountOrderDetailsByProductId(productid);
        }
    }
}
