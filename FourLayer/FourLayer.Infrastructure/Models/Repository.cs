using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Infrastructure.Models
{
    public class Repository : IRepository
    {
        //Query
        //Add
        //Find
        //Delete
        //Dispose
        //Extension

        private DataContext _db = new DataContext();

        public IQueryable<T> Query <T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }

        public IQueryable Query(string entityTypeName)
        {
            var entityType = Type.GetType(entityTypeName);
            return _db.Set(entityType).AsQueryable();
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            return _db.Set<T>().Find(keyValues);
        }

        public void Add<T>(T entity) where T : class
        {
           _db.Set<T>().Add(entity);
        }
        
        public void Delete<T>(params object[] keyValues) where T : class
        {
            var entity = this.Find<T>(keyValues);
            _db.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbVal)
            {
                var firstError = dbVal.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }

        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return this._db.Database.SqlQuery<T>(sql, parameters);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }

    public static class GenericRepositoryExtensions
    {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable, Expression<Func<T, TProperty>> relatedEntity) where T : class
        {
            return System.Data.Entity.QueryableExtensions.Include<T, TProperty>(queryable, relatedEntity);
        }
    }

    public interface IGenericRepository : IDisposable
    {
        System.Linq.IQueryable<T> Query<T>() where T : class;
        System.Linq.IQueryable Query(string entityTypeName);
        void Add<T>(T entityToCreate) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        void SaveChanges();
        System.Collections.Generic.IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);
    }
}
