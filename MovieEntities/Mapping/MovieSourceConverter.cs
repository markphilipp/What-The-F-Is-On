using System;
using System.Linq;
using MovieEntities.Interfaces;
using MovieEntities.Models;

namespace MovieEntities.Mapping
{
    public class MovieSourceConverter : IMovieSourceConverter
    {
        private readonly MovieContext _movieContext;

        public MovieSourceConverter(MovieContext movieContext)
        {
            this._movieContext = movieContext;
        }

        public MovieRatingSource CreateSourceFromName(string name)
        {
            var source = _movieContext.MovieSources.FirstOrDefault(s => s.Name == name);

            return new MovieRatingSource()
            {
                Source = source
            };
        }
    }
}
