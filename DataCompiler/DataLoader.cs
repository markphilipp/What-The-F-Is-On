using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MovieEntities.Models;
using Newtonsoft.Json;

namespace DataCompiler
{
    public class DataLoader
    {
        const string urlTemplate = @"https://api.reelgood.com/v2/browse/source/netflix?availability=onSources&content_kind=both&hide_seen=false&hide_tracked=false&hide_watchlisted=false&imdb_start={1}&imdb_end={0}&override_user_sources=true&overriding_free=false&overriding_sources=netflix&rt_end=100&rt_start=0&skip=50&sort=0&sources=netflix&take=50&year_end=2018&year_start=1970";

        internal void Run()
        {
            // Just testing the method
            var r = GetResult().Result;
        }

        private static async Task<List<MovieRating>> GetResult()
        {
            var client = new HttpClient();
            var deserializer = new JsonSerializer();

            var url = String.Format(urlTemplate, 101, 1);

            var streamResult = client.GetStreamAsync(url);
            using (var responseRead = new JsonTextReader(new StreamReader(await streamResult)))
                return deserializer.Deserialize<List<MovieRating>>(responseRead);
        }
    }
}
