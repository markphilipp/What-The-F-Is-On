using System;
using System.Linq;
using MovieEntities.Models;

namespace MovieEntities.Converters
{
    public class MovieSourceConverter
    {
        private readonly MovieContext movieContext;

        public MovieSourceConverter(MovieContext movieContext)
        {
            this.movieContext = movieContext;
        }

        public MovieSource GetSourceFromName(string name)
        {
            return movieContext.Sources.FirstOrDefault(s => s.Name == name);
        }
    }
}
