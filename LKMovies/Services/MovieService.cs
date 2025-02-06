using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using LKMovies.Services.Interfaces;
using LKMovies.Data;
using LKMovies.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using LKMovies.ViewModels;

namespace LKMovies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryService _categoryService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        private readonly IDirectorService _directorService;
        private readonly Filter _filter;
        public MovieService(IMovieRepository movieRepository, ICategoryService categoryService, IGenreService genreService, IActorService actorService, IDirectorService directorService)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
            _directorService = directorService ?? throw new ArgumentNullException(nameof(directorService));

        }
        public async Task<Movie> Add(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            if (string.IsNullOrWhiteSpace(movie.Title))
                throw new ArgumentException("Title can not be empty", nameof(movie.Title));
            return await _movieRepository.Add(movie);
        }

        public async Task<bool> Delete(int id)
        {
            return await _movieRepository.Delete(id);
        }

        public async Task<IEnumerable<MovieViewModel>> GetAll()
        {
            IEnumerable<Movie> movies = await _movieRepository.GetAll();
            ICollection<MovieViewModel> viewModels = new List<MovieViewModel>();

            foreach (Movie movie in movies)
            {
                MovieViewModel viewModel = new MovieViewModel();
                viewModel.Title = movie.Title;
                viewModel.Id = movie.Id;
                viewModel.Synopsis = movie.Synopsis;
                viewModel.Score = movie.Score;
                viewModel.Year = movie.Year;
                viewModel.Director = $"{movie.Director.FirstName} {movie.Director.LastName}";
                viewModel.Actors = string.Join(", ", movie.Actors.Select(a => $"{a.FirstName} {a.LastName}"));
                viewModel.Category = movie.Category.Name;
                viewModel.Genres = string.Join(", ", movie.Genres.Select(g => g.Name));


                viewModels.Add(viewModel);
            }

            return viewModels;
        }

        public async Task<MovieViewModel> GetById(int id)
        {
            Movie movie = await _movieRepository.GetById(id);
            MovieViewModel viewModel = new MovieViewModel();
            viewModel.Title = movie.Title;
            viewModel.Id = movie.Id;
            viewModel.Synopsis = movie.Synopsis;
            viewModel.Score = movie.Score;
            viewModel.Year = movie.Year;
            viewModel.Director = $"{movie.Director.FirstName} {movie.Director.LastName}";
            viewModel.Actors = string.Join(", ", movie.Actors.Select(a => $"{a.FirstName} {a.LastName}"));
            viewModel.Category = movie.Category.Name;
            viewModel.Genres = string.Join(", ", movie.Genres.Select(g => g.Name));
            
            return viewModel;
        }

        public async Task<Movie> Update(int id, Movie movie)
        {
            return await _movieRepository.Update(id, movie);
        }
        /*public IActionResult Filter(Filter filter) 
        {
            var movie = _movieRepository.AsQueryable();
            if(!string.IsNullOrEmpty(filter.Title))
                movie = movie.Where(m => m.Title.Contains(filter.Title));
            if (filter.Year.HasValue)
                movie = movie.Where(m => m.Year == filter.Year);
            if (filter.Score.HasValue)
                movie = movie.Where(movie => movie.Score == filter.Score);
            if (!string.IsNullOrEmpty(filter.Genre))
                movie = movie.Where(m => m.Genre.Contains(filter.Genre));
            if (!string.IsNullOrEmpty(filter.Actor))
                movie = movie.Where(m => m.Actor.Contains(filter.Actor));
            if (!string.IsNullOrEmpty(filter.Director))
                movie = movie.Where(m => m.Director.Contains(filter.Director));

            return View("Filter", new { Filter = filter, Result = movie.ToList() });

        }*/
    }
}
