using MovieViewer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static MovieViewer.Models.MovieDb.MovieResponse;

/// <summary>
/// Respository call for Popular Movie data
/// </summary>
namespace MovieViewer.Service.Repository
{
    public class MovieRespository : IRepositoryBase<Movie>
    {
        private readonly ApplicationDbContext _context;

        public MovieRespository(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        /// <summary>
        /// Insert a list of popula movies into database.
        /// </summary>
        /// <param name="results"></param>
        public void InsertList(List<Movie> results)
        {
            try
            {
                foreach (Movie result in results)
                {
                    Movie movie = FindById(result.Id);
                    // if the movie is already in database, just update the popularity and voting
                    if (movie != null)
                    {
                        movie.Popularity = result.Popularity;
                        movie.VoteAverage = result.VoteAverage;
                        movie.VoteCount = result.VoteCount;
                        Update(movie);
                    } else
                    {
                        // else insert new movie data
                        result.InsertDate = DateTimeOffset.Now;
                        Create(result);
                    }
                    
                }
            } catch (Exception ex)
            {
                // Log and continue to insert next record
                Console.Write("failed to insert a record. " + ex.Message);
            }
            
        }

        /// <summary>
        /// Get the top 10 highest average vote from today and yesterday data.
        /// </summary>
        /// <returns></returns>
        public List<Movie> FindTopTenPopularMovie()
        {
            DateTimeOffset yesterday = DateTimeOffset.Now.Date.AddDays(-1);
            return _context.Movie.OrderByDescending(p => p.InsertDate).OrderByDescending(p => p.Popularity)
                .Where(p => p.InsertDate > yesterday).Take(10).ToList();
        }

        /// <summary>
        /// Get the top 5 highest rated overall database.
        /// </summary>
        /// <returns></returns>
        public List<Movie> FindTopFiveRatedMovie()
        {
            return _context.Movie.OrderByDescending(p => p.VoteAverage).Take(5).ToList();
        }

        /// <summary>
        /// Select Movie data based on id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Movie FindById(long key)
        {
            return _context.Movie.Where(p => p.Id == key).FirstOrDefault();
        }

        public void Create(Movie entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> FindByCondition(Expression<Func<Movie, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Movie entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
        
    }
}
