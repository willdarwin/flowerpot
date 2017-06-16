using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DataEntity;
using System.Data.Entity;
using TTA.Model;

/*************************************************************************
 * * Author: Lily
 
 * * Description:
 
 * *    CUID(Create,Update,Insert,Delete) functions to the table Category.
 *************************************************************************/

namespace TTA.DataManager
{
    public partial class CategoryManager
    {
        #region Property Initialize

        private TTAEntityContainer _dbEntity;

        public TTAEntityContainer DBEntity
        {
            get{return _dbEntity;}
            private set{_dbEntity = this.DBEntity;}
        }

        /// <summary>
        /// Initialize the DB context.
        /// </summary>
        public CategoryManager()
        {
            this._dbEntity = new TTAEntityContainer();
        }
        #endregion

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <param name="dbEntity">The db entity.</param>
        /// <returns></returns>
        public List<CategoryBE> GetAllCategories(TTAEntityContainer dbEntity)
        {
            List<CategoryBE> listCategoryBE = new List<CategoryBE>();
            CategoryTranslator categoryTranslator = new CategoryTranslator();

            List<Category> categoryDEList = (from Category category in dbEntity.Categories 
                                             select category).ToList<Category>();
            foreach (Category categoryDE in categoryDEList)
            {
                CategoryBE categoryBE = categoryTranslator.Translate(categoryDE);
                listCategoryBE.Add(categoryBE);
            }
            return listCategoryBE;
        }

        /// <summary>
        /// Get all Categories.
        /// </summary>
        /// <returns></returns>
        public List<CategoryBE> GetAllCategories()
        {
            return this.GetAllCategories(this.DBEntity);
        }

        public Category GetById(TTAEntityContainer dbEntity, int id)
        {
            Category categoryDE = (from Category category in dbEntity.Categories 
                                   where category.CategoryId == id 
                                   select category).SingleOrDefault<Category>();
            return categoryDE;
        }

        /// <summary>
        /// Get category record by the input - id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id)
        {
            return this.GetById(this.DBEntity, id);
        }

        public void Insert(TTAEntityContainer dbEntity, Category category)
        {
            dbEntity.Categories.AddObject(category);
            dbEntity.SaveChanges();
        }

        /// <summary>
        /// Insert a category object to DB.
        /// </summary>
        /// <param name="category"></param>
        public void Insert(Category category)
        {
            this.Insert(this.DBEntity, category);
        }

        public void Update(TTAEntityContainer dbEntity, Category category)
        {
            Category categoryDE = (from Category cate in dbEntity.Categories 
                                   where cate.CategoryId == category.CategoryId 
                                   select cate).SingleOrDefault<Category>();
            categoryDE.CategoryName = category.CategoryName;
            dbEntity.SaveChanges();
        }

        /// <summary>
        /// Update the input cayegory object in DB.
        /// </summary>
        /// <param name="category"></param>
        public void Update(Category category)
        {
            this.Update(this.DBEntity, category);
        }

        public void Delete(TTAEntityContainer dbEntity, int id)
        {
            Category categoryDE = (from Category category in dbEntity.Categories 
                                   where category.CategoryId == id 
                                   select category).SingleOrDefault<Category>();
            dbEntity.DeleteObject(categoryDE);
            dbEntity.SaveChanges();
        }

        /// <summary>
        /// Delete a record from DB by the input id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id) 
        {
            this.Delete(this.DBEntity, id);
        }
    }
}
