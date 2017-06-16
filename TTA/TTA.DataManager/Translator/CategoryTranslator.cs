using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataEntity;

namespace TTA.DataManager
{
    public class CategoryTranslator
    {
        /// <summary>
        /// Translate Category To CategoryBE
        /// </summary>
        /// <param name="categoryDE"></param>
        /// <returns></returns>
        public CategoryBE Translate(Category categoryDE)
        {
            if (categoryDE != null)
            {
                CategoryBE categoryBE = new CategoryBE()
                {
                    CategoryId = categoryDE.CategoryId,
                    CategoryName = categoryDE.CategoryName
                };
               return categoryBE;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Translate CategoryBE To Category
        /// </summary>
        /// <param name="categoryBE"></param>
        /// <returns></returns>
        public Category Translate(CategoryBE categoryBE)
        {
            if (categoryBE != null)
            {
                Category CategoryDE = new Category();
                CategoryDE.CategoryId = categoryBE.CategoryId;
                CategoryDE.CategoryName = categoryBE.CategoryName;
                return CategoryDE;
            }
            else
            {
                return null;
            }

        }

    }
}
