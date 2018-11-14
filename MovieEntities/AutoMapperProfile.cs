using System;
using System.Reflection;
using AutoMapper;
using System.Linq;
using MovieEntities.Models;
using Containerization;
using MovieEntities.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MovieEntities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMapsViaReflection();
            AddCustomMappings();
        }

        private void CreateMapsViaReflection()
        {
            var serializationClasses = Assembly.GetAssembly(this.GetType())
                     .GetTypes()
                     .Where(c => c.Namespace.StartsWith("MovieEntities.Serialization", StringComparison.Ordinal));

            var modelClasses = Assembly.GetAssembly(this.GetType())
                     .GetTypes()
                     .Where(c => c.Namespace.StartsWith("MovieEntities.Serialization", StringComparison.Ordinal));

            foreach (var serializationClass in serializationClasses)
            {
                var modelClassMatch = modelClasses.FirstOrDefault(n => n.Name == serializationClass.Name);

                if (modelClasses == null) continue;

                CreateMap(serializationClass, modelClassMatch);
            }
        }

        private void AddCustomMappings()
        {
            CreateMap<string, MovieSource>()
                .ConvertUsing((str) => 
                {
                    var context = ConsoleContainer.Current.GetService<IMovieSourceConverter>();
                    return context.GetSourceFromName(str);
                });
        }
    }
}
