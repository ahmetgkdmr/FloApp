using ECommerce.Entity.Entities;

namespace ECommerce.Business.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category Category);
        void UpdateCategory(Category Category);
        void DeleteCategory(int id);
    }
}
