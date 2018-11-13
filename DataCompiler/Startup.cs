using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MovieEntities;

namespace DataCompiler
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movie.db"));
            services.BuildServiceProvider();
        }

        public void Configure()
        {
            ConfigureServices(new ServiceCollection());
        }
    }
}
