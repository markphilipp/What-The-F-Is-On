using System;
using System.Collections.Generic;

namespace MovieEntities.Models
{
    public class MovieRating
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
        public decimal? ImdbRating { get; set; }
        public decimal? RottenTomatoesRating { get; set; }
        public bool HasPoster { get; set; }
        public bool HasBackdrop { get; set; }
        public DateTime ReleasedOn { get; set; }
        public string Classification { get; set; }
        public List<MovieSource> Sources { get; set; }
        public bool OnServices { get; set; }
        public bool OnFree { get; set; }
        public bool OnRentPurchase { get; set; }
        public bool Watchlisted { get; set; }
        public bool Seen { get; set; }
    }
}
