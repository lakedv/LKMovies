using LKMovies.Data;
using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LKMovies.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly LKMoviesContext _db;
        public MovieRepository(LKMoviesContext db)
        {
            _db = db;
        }

        public async Task<Movie> Add(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> Delete(int id)
        {
           var movie = await _db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return false;
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            return await _db.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie> Update(int id, Movie movie)
        {
            if (await _db.Movies.Where(g => g.Id == id).AsNoTracking().FirstOrDefaultAsync() == null)
            {
                throw new Exception("Movie not Found.");
            }
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
            return movie;
        }
    }
}
