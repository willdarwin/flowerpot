using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTAProduct.Views
{
    public class CreateProductPresenter : Presenter<ICreateProductView>
    {
        private ITTAProductController _controller;
        public CreateProductPresenter([CreateNew] ITTAProductController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        public void InsertProduct()
        {
            ProductBE productBE = new ProductBE();
            productBE.ProductName = View.ProductName;
            productBE.ProductPrice = View.ProductPrice;
            productBE.CategoryId = View.CategoryId;
            CategoryBE categoryBE = new CategoryBE();
            categoryBE.CategoryId = View.CategoryId;
            productBE.Category = categoryBE;
            _controller.InsertProduct(productBE);
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




