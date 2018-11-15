using System;
using Microsoft.EntityFrameworkCore;
using MovieEntities.Mapping.Models;

namespace MovieEntities.Mapping
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        { }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }

        public DbSet<MovieRating> Ratings { get; set; }
        public DbSet<MovieSource> Sources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Trying it here
            optionsBuilder.UseSqlite("Data Source=Movie.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieSource>().HasData(
                new MovieSource { Id = 1, Name = "Netflix" },
                new MovieSource { Id = 2, Name = "Hulu Plus" },
                new MovieSource { Id = 3, Name = "Amazon Prime" }
            );
        }
    }
}
