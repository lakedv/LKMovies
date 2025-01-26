using LKMovies.Models;

namespace LKMovies.Services.Interfaces
{
    public interface IDirectorsService
    {
        public Task<IEnumerable<Director>> GetAll();
        public Task<IEnumerable<Director>> GetById(int id);
        public Task<Director> GetByName(string FirstName);
        public Task<Director> GetByLastName(string LastName);
        public Task<Director> Add(Director director);
        public Task<Director> Update(Director director);
        public Task<Director> Delete(int id);
    }
}
