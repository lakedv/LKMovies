using LKMovies.Models;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class GenreService : IGenreService
    {
        public Task<Genre> Add(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
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

        public Task<Genre> Update(int id, Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
