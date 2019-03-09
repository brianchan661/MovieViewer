using Microsoft.EntityFrameworkCore;
using MovieViewer.Data;
using MovieViewer.Models.MovieDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static MovieViewer.Models.MovieDb.Popular;

/// <summary>
/// Respository call for Popular Movie data
/// </summary>
namespace MovieViewer.Service.Repository
{
    public class MovieRespository : IRepositoryBase<PopularMovie>
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
        public void InsertList(List<PopularMovie> results)
        {
            try
            {
                foreach (PopularMovie result in results)
                {
                    PopularMovie movie = FindById(result.Id);
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
            }
            
        }

        /// <summary>
        /// Get the top 10 highest average vote from today and yesterday data.
        /// </summary>
        /// <returns></returns>
        public List<PopularMovie> FindTopTenPopularMovie()
        {
            DateTimeOffset yesterday = DateTimeOffset.Now.Date.AddDays(-1);
            return _context.PopulaResult.OrderByDescending(p => p.InsertDate).OrderBy(p => p.Popularity)
                .Where(p => p.InsertDate > yesterday).Take(10).ToList();
        }

        /// <summary>
        /// Get the top 5 highest rated overall database.
        /// </summary>
        /// <returns></returns>
        public List<PopularMovie> FindTopFiveRatedMovie()
        {
            return _context.PopulaResult.OrderByDescending(p => p.VoteAverage).Take(5).ToList();
        }

        /// <summary>
        /// Select Movie data based on id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public PopularMovie FindById(long key)
        {
            return _context.PopulaResult.Where(p => p.Id == key).First();
        }

        public void Create(PopularMovie entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(PopularMovie entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PopularMovie> FindByCondition(Expression<Func<PopularMovie, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PopularMovie entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
        
    }
}
