using LKMovies.Models;

namespace LKMovies.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public Task<IEnumerable<Genre>> GetAll();
        public Task<Genre> GetById(int id);
        public Task<Genre> Add(Genre genre);
        public Task<Genre> Update(int id, Genre genre);
        public Task<bool> Delete(int id);
    }
}
