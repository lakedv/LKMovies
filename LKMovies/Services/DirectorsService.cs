using LKMovies.Models;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class DirectorsService : IDirectorsService
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
