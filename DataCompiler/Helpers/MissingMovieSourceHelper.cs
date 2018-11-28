using System;
using System.Collections.Generic;
using System.Linq;
using MovieEntities;
using MovieEntities.Models;
using MovieEntities.Repository;

namespace DataCompiler.Helpers
{
    public interface IMissingMovieSourceHelper
    {
        /// <summary>
        /// Adds missing movie sources from raw result that aren't already stored
        /// </summary>
        /// <param name="rawResults">List of deserialized models</param>
        void AddMissingMovieSources(IEnumerable<MovieEntities.Serialization.MovieRating> rawResults);
    }

    public class MissingMovieSourceHelper : IMissingMovieSourceHelper
    {
        private readonly IRepository _repository;

        public MissingMovieSourceHelper(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds missing movie sources from raw result that aren't already stored
        /// </summary>
        /// <param name="rawResults">List of deserialized models</param>
        public void AddMissingMovieSources(IEnumerable<MovieEntities.Serialization.MovieRating> rawResults)
        {
            var uniqueCodes = rawResults.SelectMany(r => r.Sources).Distinct();
            var missingCodes = uniqueCodes.Where(u => !_repository
                    .Set<MovieSource>()
                    .Select(s => s.Code)
                    .Contains(u))
                .ToList();

            // Just exit if we already have all the sources saved
            if (!missingCodes.Any()) return;

            Console.WriteLine($"Adding ${missingCodes.Count} missing codes");

            _repository.AddRange(missingCodes.Select(code => new MovieSource { Name = code, Code = code }));
            _repository.Save();
        }
    }
}