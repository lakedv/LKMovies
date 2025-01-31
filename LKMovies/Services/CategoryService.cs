using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> Add(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof (category));
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("Name can not be empty", nameof(category.Name));
            return await _categoryRepository.Add(category);
        }

        public async Task<bool> Delete(int id)
        {
            return await _categoryRepository.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _categoryRepository.GetByName(name);
        }

        public async Task<Category> Update(int id, Category category)
        {
            return await _categoryRepository.Update(id, category);
        }
    }
}
