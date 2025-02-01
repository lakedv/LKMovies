using Humanizer.Localisation;
using LKMovies.Data;
using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LKMovies.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly LKMoviesContext _db;
        public DirectorRepository(LKMoviesContext db)
        {
            _db = db;
        }
        public async Task<Director> Add(Director director)
        {
            if (director == null) throw new ArgumentNullException(nameof(director));
            await _db.Directors.AddAsync(director);
            await _db.SaveChangesAsync();
            return director;
        }

        public async Task<bool> Delete(int id)
        {
            var director = await _db.Directors.FirstOrDefaultAsync(d => d.Id == id);
            if (director == null) return false;
            _db.Directors.Remove(director);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Director>> GetAll()
        {
            return await _db.Directors.ToListAsync();
        }

        public async Task<Director> GetById(int id)
        {
            return await _db.Directors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Director> GetByLastName(string LastName)
        {
            return await _db.Directors.FirstOrDefaultAsync(l => l.LastName == LastName);
        }

        public async Task<Director> GetByName(string FirstName)
        {
            return await _db.Directors.FirstOrDefaultAsync(f => f.FirstName == FirstName);
        }

        public async Task<Director> Update(int id, Director director)
        {
            if (await _db.Directors.Where(d => d.Id == id).AsNoTracking().FirstOrDefaultAsync() == null)
            {
                throw new Exception("Director not Found.");
            }

            _db.Directors.Update(director);
            await _db.SaveChangesAsync();
            return director;
        }
    }
}
