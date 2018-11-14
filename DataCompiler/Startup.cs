using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MovieEntities;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using DataCompiler.Interfaces;
using DataCompiler.Services;
using DataCompiler.Containerization;

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

            services.AddScoped<IDataLoader, DataLoader>();

            // Set the container for reference
            ConsoleContainer.Current = services.BuildServiceProvider();
        }
    }
}
