using LKMovies.Models;

namespace LKMovies.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> GetById(int id);
        public Task<Category> Add(Category category);
        public Task<Category> Update(int id, Category category);
        public Task<bool> Delete(int id);
    }
}