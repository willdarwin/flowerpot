using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataEntity;

namespace TTA.DataManager
{
    public class ProductTranslator
    {
        #region public method
        /// <summary>
        /// To Translate ProductBE to Product
        /// </summary>
        /// <param name="productBE"></param>
        /// <returns></returns>
        public Product Translate(ProductBE productBE)
        {
            if (productBE != null)
            {
                Product productDE = new Product();
                productDE.ProductId = productBE.ProductId;
                productDE.ProductName = productBE.ProductName;
                productDE.ProductPrice = productBE.ProductPrice;
                productDE.CategoryId = productBE.Category.CategoryId;

                return productDE;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// To Translate Product to ProductBE
        /// </summary>
        /// <param name="productDE"></param>
        /// <returns></returns>
        public ProductBE Translate(Product productDE)
        {
            if (productDE != null)
            {
                ProductBE productBE = new ProductBE()
                {
                    ProductId = productDE.ProductId,
                    ProductName = productDE.ProductName,
                    ProductPrice = productDE.ProductPrice,
                    CategoryId = productDE.CategoryId,
                    Category = new CategoryBE()
                };

                if (productDE.Category != null)
                {
                    CategoryTranslator categoryTranslator = new CategoryTranslator();
                    productBE.Category = categoryTranslator.Translate(productDE.Category);
                }

                return productBE;
            }
            else
            {
                return null;
            }

        }
        #endregion
    }
}
