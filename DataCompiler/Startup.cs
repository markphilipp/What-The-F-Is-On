using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MovieEntities;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using DataCompiler.Interfaces;
using DataCompiler.Services;

namespace DataCompiler
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Trying here too
            services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movie.db", b => b.MigrationsAssembly("MovieEntities")));

            // Initialize automapper
            services.AddAutoMapper();

            services.AddScoped<IDataLoader, DataLoader>();

            services.BuildServiceProvider();
        }

        public void Configure(IApplicationLifetime app)
        { }
    }
}
