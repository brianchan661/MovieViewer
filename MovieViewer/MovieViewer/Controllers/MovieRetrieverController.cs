using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieViewer.ApiClient;

/// <summary>
/// Api controller, mainly for schedule to notice application periodically retrieve new data
/// from TheMovieDb and update the database.
/// 
/// The api will be called by batch.
/// </summary>
namespace MovieViewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRetrieverController : ControllerBase
    {

        private readonly MovieDbApiClient _movieDbApiClient;

        public MovieRetrieverController(MovieDbApiClient movieDbApiClient)
        {
            this._movieDbApiClient = movieDbApiClient;
        }

        /// <summary>
        /// Call TheMovieDB's /movie/popular api and insert data to database.
        /// </summary>
        /// <returns>HTTP Status 200</returns>
        [HttpGet]
        public StatusCodeResult getPopulatedMovie()
        {
            _movieDbApiClient.CallApi();
            return StatusCode(200);
        }
    }
}