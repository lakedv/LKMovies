namespace LKMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Synopsis { get; set; }
        public decimal Score { get; set; }
        public Category Category { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }
        public Actor Actor { get; set; }
    }
}