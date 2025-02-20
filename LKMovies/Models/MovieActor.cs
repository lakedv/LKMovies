using Microsoft.Identity.Client;

namespace LKMovies.Models
{
    public class MovieActor
    {
        public Movie movie { get; set; } = null!;
        public int MovieId { get; set; }
        public Actor actor { get; set; } = null!;
        public int ActorId { get; set; }
    }
}
