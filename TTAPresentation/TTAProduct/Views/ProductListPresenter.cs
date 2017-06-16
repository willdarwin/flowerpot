using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTAProduct.Views
{
    public class ProductListPresenter : Presenter<IProductListView>
    {

        /// <summary>
        /// Product Controller.
        /// </summary>
        private ITTAProductController _controller;
        public ProductListPresenter([CreateNew] ITTAProductController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Selects all product.
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAllProduct()
        {
            return _controller.SelectAllProduct();
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <returns></returns>
        public bool DeleteProduct()
        {
            return _controller.DeleteProduct(View.ProductId);
        }

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <returns></returns>
        public ProductBE GetProductById()
        {
            return _controller.GetProductById(View.ProductId);
        }

        /// <summary>
        /// Counts the order details by product id.
        /// </summary>
        /// <returns></returns>
        public int CountOrderDetailsByProductId()
        {
            return _controller.CountOrderDetailsByProductId(View.ProductId);
        }

    }
}




