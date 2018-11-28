using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MovieEntities;
using Newtonsoft.Json;

namespace DataCompiler.Helpers
{
    public interface IDataLoaderHelper
    {
        void Run();
    }

    public class DataLoaderHelper : IDataLoaderHelper
    {
        const string UrlTemplate = @"https://api.reelgood.com/v2/browse/filtered?availability=onAnySource&content_kind=movie&hide_seen=false&hide_tracked=false&hide_watchlisted=false&imdb_end=10&imdb_start=0&rt_end=100&rt_start=0&skip={0}&sort=0&take=250&year_end=2018&year_start=1980";
        private readonly MovieContext _context;
        private readonly IMissingMovieSourceHelper _missingMovieSourceHelper;
        private readonly IDuplicatesRatingHelper _duplicateRatingHelper;
        private readonly IRatingsMappingHelper _ratingsMappingHelper;

        public DataLoaderHelper(MovieContext context, IMissingMovieSourceHelper missingMovieSourceHelper, IDuplicatesRatingHelper duplicateRatingHelper, IRatingsMappingHelper ratingsMappingHelper)
        {
            _context = context;
            _missingMovieSourceHelper = missingMovieSourceHelper;
            _duplicateRatingHelper = duplicateRatingHelper;
            _ratingsMappingHelper = ratingsMappingHelper;
        }

        /// <summary>
        /// Entry method to perform the data loading
        /// </summary>
        public void Run()
        {
            for (var i = 0; i < 100; i++)
                SaveMovieRatings(i * 250);
        }

        /// <summary>
        /// Retries and saves a set of movie ratings
        /// </summary>
        /// <param name="start">The starting index to retrieve</param>
        private void SaveMovieRatings(int start)
        {
            var rawResults = GetRawMovieRatingsResult(start);

            _missingMovieSourceHelper.AddMissingMovieSources(rawResults);

            var models = _ratingsMappingHelper.ConvertRawResultsToModels(rawResults);

            // For some reason getting duplicates, so am cleaning them below a certain threshold
            _duplicateRatingHelper.CleanDuplicateRatings(models);

            _context.AddRange(models);
            _context.SaveChanges();
        }

        private static List<MovieEntities.Serialization.MovieRating> GetRawMovieRatingsResult(int start)
        {
            Console.WriteLine($"Getting records {start} to {start + 250}");
            var requestUrl = String.Format(UrlTemplate, start);

            // Just testing the method
            var rawResults = GetApiResults(requestUrl).Result;

            if (rawResults.Count < 250)
                Debugger.Break();
            return rawResults;
        }

        /// <summary>
        /// Hits the All Flicks API to get a list of movie ratings
        /// </summary>
        /// <param name="requestUrl">The url to hit</param>
        /// <returns>Deserialized list of movie ratings</returns>
        private static async Task<List<MovieEntities.Serialization.MovieRating>> GetApiResults(string requestUrl)
        {
            var client = new HttpClient();
            var deserializer = new JsonSerializer();

            var streamResult = client.GetStreamAsync(requestUrl);
            using (var responseRead = new JsonTextReader(new StreamReader(await streamResult)))
                return deserializer.Deserialize<List<MovieEntities.Serialization.MovieRating>>(responseRead);
        }
    }
}
