using System;
using MovieEntities.Mapping;
using Newtonsoft.Json;

namespace MovieEntities.Serialization
{
    public class MovieRating
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "imdb_rating")]
        public decimal? ImdbRating { get; set; }

        [JsonProperty(PropertyName = "rt_critics_rating")]
        public decimal? RottenTomatoesRating { get; set; }

        [JsonProperty(PropertyName = "has_poster")]
        public bool HasPoster { get; set; }

        [JsonProperty(PropertyName = "has_backdrop")]
        public bool HasBackdrop { get; set; }

        [JsonProperty(PropertyName = "released_on")]
        public DateTime ReleasedOn { get; set; }

        [JsonProperty(PropertyName = "classification")]
        public string Classification { get; set; }

        [JsonProperty(PropertyName = "sources")]
        [AutomapAttribute(typeof(Models.MovieRating), "RatingSources")]
        public string[] Sources { get; set; }

        [JsonProperty(PropertyName = "on_services")]
        public bool OnServices { get; set; }

        [JsonProperty(PropertyName = "on_free")]
        public bool OnFree { get; set; }

        [JsonProperty(PropertyName = "on_rent_purchase")]
        public bool OnRentPurchase { get; set; }

        [JsonProperty(PropertyName = "watchlisted")]
        public bool Watchlisted { get; set; }

        [JsonProperty(PropertyName = "seen")]
        public bool Seen { get; set; }
    }
}
