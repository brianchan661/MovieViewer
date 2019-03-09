using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Model class for TheMovieDb's popula API
/// The data is updated daily in TheMobieDb's server,
/// so an extra field insertDate is added for specifying the date of popula
/// <seealso cref="https://developers.themoviedb.org/3/movies/get-popular-movies"/>
/// </summary>
namespace MovieViewer.Models.MovieDb
{
    public class Popula
    {
        public partial class ResultList
        {
            public List<PopularMovie> Results { get; set; }
        }

        public partial class PopularMovie : Entity
        {
            [Key, Column(Order = 1)]
            [JsonProperty("id")]
            public long Id { get; set; }

            [Column(Order = 2)]
            [JsonProperty("title")]
            public string Title { get; set; }

            [Column(Order = 3)]
            [JsonProperty("overview")]
            public string Overview { get; set; }

            [Column(Order = 4)]
            [JsonProperty("popularity")]
            public double Popularity { get; set; }

            [Column(Order = 5)]
            [JsonProperty("poster_path")]
            public string PosterPath { get; set; }

            [Column(Order = 6)]
            [JsonProperty("adult")]
            public bool Adult { get; set; }

            [Column(Order = 7)]
            [JsonProperty("release_date")]
            public DateTimeOffset ReleaseDate { get; set; }

            [Column(Order = 8)]
            [JsonProperty("original_title")]
            public string OriginalTitle { get; set; }

            [Column(Order = 9)]
            [JsonProperty("original_language")]
            public string OriginalLanguage { get; set; }

            [Column(Order = 10)]
            [JsonProperty("backdrop_path")]
            public string BackdropPath { get; set; }

            [Column(Order = 11)]
            [JsonProperty("vote_count")]
            public long VoteCount { get; set; }

            [Column(Order = 12)]
            [JsonProperty("video")]
            public bool Video { get; set; }

            [Column(Order = 13)]
            [JsonProperty("vote_average")]
            public double VoteAverage { get; set; }

            [Column(Order = 14)]
            public DateTimeOffset insertDate { get; set; }
        }

    }
}
