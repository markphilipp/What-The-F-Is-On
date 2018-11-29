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
            if (!source.Any()) throw new InvalidOperationException("No items in the list");

            return source.OrderBy(_ => Guid.NewGuid())
                .First();
        }

        /// <summary>
        /// Picks a random item from the IEnumerable that is not in the list of items to exclude
        /// </summary>
        public static T PickRandomNotIn<T>(this IEnumerable<T> source, params T[] excludes) => MatchUntil(source, s => !excludes.Contains(s));

        /// <summary>
        /// Picks a random item from the IEnumerable that doesn't match the predicate
        /// </summary>
        public static T PickRandomNotMatching<T>(this IEnumerable<T> source, Predicate<T> match) => MatchUntil(source, s => !match(s));

        public static IEnumerable<T> PickRandomSet<T>(this IEnumerable<T> source, int numOfItems)
        {
            if (numOfItems > source.Count()) throw new InvalidOperationException("Number of items in the list is less than the number of items requested");

            return source
                .OrderBy(s => Guid.NewGuid())
                .Take(numOfItems);
        }

        /// <summary>
        /// Helper method to find a
        /// </summary>
        private static T MatchUntil<T>(IEnumerable<T> source, Predicate<T> match)
        {
            // If there aren't any besides the excludes list, throw informative error
            if (source.All(s => !match(s))) throw new InvalidOperationException("No items available in list that are not excluded");

            // Pick until we get one not in the list
            var randomPick = source.PickRandom();
            while (!match(randomPick))
                randomPick = source.PickRandom();

            return randomPick;
        }
    }
}