using LKMovies.Models;

namespace LKMovies.Services.Interfaces
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(int id);
        Task<Genre> GetByName(string name);
        Task<Genre> Add(Genre genre);
        Task<Genre> Update(Genre genre);
        Task<Genre> Delete(int id);
    }
}
