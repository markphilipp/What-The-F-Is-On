using System;
using Microsoft.EntityFrameworkCore;
using MovieEntities.Models;

namespace MovieEntities
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        { }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }

        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<MovieSource> MovieSources { get; set; }

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

            modelBuilder.Entity<MovieRatingSource>()
                .HasKey(mrs => new { mrs.RatingId, mrs.SourceId });

            modelBuilder.Entity<MovieRatingSource>()
                .HasOne<MovieRating>(mrs => mrs.Rating)
                .WithMany(r => r.RatingSources)
                .HasForeignKey(mrs => mrs.RatingId);

            modelBuilder.Entity<MovieRatingSource>()
                .HasOne<MovieSource>(mrs => mrs.Source)
                .WithMany()
                .HasForeignKey(mrs => mrs.SourceId);
        }
    }
}
