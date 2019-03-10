using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieViewer.Service.Repository;
using static MovieViewer.Models.MovieDb.Popular;

namespace MovieViewer.Controllers
{
    [Authorize]
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

        /// <summary>
        /// get top 10 popular movie and show on page.
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult Popular()
        {
            List<PopularMovie> result = _movieRespository.FindTopTenPopularMovie();
            return View(result);
        }

        /// <summary>
        /// get top 5 popular movie and show on page.
        /// </summary>
        /// <returns></returns>
        public IActionResult TopRate()
        {
            List<PopularMovie> result = _movieRespository.FindTopFiveRatedMovie();
            return View(result);
        }
    }
}