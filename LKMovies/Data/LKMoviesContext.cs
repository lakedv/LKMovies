using Microsoft.EntityFrameworkCore;
using LKMovies.Models;
using LKMovies.ViewModels;

namespace LKMovies.Data
{
    public class LKMoviesContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }


        public LKMoviesContext(DbContextOptions options) :
            base(options)
        { }
    }
}
