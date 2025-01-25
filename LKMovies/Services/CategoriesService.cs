using LKMovies.Models;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class CategoriesService : ICategoriesService
    {
        public Task<Category> Add(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
