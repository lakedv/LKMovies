using LKMovies.Models;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class ActorService : IActorService
    {
        public Task<Actor> Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Actor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Actor>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> GetByLastName(string LastName)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> GetByName(string FirstName)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
