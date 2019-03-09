using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieViewer.Service.Repository;
using static MovieViewer.Models.MovieDb.Popular;

namespace MovieViewer.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRespository _movieRespository;

        public MovieController(MovieRespository movieRespository)
        {
            this._movieRespository = movieRespository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Popular()
        {
            ViewData["Message"] = "Your application description page.";
            List<PopularMovie> result = _movieRespository.FindTopTenPopularMovie();
            return View(result);
        }
    }
}