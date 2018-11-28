using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using DataCompiler.Interfaces;
using MovieEntities;
using MovieEntities.Models;
using Newtonsoft.Json;

namespace DataCompiler.Services
{
    public class DataLoader : IDataLoader
    {
        const string UrlTemplate = @"https://api.reelgood.com/v2/browse/filtered?availability=onAnySource&content_kind=movie&hide_seen=false&hide_tracked=false&hide_watchlisted=false&imdb_end=10&imdb_start=0&rt_end=100&rt_start=0&skip={0}&sort=0&take=250&year_end=2018&year_start=1980";
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public DataLoader(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                GetResultSet(i * 250);
            }
        }

        private void GetResultSet(int start)
        {
            Console.WriteLine($"Getting records {start} to {start + 250}");
            var requestUrl = String.Format(UrlTemplate, start);

            // Just testing the method
            var rawResults = GetResult(requestUrl).Result;

            var uniqueCodes = rawResults.SelectMany(r => r.Sources).Distinct();
            var missingCodes = uniqueCodes.Where(u => !_context
                    .MovieSources
                    .Select(s => s.Code)
                    .Contains(u))
                    .ToList();

            if (rawResults.Count < 250)
                Debugger.Break();

            if (missingCodes.Any())
            {
                Console.WriteLine($"Adding ${missingCodes.Count} missing codes");
                AddMissingCodes(missingCodes);
            }

            var models = _mapper.Map<List<MovieRating>>(rawResults);

            // I hate this but have to set the relationship up
            foreach(var model in models.Where(m => m.RatingSources != null))
                foreach(var source in model.RatingSources.Where(rs => rs != null))
                    source.Rating = model;

            // For some reason getting duplicates, so am cleaning them below a certain threshold
            CleanDuplicates(models);

            _context.AddRange(models);
            _context.SaveChanges();
        }

        private void CleanDuplicates(List<MovieRating> models)
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

        private void AddMissingCodes(List<string> missingCodes)
        {
            foreach (var code in missingCodes)
            {
                _context.Add(new MovieSource()
                {
                    Name = code,
                    Code = code
                });
            }

            _context.SaveChanges();
        }

        private static async Task<List<MovieEntities.Serialization.MovieRating>> GetResult(string requestUrl)
        {
            var client = new HttpClient();
            var deserializer = new JsonSerializer();

            var streamResult = client.GetStreamAsync(requestUrl);
            using (var responseRead = new JsonTextReader(new StreamReader(await streamResult)))
                return deserializer.Deserialize<List<MovieEntities.Serialization.MovieRating>>(responseRead);
        }
    }
}
