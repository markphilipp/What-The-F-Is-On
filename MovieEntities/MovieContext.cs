using System;
using Microsoft.EntityFrameworkCore;

namespace MovieEntities
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
        {}

        public DbSet<MovieRating> Ratings { get; set; }
    }
}
