using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingInfrastructure
{
    public static class TestingExtensions
    {
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(_ => Guid.NewGuid())
                .Single();
        }
    }
}