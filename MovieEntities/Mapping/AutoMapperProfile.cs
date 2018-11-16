using System;
using System.Reflection;
using AutoMapper;
using System.Linq;
using MovieEntities.Models;
using Containerization;
using MovieEntities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MovieEntities.Mapping
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
            var currentAssembly      = Assembly.GetAssembly(this.GetType());
            var serializationClasses = GetTypesStartingWithNamespace(currentAssembly, "MovieEntities.Serialization");
            var modelClasses         = GetTypesStartingWithNamespace(currentAssembly, "MovieEntities.Models");

            foreach (var serializationClass in serializationClasses)
            {
                var modelClassMatch = modelClasses.FirstOrDefault(n => n.Name == serializationClass.Name);

                // Skip anything that doesn't match
                // TODO: should we log out a warning on non-matches?
                if (modelClassMatch == null) continue;

                CreateMap(serializationClass, modelClassMatch);
            }
        }

        private void AddCustomMappings()
        {
            CreateMap<string, MovieRatingSource>()
                .ConvertUsing((str) => 
                {
                    var context = ConsoleContainer.Current.GetService<IMovieSourceConverter>();
                    return context.CreateSourceFromName(str);
                });
        }

        private IEnumerable<Type> GetTypesStartingWithNamespace(Assembly assembly, string nspace)
        {
            return assembly
                .GetTypes()
                .Where(c => c.Namespace != null && c.Namespace.StartsWith(nspace, StringComparison.Ordinal));
        }
    }
}
