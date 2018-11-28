using System;
using Microsoft.EntityFrameworkCore;
using MovieEntities.Mapping;
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
                new MovieSource { Id = 1, Name = "Netflix", Code = "netflix" },
                new MovieSource { Id = 2, Name = "Hulu Plus", Code = "hulu_plus" },
                new MovieSource { Id = 3, Name = "Amazon Prime", Code = "amazon_prime" },
                new MovieSource { Id = 4, Name = "HBO", Code = "hbo" },
                new MovieSource { Id = 5, Name = "Showtime", Code = "showtime" },
                new MovieSource { Id = 6, Name = "Starz", Code = "starz" },
                new MovieSource { Id = 7, Name = "Mubi", Code = "mubi" },
                new MovieSource { Id = 8, Name = "Cinemax", Code = "cinemax" },
                new MovieSource { Id = 9, Name = "CBS All Access", Code = "cbs_all_access" },
                new MovieSource { Id = 10, Name = "Fandor", Code = "fandor" },
                new MovieSource { Id = 11, Name = "Acorntv", Code = "acorntv" },
                new MovieSource { Id = 12, Name = "Film Struck", Code = "film_struck" },
                new MovieSource { Id = 13, Name = "Shudder", Code = "shudder" },
                new MovieSource { Id = 14, Name = "Fx TVEverywhere", Code = "fx_tveverywhere" },
                new MovieSource { Id = 15, Name = "Fox TVEverywhere", Code = "fox_tveverywhere" },
                new MovieSource { Id = 16, Name = "Hallmark everywhere", Code = "hallmark_everywhere" },
                new MovieSource { Id = 17, Name = "Lifetime TVEverywhere", Code = "lifetime_tveverywhere" },
                new MovieSource { Id = 18, Name = "Sundance TVEverywhere", Code = "sundance_tveverywhere" },
                new MovieSource { Id = 19, Name = "TBS", Code = "tbs" },
                new MovieSource { Id = 20, Name = "TNT", Code = "tnt" },
                new MovieSource { Id = 21, Name = "IFC", Code = "ifc" },
                new MovieSource { Id = 22, Name = "TCM", Code = "watch_tcm" },
                new MovieSource { Id = 23, Name = "Any", Code = "#any#" },
                new MovieSource { Id = 24, Name = "Free", Code = "#free#" },
                new MovieSource { Id = 25, Name = "Disney Now", Code = "disneynow" },
                new MovieSource { Id = 26, Name = "ABC TVEverywhere", Code = "abc_tveverywhere" },
                new MovieSource { Id = 27, Name = "SYFY TVEverywhere", Code = "syfy_tveverywhere" },
                new MovieSource { Id = 28, Name = "Comedy Central TVEverywhere", Code = "comedycentral_tveverywhere" },
                new MovieSource { Id = 29, Name = "DOC Club", Code = "doc_club" },
                new MovieSource { Id = 30, Name = "Sundance Now DOC Club", Code = "sundancenowdocclub" },
                new MovieSource { Id = 31, Name = "NBC TVEverywhere", Code = "nbc_tveverywhere" },
                new MovieSource {Id = 32, Name = "EPIX", Code = "epix" },
                new MovieSource {Id = 33, Name = "ABC Family", Code = "abc_family" },
                new MovieSource {Id = 34, Name = "Tribeca Shortlist", Code = "tribeca_shortlist" },
                new MovieSource {Id = 35, Name = "Indie Flix Shorts", Code = "indieflixshorts" },
                new MovieSource {Id = 36, Name = "Hallmark Movies Now", Code = "hallmark_movies_now" },
                new MovieSource {Id = 37, Name = "Monsters Nightmares", Code = "monstersnightmares" },
                new MovieSource {Id = 38, Name = "RealEYZ", Code = "realeyz" },
                new MovieSource {Id = 39, Name = "Warriors Gangsters", Code = "warriorsgangsters" }
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
