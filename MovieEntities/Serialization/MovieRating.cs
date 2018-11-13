using System;
using System.Runtime.Serialization;

namespace MovieEntities.Serialization
{
    [DataContract]
    public class MovieRating
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "content_type")]
        public string ContentType { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "imdb_rating")]
        public decimal ImdbRating { get; set; }

        [DataMember(Name = "rt_critics_rating")]
        public decimal RottenTomatoesRating { get; set; }

        [DataMember(Name = "has_poster")]
        public bool HasPoster { get; set; }

        [DataMember(Name = "has_backdrop")]
        public bool HasBackdrop { get; set; }

        [DataMember(Name = "released_on")]
        public DateTime ReleasedOn { get; set; }

        [DataMember(Name = "classification")]
        public string Classification { get; set; }

        [DataMember(Name = "sources")]
        public string[] Sources { get; set; }

        [DataMember(Name = "on_services")]
        public bool OnServices { get; set; }

        [DataMember(Name = "on_free")]
        public bool OnFree { get; set; }

        [DataMember(Name = "on_rent_purchase")]
        public bool OnRentPurchase { get; set; }

        [DataMember(Name = "watchlisted")]
        public bool Watchlisted { get; set; }

        [DataMember(Name = "seen")]
        public bool Seen { get; set; }
    }
}
