using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using travel.DTO;
using travel.Interfaces;

namespace travel.Data
{
    public class Repository<T> : IRepository<T> where T : BaseIdentityModel
    {
        CustomCache<T> _customCache;
        public Repository(IMemoryCache cache)
        {
            _customCache = new CustomCache<T>(cache);
        }

        public virtual bool Add(string source, T entity)
        {
            return _customCache.Add(source, entity);
        }

        public virtual bool Delete(string source, Guid id)
        {
            return _customCache.Delete(source, id);
        }

        public virtual T Get(string source, Guid id)
        {
            return _customCache.Get(source, id);
        }

        public virtual List<T> GetAll(string source)
        {
            return _customCache.GetAll(source);
        }

        public virtual T Update(string source, T entity)
        {
            return _customCache.Update(source, entity);
        }
    }
}
