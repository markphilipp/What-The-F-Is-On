using System;
using System.Collections.Generic;

namespace MovieEntities.Models
{
    public class MovieRatingSource
    {
        public Guid RatingId { get; set; }
        public MovieRating Rating { get; set; }

        public int SourceId { get; set; }
        public MovieSource Source { get; set; }
    }
}
