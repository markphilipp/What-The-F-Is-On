using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using DataCompiler.Interfaces;
using MovieEntities.Models;
using Newtonsoft.Json;

namespace DataCompiler.Services
{
    public class DataLoader : IDataLoader
    {
        const string UrlTemplate = @"https://api.reelgood.com/v2/browse/source/netflix?availability=onSources&content_kind=both&hide_seen=false&hide_tracked=false&hide_watchlisted=false&imdb_start={1}&imdb_end={0}&override_user_sources=true&overriding_free=false&overriding_sources=netflix&rt_end=100&rt_start=0&skip=50&sort=0&sources=netflix&take=50&year_end=2018&year_start=1970";
        private readonly IMapper _mapper;

        public DataLoader(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Run()
        {
            // Just testing the method
            var rawResults = GetResult().Result;

            var models = _mapper.Map<List<MovieRating>>(rawResults);
            System.Diagnostics.Debugger.Log(1, "Debug", models.ToString());
        }

        private static async Task<List<MovieEntities.Serialization.MovieRating>> GetResult()
        {
            var client = new HttpClient();
            var deserializer = new JsonSerializer();

            var url = String.Format(UrlTemplate, 101, 1);

            var streamResult = client.GetStreamAsync(url);
            using (var responseRead = new JsonTextReader(new StreamReader(await streamResult)))
                return deserializer.Deserialize<List<MovieEntities.Serialization.MovieRating>>(responseRead);
        }
    }
}
