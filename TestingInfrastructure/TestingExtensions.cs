using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingInfrastructure
{
    public static class TestingExtensions
    {
        /// <summary>
        /// Picks a random item from the IEnumerable
        /// </summary>
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            // avoid multiple iterations of IEnumberable
            var sourceList = source as T[] ?? source.ToArray();

            if (!sourceList.Any()) throw new InvalidOperationException("No items in the list");

            return sourceList.OrderBy(_ => Guid.NewGuid())
                .Single();
        }

        /// <summary>
        /// Picks a random item from the IEnumerable that is not in the list of items to exclude
        /// </summary>
        public static T PickRandomNotIn<T>(this IEnumerable<T> source, params T[] excludes) => MatchUntil(source, s => !excludes.Contains(s));

        /// <summary>
        /// Picks a random item from the IEnumerable that doesn't match the predicate
        /// </summary>
        public static T PickRandomNotMatching<T>(this IEnumerable<T> source, Predicate<T> match) => MatchUntil(source, s => !match(s));

        /// <summary>
        /// Helper method to find a
        /// </summary>
        private static T MatchUntil<T>(IEnumerable<T> source, Predicate<T> match)
        {
            // avoid multiple iterations of IEnumberable
            var sourceList = source as T[] ?? source.ToArray();

            // If there aren't any besides the excludes list, throw informative error
            if (sourceList.All(s => !match(s))) throw new InvalidOperationException("No items available in list that are not excluded");

            // Pick until we get one not in the list
            var randomPick = sourceList.PickRandom();
            while (match(randomPick))
                randomPick = sourceList.PickRandom();

            return randomPick;
        }
    }
}