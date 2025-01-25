using LKMovies.Models;
using LKMovies.Repositories.Interfaces;

namespace LKMovies.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
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
