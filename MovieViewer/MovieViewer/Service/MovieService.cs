using MovieViewer.ApiClient;
using MovieViewer.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static MovieViewer.Models.MovieDb.MovieResponse;

namespace MovieViewer.Service
{
    public class MovieService : IService
    {
        private readonly MovieDbApiClient _movieDbApiClient;
        private readonly MovieRespository _movieRespository;
        
        public MovieService(MovieDbApiClient movieDbApiClient, MovieRespository movieRespository)
        {
            this._movieDbApiClient = movieDbApiClient;
            this._movieRespository = movieRespository;
        }

        /// <summary>
        /// call api to insert new movie data to database
        /// </summary>
        public void RetrievePopularMovieFormMovieDb()
        {
            _movieDbApiClient.CallApi();
        }

        /// <summary>
        /// Get the top popular movie
        /// </summary>
        /// <returns></returns>
        public Movie GetTopPopularMovie()
        {
            Movie result = new Movie();
            try
            {
                result = _movieRespository.FindTopTenPopularMovie().First();
            }
            catch (Exception ex)
            {
                Console.Write("fail to retrive popular movie. " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Get top 10 popular movie
        /// </summary>
        /// <returns>Top 10 popular movie. If exception, return null</returns>
        public List<Movie> GetTopTenPopularMovie()
        {
            List<Movie> result = new List<Movie>();
            try
            {
                result = _movieRespository.FindTopTenPopularMovie();
            }
            catch (Exception ex)
            {
                Console.Write("fail to retrive popular movie. " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Get top 5 rated movie
        /// </summary>
        /// <returns>Top 5 rated movie. If exception, return null</returns>
        public List<Movie> GetTopFiveRatedMovie()
        {
            List<Movie> result = new List<Movie>();
            try
            {
                result = _movieRespository.FindTopFiveRatedMovie();
            }
            catch (Exception ex)
            {
                Console.Write("fail to retrive rated movie. " + ex.Message);
            }
            return result;
        }

    }
}
