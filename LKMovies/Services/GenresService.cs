using LKMovies.Models;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class GenresService : IGenresService
    {
        public Task<Genre> Add(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> Update(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
