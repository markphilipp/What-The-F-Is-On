using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Containerization;
using DataCompiler.Helpers;
using MovieEntities;
using MovieEntities.Interfaces;
using MovieEntities.Mapping;

namespace DataCompiler
{
    public class Startup
    {
        public void ConfigureContainer()
        {
            var services = new ServiceCollection();

            // Trying here too
            services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movie.db", b => b.MigrationsAssembly("MovieEntities")));

            // Initialize automapper
            services.AddAutoMapper();

            services.AddScoped<IDataLoaderHelper, DataLoaderHelper>();
            services.AddScoped<IMovieSourceConverter, MovieSourceConverter>();
            services.AddScoped<IDuplicateRatingHelper, DuplicateRatingHelper>();
            services.AddScoped<IMissingMovieSourceHelper, MissingMovieSourceHelper>();
            services.AddScoped<IRatingsMappingHelper, RatingsMappingHelper>();

            // Set the container for reference
            ConsoleContainer.Current = services.BuildServiceProvider();
        }
    }
}
