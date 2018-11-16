using System;
using System.Linq;
using MovieEntities.Interfaces;
using MovieEntities.Models;

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
            return movieContext.MovieSources.FirstOrDefault(s => s.Name == name);
        }
    }
}
