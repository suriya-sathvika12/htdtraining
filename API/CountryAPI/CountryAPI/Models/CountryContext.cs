using System.Data.Entity;

namespace CountryAPI.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext() : base("CountryDB")
        {
        }

        public DbSet<Country> Countries { get; set; }
    }
}