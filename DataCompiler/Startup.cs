using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DataCompiler.Interfaces;
using DataCompiler.Services;
using Containerization;
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

            services.AddScoped<IDataLoader, DataLoaderHelper>();
            services.AddScoped<IMovieSourceConverter, MovieSourceConverter>();

            // Set the container for reference
            ConsoleContainer.Current = services.BuildServiceProvider();
        }
    }
}
