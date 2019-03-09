using MovieViewer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static MovieViewer.Models.MovieDb.Popula;

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
                    result.insertDate = DateTimeOffset.Now;
                    Create(result);
                }
            } catch (Exception ex)
            {
                // Log and continue to insert next record
            }
            
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
            throw new NotImplementedException();
        }
    }
}
