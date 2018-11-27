using System;
using System.IO;
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

        public MovieRatingSource CreateSourceFromName(string code)
        {
            var source = _movieContext.MovieSources.FirstOrDefault(s => s.Code == code);

            if (source == null) throw new InvalidDataException($"Could not find a MovieSource record with code {code}. Make sure that the MovieContext has a record in OnModelCreating.");

            return new MovieRatingSource()
            {
                Source = source
            };
        }
    }
}
