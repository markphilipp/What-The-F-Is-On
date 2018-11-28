using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using MovieEntities;
using MovieEntities.Models;
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
        private readonly IMapper _mapper;
        private readonly MovieContext _context;
        private readonly IMissingMovieSourceHelper _missingMovieSourceHelper;
        private readonly IDuplicateRatingHelper _duplicateRatingHelper;

        public DataLoaderHelper(IMapper mapper, MovieContext context, IMissingMovieSourceHelper missingMovieSourceHelper, IDuplicateRatingHelper duplicateRatingHelper)
        {
            _mapper = mapper;
            _context = context;
            _missingMovieSourceHelper = missingMovieSourceHelper;
            _duplicateRatingHelper = duplicateRatingHelper;
        }

        /// <summary>
        /// Entry method to perform the data loading
        /// </summary>
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                SaveMovieRatings(i * 250);
            }
        }

        /// <summary>
        /// Retries and saves a set of movie ratings
        /// </summary>
        /// <param name="start">The starting index to retrieve</param>
        private void SaveMovieRatings(int start)
        {
            var rawResults = GetRawMovieRatingsResult(start);

            _missingMovieSourceHelper.AddMissingMovieSources(rawResults);

            var models = ConvertRawResultsToModels(rawResults);

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

        private List<MovieRating> ConvertRawResultsToModels(List<MovieEntities.Serialization.MovieRating> rawResults)
        {
            // 250 was the maximum number of ratings I was able to pull from the API at a time
            var models = _mapper.Map<List<MovieRating>>(rawResults);

            // I hate this but have to set the relationship up
            foreach (var model in models.Where(m => m.RatingSources != null))
                foreach (var source in model.RatingSources.Where(rs => rs != null))
                    source.Rating = model;
            return models;
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
