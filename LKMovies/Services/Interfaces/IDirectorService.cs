using LKMovies.Models;

namespace LKMovies.Services.Interfaces
{
    public interface IDirectorService
    {
        public Task<IEnumerable<Director>> GetAll();
        public Task<IEnumerable<Director>> GetById(int id);
        public Task<Director> GetByName(string FirstName);
        public Task<Director> GetByLastName(string LastName);
        public Task<Director> Add(Director director);
        public Task<Director> Update(int id, Director director);
        public Task<bool> Delete(int id);
    }
}
