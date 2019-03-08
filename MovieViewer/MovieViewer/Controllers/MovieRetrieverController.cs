using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieViewer.ApiClient;

namespace MovieViewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRetrieverController : ControllerBase
    {

        [HttpGet]
        public StatusCodeResult getPopulatedMovie()
        {
            MovieDbApiClient client = new MovieDbApiClient();
            client.callApi();
            return StatusCode(200);
        }
    }
}