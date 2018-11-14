using System;
using Microsoft.EntityFrameworkCore;

namespace MovieEntities
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }

        public DbSet<MovieRating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Trying it here
            //optionsBuilder.UseSqlite("Data Source=Movie.db");
        }
    }
}
