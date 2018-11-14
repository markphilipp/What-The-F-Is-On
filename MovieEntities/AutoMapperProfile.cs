using System;
using System.Reflection;
using AutoMapper;
using System.Linq;

namespace MovieEntities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
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
    }
}
