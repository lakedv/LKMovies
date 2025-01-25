using LKMovies.Models;

namespace LKMovies.Repositories.Interfaces
{
    public interface IGenresRepository
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(int id);
        Task<Genre> GetByName(string name);
        Task<Genre> Add(Genre genre);
        Task<Genre> Update(Genre genre);
        Task<Genre> Delete(int id);
    }
}
