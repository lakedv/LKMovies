namespace LKMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Synopsis { get; set; }
        public float Score { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
        public int? DirectorId { get; set; }
        public Director? Director { get; set; } = null!;
        public List<Genre>? Genres { get; set; } = null!;
        public List<Actor>? Actors { get; set; } = null!;
    }
}