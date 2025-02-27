using LKMovies.Models;

namespace LKMovies.ViewModels.Movies
{
    public class GetMovieViewModel
    {
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
