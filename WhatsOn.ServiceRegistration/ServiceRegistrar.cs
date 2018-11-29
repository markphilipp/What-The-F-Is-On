using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieEntities;
using MovieEntities.Repository;

namespace WhatsOn.ServiceRegistration
{
    public class ServiceRegistrar
    {
        public void Run(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movie.db", b => b.MigrationsAssembly("MovieEntities")));
            services.AddScoped<IRepository, Repository>();

            // Initialize automapper
            services.AddAutoMapper();
        }
    }
}