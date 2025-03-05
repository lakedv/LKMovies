using LKMovies.Models;

namespace LKMovies.ViewModels.Movies
{
    public class GetMovieViewModel
    {
        public GetMovieViewModel()
        {
            
        }
        public GetMovieViewModel(Movie movie)
        {
            Title = movie.Title;
            Id = movie.Id;
            Synopsis = movie.Synopsis;
            Score = movie.Score;
            Year = movie.Year;
            Director = $"{movie.Director?.FirstName} {movie.Director?.LastName}";
            Actors = string.Join(", ", movie.Actors?.Select(a => $"{a.FirstName} {a.LastName}"));
            Category = movie.Category?.Name;
            Genres = string.Join(", ", movie.Genres?.Select(g => g.Name));
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Synopsis { get; set; }
        public float Score { get; set; }
        public string Category { get; set; }
        public string Genres { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
    }
}
