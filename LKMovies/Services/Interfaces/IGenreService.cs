using LKMovies.Models;

namespace LKMovies.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(int id);
        Task<Genre> Add(Genre genre);
        Task<Genre> Update(int id, Genre genre);
        Task<bool> Delete(int id);
    }
}
