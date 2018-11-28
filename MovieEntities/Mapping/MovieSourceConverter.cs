using System;
using System.IO;
using System.Linq;
using MovieEntities.Interfaces;
using MovieEntities.Models;
using MovieEntities.Repository;

namespace MovieEntities.Mapping
{
    public class MovieSourceConverter : IMovieSourceConverter
    {
        private readonly IRepository _repository;

        public MovieSourceConverter(IRepository repository)
        {
            this._repository = repository;
        }

        public MovieRatingSource CreateSourceFromName(string code)
        {
            var source = _repository.Set<MovieSource>().FirstOrDefault(s => s.Code == code);

            if (source == null) throw new InvalidDataException($"Could not find a MovieSource record with code {code}. Make sure that the MovieContext has a record in OnModelCreating.");

            return new MovieRatingSource()
            {
                Source = source
            };
        }
    }
}
