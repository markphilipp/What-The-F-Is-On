using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieEntities.Models;

namespace DataCompiler.Helpers
{
    public interface IRatingsMappingHelper
    {
        List<MovieRating> ConvertRawResultsToModels(List<MovieEntities.Serialization.MovieRating> rawResults);
    }

    public class RatingsMappingHelper : IRatingsMappingHelper
    {
        private readonly IMapper _mapper;

        public RatingsMappingHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<MovieRating> ConvertRawResultsToModels(List<MovieEntities.Serialization.MovieRating> rawResults)
        {
            // 250 was the maximum number of ratings I was able to pull from the API at a time
            var models = _mapper.Map<List<MovieRating>>(rawResults);

            // I hate this but have to set the relationship up
            foreach (var model in models.Where(m => m.RatingSources != null))
                foreach (var source in model.RatingSources.Where(rs => rs != null))
                    source.Rating = model;
            return models;
        }
    }
}