using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieViewer.Models;
using MovieViewer.Service;

/// <summary>
/// Home page controller
/// </summary>
namespace MovieViewer.Controllers
{
    public class HomeController : Controller
    {

        private readonly MovieService _movieService;

        public HomeController(MovieService movieService)
        {
            this._movieService = movieService;
        }

        /// <summary>
        /// Homw page of Movie Viewer
        /// Show the top popular movie for recommenation
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            Models.MovieDb.MovieResponse.Movie todayTopMovie = _movieService.GetTopPopularMovie();
            return View(todayTopMovie);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
