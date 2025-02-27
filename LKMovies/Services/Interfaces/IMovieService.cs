using LKMovies.Models;
using LKMovies.ViewModels.Movies;

namespace LKMovies.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<IEnumerable<GetMovieViewModel>> GetAll();
        public Task<GetMovieViewModel> GetById(int id);
        public Task<Movie> Add(CreateMovieViewModel movieViewModel);
        public Task<Movie> Update(int id, Movie movie);
        public Task<bool> Delete(int id);
        public Task GetViewBagData(dynamic viewBag);
    }
}
