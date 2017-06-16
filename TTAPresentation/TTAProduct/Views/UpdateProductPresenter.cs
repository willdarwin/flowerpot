using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTAProduct.Views
{
    public class UpdateProductPresenter : Presenter<IUpdateProductView>
    {
        /// <summary>
        /// Product controller.
        /// </summary>
        private ITTAProductController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductPresenter"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public UpdateProductPresenter([CreateNew] ITTAProductController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        public void UpdateProduct()
        {
            ProductBE product = new ProductBE();
            product.ProductId = View.ProductId;
            product.ProductName = View.ProductName;
            product.ProductPrice = View.ProductPrice;
            product.CategoryId = View.CategoryId;

            CategoryBE category = new CategoryBE();
            category.CategoryId = View.CategoryId;
            product.Category = category;

            _controller.UpdateProduct(product);
        }

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetProductById()
        {
            return _controller.GetProductById(View.ProductId);
        }

        /// <summary>
        /// Selects all category.
        /// </summary>
        /// <returns></returns>
        public List<CategoryBE> SelectAllCategory()
        {
            return _controller.SelectAllCategory();
        }
    }
}




