using LKMovies.Models;

namespace LKMovies.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(int id);
        Task<Genre> GetByName(string name);
        Task<Genre> Add(Genre genre);
        Task<Genre> Update(int id, Genre genre);
        Task<bool> Delete(int id);
    }
}
