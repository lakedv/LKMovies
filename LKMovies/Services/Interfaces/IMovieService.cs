using LKMovies.Models;
using LKMovies.ViewModels;

namespace LKMovies.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieViewModel>> GetAll();
        public Task<MovieViewModel> GetById(int id);
        public Task<Movie> Add(Movie movie);
        public Task<Movie> Update(int id, Movie movie);
        public Task<bool> Delete(int id);
    }
}
