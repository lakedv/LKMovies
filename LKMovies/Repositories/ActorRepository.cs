using LKMovies.Data;
using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LKMovies.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly LKMoviesContext _db;
        public ActorRepository(LKMoviesContext db)
        {
            _db = db;
        }
        public async Task<Actor> Add(Actor actor)
        {
            if (actor == null) throw new ArgumentNullException(nameof(actor));
            await _db.Actors.AddAsync(actor);
            await _db.SaveChangesAsync();
            return actor;
        }

        public async Task<bool> Delete(int id)
        {
            var actor = await _db.Actors.FirstOrDefaultAsync(a => a.Id == id);
            if (actor == null) return false;
            _db.Actors.Remove(actor);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            return await _db.Actors.ToListAsync();
        }

        public async Task<Actor> GetById(int id)
        {
            return await _db.Actors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Actor> GetByLastName(string LastName)
        {
            return await _db.Actors.FirstOrDefaultAsync(l => l.LastName == LastName);
        }

        public async Task<Actor> GetByName(string FirstName)
        {
            return await _db.Actors.FirstOrDefaultAsync(f => f.FirstName == FirstName);
        }

        public async Task<Actor> Update(int id, Actor actor)
        {
            if (await _db.Actors.Where(a => a.Id == id).AsNoTracking().FirstOrDefaultAsync() == null)
            {
                throw new Exception("Actor not Found.");
            }

            _db.Actors.Update(actor);
            await _db.SaveChangesAsync();
            return actor;
        }
    }
}
