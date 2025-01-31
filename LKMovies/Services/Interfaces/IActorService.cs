using LKMovies.Models;

namespace LKMovies.Services.Interfaces
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetAll();
        public Task<IEnumerable<Actor>> GetById(int id);
        public Task<Actor> GetByName(string FirstName);
        public Task<Actor> GetByLastName(string LastName);
        public Task<Actor> Add(Actor actor);
        public Task<Actor> Update(int id, Actor actor);
        public Task<bool> Delete(int id);
    }
}