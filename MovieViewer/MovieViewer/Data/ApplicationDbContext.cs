using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieViewer.Models;

namespace MovieViewer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieViewer.Models.Movie> Movie { get; set; }
        public DbSet<MovieViewer.Models.MovieDb.Popula.PopularMovie> PopulaResult { get; set; }

    }
}
