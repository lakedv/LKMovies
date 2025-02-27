using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using LKMovies.Services.Interfaces;
using LKMovies.Data;
using LKMovies.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using LKMovies.ViewModels.Movies;

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
        public async Task<Movie> Add(CreateMovieViewModel movieViewModel)
        {
            if (movieViewModel == null) throw new ArgumentNullException(nameof(movieViewModel));
            if (string.IsNullOrWhiteSpace(movieViewModel.Title))
                throw new ArgumentException("Title can not be empty", nameof(movieViewModel.Title));
            Movie movie = new Movie
            {
                Title = movieViewModel.Title,
                Year = movieViewModel.Year,
                Synopsis = movieViewModel.Synopsis,
                Score = movieViewModel.Score,
                DirectorId = movieViewModel.DirectorId,
                CategoryId = movieViewModel.CategoryId,
                Genres = new List<Genre>(),
                Actors = new List<Actor>()
            };
            foreach (int actorId in movieViewModel.SelectedActors)
            {
                movie.Actors.Add(await _actorService.GetById(actorId));
            }
            foreach (int genreId in movieViewModel.SelectedGenres)
            {
                movie.Genres.Add(await _genreService.GetById(genreId));
            }

            return await _movieRepository.Add(movie);
        }

        public async Task<bool> Delete(int id)
        {
            return await _movieRepository.Delete(id);
        }

        public async Task<IEnumerable<GetMovieViewModel>> GetAll()
        {
            IEnumerable<Movie> movies = await _movieRepository.GetAll();
            ICollection<GetMovieViewModel> viewModels = new List<GetMovieViewModel>();

            foreach (Movie movie in movies)
            {
                GetMovieViewModel viewModel = new GetMovieViewModel();
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

        public async Task<GetMovieViewModel> GetById(int id)
        {
            Movie movie = await _movieRepository.GetById(id);
            GetMovieViewModel viewModel = new GetMovieViewModel();
            viewModel.Title = movie.Title;
            viewModel.Id = movie.Id;
            viewModel.Synopsis = movie.Synopsis;
            viewModel.Score = movie.Score;
            viewModel.Year = movie.Year;
            viewModel.Director = $"{movie.Director?.FirstName} {movie.Director?.LastName}";
            viewModel.Actors = string.Join(", ", movie.Actors?.Select(a => $"{a.FirstName} {a.LastName}"));
            viewModel.Category = movie.Category?.Name;
            viewModel.Genres = string.Join(", ", movie.Genres?.Select(g => g.Name));
            
            return viewModel;
        }

        public async Task<Movie> Update(int id, Movie movie)
        {
            return await _movieRepository.Update(id, movie);
        }

        public async Task GetViewBagData(dynamic viewBag) 
        {
            viewBag.Categories = await _categoryService.GetAll();
            viewBag.Directors = await _directorService.GetAll();
            viewBag.Genres = await _genreService.GetAll();
            viewBag.Actors = await _actorService.GetAll();
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
