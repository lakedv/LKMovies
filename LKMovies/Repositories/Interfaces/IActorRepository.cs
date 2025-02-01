using LKMovies.Models;
namespace LKMovies.Repositories.Interfaces
{
    public interface IActorRepository
    {
        public Task<IEnumerable<Actor>> GetAll();
        public Task<Actor> GetById(int id);
        public Task<Actor> GetByName(string FirstName);
        public Task<Actor> GetByLastName(string LastName);
        public Task<Actor> Add(Actor actor);
        public Task<Actor> Update(int id, Actor actor);
        public Task<bool> Delete(int id);
    }
}
