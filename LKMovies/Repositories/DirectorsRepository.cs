using LKMovies.Models;
using LKMovies.Repositories.Interfaces;

namespace LKMovies.Repositories
{
    public class DirectorsRepository : IDirectorsRepository
    {
        public Task<Director> Add(Director director)
        {
            throw new NotImplementedException();
        }

        public Task<Director> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Director>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Director>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Director> GetByLastName(string LastName)
        {
            throw new NotImplementedException();
        }

        public Task<Director> GetByName(string FirstName)
        {
            throw new NotImplementedException();
        }

        public Task<Director> Update(Director director)
        {
            throw new NotImplementedException();
        }
    }
}
