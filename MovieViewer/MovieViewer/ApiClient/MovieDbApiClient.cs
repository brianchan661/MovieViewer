using MovieViewer.Models.MovieDb;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using static MovieViewer.Models.MovieDb.Popula;

namespace MovieViewer.ApiClient
{
    public class MovieDbApiClient
    {
        private const string BASE_URL = "https://api.themoviedb.org/3/search/movie";
        private const string API_KEY = "?api_key=d1efd6fa1828aed23dc8d8d24120cd7d";


        public void callApi()
        {
            var client = new RestClient("https://api.themoviedb.org/3/movie/popular?page=1&language=en-US&api_key=d1efd6fa1828aed23dc8d8d24120cd7d");
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var model = JsonConvert.DeserializeObject<Popula.FullResult>(content);

            Console.Write(content);
        }
    }
}
