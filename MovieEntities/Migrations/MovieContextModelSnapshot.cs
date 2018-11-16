﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieEntities;

namespace MovieEntities.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("MovieEntities.Models.MovieSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MovieRatingId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MovieRatingId");

                    b.ToTable("MovieSources");

                    b.HasData(
                        new { Id = 1, Name = "Netflix" },
                        new { Id = 2, Name = "Hulu Plus" },
                        new { Id = 3, Name = "Amazon Prime" }
                    );
                });

            modelBuilder.Entity("MovieEntities.Models.MovieSource", b =>
                {
                    b.HasOne("MovieEntities.Models.MovieRating")
                        .WithMany("Sources")
                        .HasForeignKey("MovieRatingId");
                });
#pragma warning restore 612, 618
        }
    }
}
