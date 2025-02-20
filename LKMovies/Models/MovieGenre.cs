namespace LKMovies.Models
{
    public class MovieGenre
    {
        public Movie movie { get; set; } = null!;
        public int MovieId { get; set; }
        public Genre genre { get; set; } = null!;
        public int GenreId { get; set; }
    }
}
