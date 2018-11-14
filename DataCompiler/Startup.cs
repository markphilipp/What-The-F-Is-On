using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MovieEntities;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

namespace DataCompiler
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Trying here too
            services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movie.db", b => b.MigrationsAssembly("MovieEntities")));

            services.AddAutoMapper();

            services.BuildServiceProvider();
        }

        public void Configure(IApplicationLifetime app)
        {
        }
    }
}
