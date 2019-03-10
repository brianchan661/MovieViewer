using MovieViewer.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static MovieViewer.Models.MovieDb.MovieResponse;

namespace MovieViewer.Service
{
    public class MovieService
    {
        private readonly MovieRespository _movieRespository;
        
        public MovieService(MovieRespository movieRespository)
        {
            this._movieRespository = movieRespository;
        }

        /// <summary>
        /// Get top 10 popular movie
        /// </summary>
        /// <returns>Top 10 popular movie. If exception, return null</returns>
        public List<Movie> GetTopTenPopularMovie()
        {
            List<Movie> result = null;
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
            List<Movie> result = null;
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
