using LKMovies.Models;

namespace LKMovies.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetAll();
        public Task<Movie> GetById(int id);
        public Task<Movie> Add(Movie movie);
        public Task<Movie> Update(int id, Movie movie);
        public Task<bool> Delete(int id);
    }
}