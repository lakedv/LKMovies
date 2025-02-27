using LKMovies.Models;

namespace LKMovies.ViewModels.Movies
{
    public class CreateMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Synopsis { get; set; }
        public float Score { get; set; }
        public int? CategoryId { get; set; }
        public int? DirectorId { get; set; }
        public Director Director { get; set; }
        public List<int> SelectedGenres { get; set; }
        public List<int> SelectedActors { get; set; }
    }
}
