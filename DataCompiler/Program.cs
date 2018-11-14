using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using MovieEntities.Serialization;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MovieEntities;

namespace DataCompiler
{
    class Program
    {
        const string urlTemplate = @"https://api.reelgood.com/v2/browse/source/netflix?availability=onSources&content_kind=both&hide_seen=false&hide_tracked=false&hide_watchlisted=false&imdb_end={0}&imdb_start={1}&override_user_sources=true&overriding_free=false&overriding_sources=netflix&rt_end=100&rt_start=0&skip=50&sort=0&sources=netflix&take=50&year_end=2018&year_start=1970";

        static void Main(string[] args)
        {
            // Call the startup class config methods
            BuildWebHost(args).Run();

            // Just testing the method
            var r = GetResult().Result;
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static async Task<List<MovieEntities.Serialization.MovieRating>> GetResult()
        {
            var client = new HttpClient()
            {
                //BaseAddress = new Uri(String.Format(urlTemplate, i * 100, (i + 1) * 100 - 1))
            };
            var deserializer = new JsonSerializer();

            var url = String.Format(urlTemplate, 101, 1);

            var streamResult = client.GetStreamAsync(url);
            using (var responseRead = new JsonTextReader(new StreamReader(await streamResult)))
                return deserializer.Deserialize<List<MovieEntities.Serialization.MovieRating>>(responseRead);
        }
    }
}
