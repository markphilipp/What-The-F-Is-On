using System;
using System.Collections.Generic;
using System.Linq;
using MovieEntities;
using MovieEntities.Models;

namespace DataCompiler.Helpers
{
    public interface IDuplicatesRatingHelper
    {
        /// <summary>
        /// Clean up duplicate models
        /// </summary>
        /// <param name="models">List of moving ratings</param>
        /// <exception cref="ApplicationException">Throws an exception if too many duplicate ratings are encountered</exception>
        void CleanDuplicateRatings(List<MovieRating> models);
    }

    public class DuplicateRatingHelper : IDuplicatesRatingHelper
    {
        private readonly MovieContext _context;

        public DuplicateRatingHelper(MovieContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Clean up duplicate models
        /// </summary>
        /// <param name="models">List of moving ratings</param>
        /// <exception cref="ApplicationException">Throws an exception if too many duplicate ratings are encountered</exception>
        public void CleanDuplicateRatings(List<MovieRating> models)
        {
            var duplicateRatings = models.Where(m => _context.MovieRatings
                    .Select(mr => mr.Id)
                    .Contains(m.Id))
                .ToList();

            // Keep getting duplicates for some reason from the API so continuing unless it's incredibly high
            if (duplicateRatings.Count > 100)
                throw new ApplicationException("Too many duplicates");

            if (!duplicateRatings.Any()) return;

            // Remove duplicates from models
            Console.WriteLine($"Encountered {duplicateRatings.Count} duplicates but is under the threshhold");
            foreach (var dup in duplicateRatings)
                models.Remove(dup);
        }
    }
}