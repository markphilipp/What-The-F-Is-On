using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MovieEntities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace MovieEntities
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Trying here too
            services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movie.db", b => b.MigrationsAssembly("MovieEntities")));
            services.BuildServiceProvider();
        }

        public void Configure(IApplicationLifetime app)
        {

        }
    }
}
