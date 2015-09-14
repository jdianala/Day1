using IdentityDay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace IdentityDay.Services.Models
{
    public class CacheRepository : IRepository
    {
        private ApplicationDbContext _db;

        private IList<string> _cacheNames = new List<string>();

        public CacheRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }

        // cache
        public IList<T> List<T>() where T : class
        {
            var typeName = typeof(T).FullName;
            var cache = HttpRuntime.Cache[typeName] as IList<T>;

            if (cache == null)
            {
                cache = Query<T>().ToList();
                HttpRuntime.Cache[typeName] = cache;
            }

            return cache;
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
            _db.Set<T>().Remove(Find<T>(keyValues));
        }

        public void SaveChanges()
        {
            try
            {
                _db.SaveChanges();

                foreach (string cache in _cacheNames)
                {
                    HttpRuntime.Cache.Remove(cache);
                }
                _cacheNames.Clear();
            }
            catch (DbEntityValidationException error)
            {
                var firstError = error.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new DbEntityValidationException(firstError);
            }

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    
    }
}