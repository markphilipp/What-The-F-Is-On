using System;
using System.Collections.Generic;
using System.Linq;
using MovieEntities;
using MovieEntities.Models;

namespace DataCompiler.Helpers
{
    public interface IDuplicateRatingHelper
    {
        /// <summary>
        /// Clean up duplicate models
        /// </summary>
        /// <param name="models">List of moving ratings</param>
        /// <exception cref="ApplicationException">Throws an exception if too many duplicate ratings are encountered</exception>
        void CleanDuplicateRatings(List<MovieRating> models);
    }

    public class DuplicateRatingHelper : IDuplicateRatingHelper
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

            if (duplicateRatings.Count > 10)
            {
                throw new ApplicationException("Too many duplicates");
            }

            if (duplicateRatings.Any())
            {
                Console.WriteLine($"Encountered {duplicateRatings.Count} duplicates but is under the threshhold");
                foreach (var dup in duplicateRatings)
                {
                    models.Remove(dup);
                }
            }
        }
    }
}