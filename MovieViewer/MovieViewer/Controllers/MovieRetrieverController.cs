using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieViewer.ApiClient;
using MovieViewer.Service;

/// <summary>
/// Api controller, mainly for schedule to notice application periodically retrieve new data
/// from TheMovieDb and update the database.
/// 
/// The api will be called by scheduled task.
/// </summary>
namespace MovieViewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MovieRetrieverController : ControllerBase
    {

        private readonly MovieService _movieService;

        public MovieRetrieverController(MovieService movieService)
        {
            this._movieService = movieService;
        }

        /// <summary>
        /// Call TheMovieDB's /movie/popular api and insert data to database.
        /// </summary>
        /// <returns>HTTP Status 200</returns>
        [HttpGet]
        public StatusCodeResult getPopulatedMovie()
        {
            _movieService.RetrievePopularMovieFormMovieDb();
            return StatusCode(200);
        }
    }
}