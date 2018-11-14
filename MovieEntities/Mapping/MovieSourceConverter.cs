using System;
using System.Linq;
using MovieEntities.Mapping.Interfaces;
using MovieEntities.Mapping.Models;

namespace MovieEntities.Mapping
{
    public class MovieSourceConverter : IMovieSourceConverter
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
