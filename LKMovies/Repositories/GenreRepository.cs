using LKMovies.Data;
using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LKMovies.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LKMoviesContext _db;
        public GenreRepository(LKMoviesContext db)
        {
            _db = db;
        }
        public async Task<Genre> Add(Genre genre)
        {
            if (genre == null) throw new ArgumentNullException(nameof(genre));
            await _db.Genres.AddAsync(genre);
            await _db.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> Delete(int id)
        {
            var genre = await _db.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null) return false;
            _db.Genres.Remove(genre);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _db.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await _db.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Genre> Update(int id, Genre genre)
        {
            if (await _db.Genres.Where(g => g.Id == id).AsNoTracking().FirstOrDefaultAsync() == null)
            {
                throw new Exception("Genre not Found.");
            }

            _db.Genres.Update(genre);
            await _db.SaveChangesAsync();
            return genre;
        }
    }
}
