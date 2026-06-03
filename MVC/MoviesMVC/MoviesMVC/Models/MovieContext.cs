using System.Data.Entity;

namespace MoviesMVC.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MovieConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}