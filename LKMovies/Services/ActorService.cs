using LKMovies.Models;
using LKMovies.Repositories;
using LKMovies.Repositories.Interfaces;
using LKMovies.Services.Interfaces;
using System.IO;

namespace LKMovies.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
        }
        public async Task<Actor> Add(Actor actor)
        {
            if (actor == null) throw new ArgumentNullException(nameof(actor));
            if (string.IsNullOrWhiteSpace(actor.FirstName))
                throw new ArgumentException("Name can not be empty", nameof(actor.FirstName));
            if (string.IsNullOrWhiteSpace(actor.LastName))
                throw new ArgumentException("Surname can not be empty", nameof(actor.LastName));
            return await _actorRepository.Add(actor);
        }

        public async Task<bool> Delete(int id)
        {
            return await _actorRepository.Delete(id);
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            return await _actorRepository.GetAll();
        }

        public async Task<Actor> GetById(int id)
        {
            return await _actorRepository.GetById(id);
        }

        public async Task<Actor> GetByLastName(string LastName)
        {
            return await _actorRepository.GetByLastName(LastName);
        }

        public async Task<Actor> GetByName(string FirstName)
        {
            return await _actorRepository.GetByName(FirstName);
        }

        public async Task<Actor> Update(int id, Actor actor)
        {
            return await _actorRepository.Update(id, actor);
        }
    }
}
