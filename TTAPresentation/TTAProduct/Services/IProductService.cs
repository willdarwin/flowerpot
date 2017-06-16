﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.ServiceProxy;

namespace TTAPresentation.TTAProduct.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Selects all product.
        /// </summary>
        /// <returns></returns>
        List<ProductBE> SelectAllProduct();

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        ProductBE GetProductById(int id);

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        bool InsertProduct(ProductBE productBE);

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        bool UpdateProduct(ProductBE productBE);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool DeleteProduct(int id);

        /// <summary>
        /// Selects all category.
        /// </summary>
        /// <returns></returns>
        List<CategoryBE> SelectAllCategory();

        /// <summary>
        /// Counts the order details by product id.
        /// </summary>
        /// <returns></returns>
        int CountOrderDetailsByProductId(int productid);
    }
}
