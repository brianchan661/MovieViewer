using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieViewer.Models.MovieDb
{
    public class Popula
    {
        public partial class FullResult
        {
            public long Page { get; set; }
            public List<Result> Results { get; set; }
            public long TotalResults { get; set; }
            public long TotalPages { get; set; }
        }

        public partial class Result
        {
            public string PosterPath { get; set; }
            public bool Adult { get; set; }
            public string Overview { get; set; }
            public DateTimeOffset ReleaseDate { get; set; }
            public long Id { get; set; }
            public string OriginalTitle { get; set; }
            public OriginalLanguage OriginalLanguage { get; set; }
            public string Title { get; set; }
            public string BackdropPath { get; set; }
            public double Popularity { get; set; }
            public long VoteCount { get; set; }
            public bool Video { get; set; }
            public double VoteAverage { get; set; }
        }

        public enum OriginalLanguage { En };

    }
}
