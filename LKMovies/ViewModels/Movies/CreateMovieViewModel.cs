using LKMovies.Models;

namespace LKMovies.ViewModels.Movies
{
    public class CreateMovieViewModel
    {
        public CreateMovieViewModel()
        {
            
        }
        public CreateMovieViewModel(Movie movie)
        {
            Title = movie.Title;
            Id = movie.Id;
            Synopsis = movie.Synopsis;
            Score = movie.Score;
            Year = movie.Year;
            DirectorId = movie.DirectorId;
            SelectedActors = movie.Actors.Select(a => a.Id).ToList();
            CategoryId = movie.CategoryId;
            SelectedGenres = movie.Genres.Select(g => g.Id).ToList();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Synopsis { get; set; }
        public float Score { get; set; }
        public int? CategoryId { get; set; }
        public int? DirectorId { get; set; }
        public List<int> SelectedGenres { get; set; }
        public List<int> SelectedActors { get; set; }
    }
}
