using MovieViewer.Models.MovieDb;
using MovieViewer.Service.Repository;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using static MovieViewer.Models.MovieDb.Popular;

/// <summary>
/// API client for calling TheMovieDb apis.
/// <seealso cref="https://developers.themoviedb.org/3/getting-started/introduction"/>
/// </summary>
namespace MovieViewer.ApiClient
{
    public class MovieDbApiClient
    {
        private readonly MovieRespository _movieRespository;

        private const string BASE_URL = "https://api.themoviedb.org/3";
        private const string API_KEY = "?api_key=d1efd6fa1828aed23dc8d8d24120cd7d";

        private const string POPULAR_PATH = "/movie/popular";

        public MovieDbApiClient(MovieRespository movieRespository)
        {
            this._movieRespository = movieRespository;
        }

        public void CallApi()
        {
            string parameter = "&page=1&language=en-US";
            string endpoint = BASE_URL + POPULAR_PATH  + API_KEY + parameter;
            var client = new RestClient(endpoint);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            ResultList model = JsonConvert.DeserializeObject<ResultList>(content);
            _movieRespository.InsertList(model.Results);


            Console.Write(content);
        }
    }
}
