using System;
using Microsoft.Extensions.DependencyInjection;
using Containerization;
using DataCompiler.Helpers;
using MovieEntities.Interfaces;
using MovieEntities.Mapping;
using WhatsOn.ServiceRegistration;

namespace DataCompiler
{
    public class Startup
    {
        public void ConfigureContainer()
        {
            var services = new ServiceCollection();

            // Run shared registration methods
            new ServiceRegistrar().Run(services);

            // Custom helper registration
            services.AddScoped<IDataLoaderHelper, DataLoaderHelper>();
            services.AddScoped<IMovieSourceConverter, MovieSourceConverter>();
            services.AddScoped<IDuplicatesRatingHelper, DuplicateRatingHelper>();
            services.AddScoped<IMissingMovieSourceHelper, MissingMovieSourceHelper>();
            services.AddScoped<IRatingsMappingHelper, RatingsMappingHelper>();

            // Set the container for reference
            ConsoleContainer.Current = services.BuildServiceProvider();
        }
    }
}
