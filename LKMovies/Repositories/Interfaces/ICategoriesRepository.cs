using LKMovies.Models;

namespace LKMovies.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> GetByName(string name);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
    }
}