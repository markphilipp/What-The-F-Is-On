﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieEntities;

namespace MovieEntities.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20181127221812_MovieSource_MoreCodesAgain")]
    partial class MovieSource_MoreCodesAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("MovieEntities.Models.MovieRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Classification");

                    b.Property<string>("ContentType");

                    b.Property<bool>("HasBackdrop");

                    b.Property<bool>("HasPoster");

                    b.Property<decimal?>("ImdbRating");

                    b.Property<bool>("OnFree");

                    b.Property<bool>("OnRentPurchase");

                    b.Property<bool>("OnServices");

                    b.Property<DateTime>("ReleasedOn");

                    b.Property<decimal?>("RottenTomatoesRating");

                    b.Property<bool>("Seen");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<bool>("Watchlisted");

                    b.HasKey("Id");

                    b.ToTable("MovieRatings");
                });

            modelBuilder.Entity("MovieEntities.Models.MovieRatingSource", b =>
                {
                    b.Property<Guid>("RatingId");

                    b.Property<int>("SourceId");

                    b.HasKey("RatingId", "SourceId");

                    b.HasIndex("SourceId");

                    b.ToTable("MovieRatingSource");
                });

            modelBuilder.Entity("MovieEntities.Models.MovieSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MovieSources");

                    b.HasData(
                        new { Id = 1, Code = "netflix", Name = "Netflix" },
                        new { Id = 2, Code = "hulu_plus", Name = "Hulu Plus" },
                        new { Id = 3, Code = "amazon_prime", Name = "Amazon Prime" },
                        new { Id = 4, Code = "hbo", Name = "HBO" },
                        new { Id = 5, Code = "showtime", Name = "Showtime" },
                        new { Id = 6, Code = "starz", Name = "Starz" },
                        new { Id = 7, Code = "mubi", Name = "Mubi" },
                        new { Id = 8, Code = "cinemax", Name = "Cinemax" },
                        new { Id = 9, Code = "cbs_all_access", Name = "CBS All Access" },
                        new { Id = 10, Code = "fandor", Name = "Fandor" },
                        new { Id = 11, Code = "acorntv", Name = "Acorntv" },
                        new { Id = 12, Code = "film_struck", Name = "Film Struck" },
                        new { Id = 13, Code = "shudder", Name = "Shudder" },
                        new { Id = 14, Code = "fx_tveverywhere", Name = "Fx TVEverywhere" },
                        new { Id = 15, Code = "fox_tveverywhere", Name = "Fox TVEverywhere" },
                        new { Id = 16, Code = "hallmark_everywhere", Name = "Hallmark everywhere" },
                        new { Id = 17, Code = "lifetime_tveverywhere", Name = "Lifetime TVEverywhere" },
                        new { Id = 18, Code = "sundance_tveverywhere", Name = "Sundance TVEverywhere" },
                        new { Id = 19, Code = "tbs", Name = "TBS" },
                        new { Id = 20, Code = "tnt", Name = "TNT" },
                        new { Id = 21, Code = "ifc", Name = "IFC" },
                        new { Id = 22, Code = "watch_tcm", Name = "TCM" },
                        new { Id = 23, Code = "#any#", Name = "Any" },
                        new { Id = 24, Code = "#free#", Name = "Free" },
                        new { Id = 25, Code = "disneynow", Name = "Disney Now" },
                        new { Id = 26, Code = "abc_tveverywhere", Name = "ABC TVEverywhere" },
                        new { Id = 27, Code = "syfy_tveverywhere", Name = "SYFY TVEverywhere" },
                        new { Id = 28, Code = "comedycentral_tveverywhere", Name = "Comedy Central TVEverywhere" },
                        new { Id = 29, Code = "doc_club", Name = "DOC Club" },
                        new { Id = 30, Code = "sundancenowdocclub", Name = "Sundance Now DOC Club" },
                        new { Id = 31, Code = "nbc_tveverywhere", Name = "NBC TVEverywhere" },
                        new { Id = 32, Code = "epix", Name = "epix" },
                        new { Id = 33, Code = "abc_family", Name = "abc_family" },
                        new { Id = 34, Code = "tribeca_shortlist", Name = "tribeca_shortlist" }
                    );
                });

            modelBuilder.Entity("MovieEntities.Models.MovieRatingSource", b =>
                {
                    b.HasOne("MovieEntities.Models.MovieRating", "Rating")
                        .WithMany("RatingSources")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieEntities.Models.MovieSource", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
