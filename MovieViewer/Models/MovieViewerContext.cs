using System;
using Microsoft.EntityFrameworkCore;

namespace MovieViewer.Models
{
    public class MovieViewerContext : DbContext
    {
        public MovieViewerContext(DbContextOptions<MovieViewerContext> options)
            : base(options)
        {
        }

        public DbSet<MovieViewer.Models.Movie> Movie { get; set; }
    }
}
