using Microsoft.AspNetCore.Mvc;
using WearHouse_API_Revision.Datas;
using WearHouse_API_Revision.Models;
using WearHouse_API_Revision.Outputs;

namespace WearHouse_API_Revision.Helpers
{
    public class CategoryHelper
    {
        private AppDbContext _dbContext;
        public CategoryHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Category> GetCategory([FromBody] CategoryRequest request)
        {
            try
            {
                if (request.CategoryID != null)
                {
                    var category = (from c in _dbContext.Category
                                    where c.CategoryID == request.CategoryID
                                    select c).ToList();
                    if (category != null) return category;
                }
                else
                {
                    var categories = _dbContext.Category.ToList();
                    if(categories != null) return categories;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Category InsertCategory([FromBody] NameCategoryRequest request) 
        {
            try
            {
                var newCategory = new Category
                {
                    CategoryName = request.CategoryName,
                };
                _dbContext.Category.Add(newCategory);
                _dbContext.SaveChanges();
                return newCategory;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Category UpdateCategory([FromBody] CategoryRequest request) 
        {
            try
            {
                var categoryData = GetCategory(request);
                Category findCategory = null;
                if (categoryData.Count != 0)
                {
                    findCategory = categoryData.FirstOrDefault();
                    findCategory.CategoryName = request.CategoryName;
                    _dbContext.SaveChanges();
                }
                return findCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StatusOutput DeleteCategory([FromBody] CategoryRequest request)
        {
            try
            {
                var status = new StatusOutput();
                var categoryData = GetCategory(request);
                Category findCategory = null;
                if (categoryData.Count != 0)
                {
                    findCategory = categoryData.FirstOrDefault();
                    _dbContext.Category.Remove(findCategory);
                    _dbContext.SaveChanges();
                    status.Status = 200;
                    status.Message = "Success";
                    return status;
                }
                status.Status = 404;
                status.Message = "Category Not Found";
                return status;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
