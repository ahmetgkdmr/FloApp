using ECommerce.Entity.Entities;
using ECommerce.Repository.Repository;

namespace ECommerce.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category != null)
            {
                _categoryRepository.Delete(category);
            }
        }
    }
}
