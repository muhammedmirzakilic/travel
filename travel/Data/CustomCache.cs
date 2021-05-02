using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using travel.DTO;
using travel.Interfaces;

namespace travel.Data
{
    public class CustomCache<T> : ICustomCache<T> where T : BaseIdentityModel
    {
        IMemoryCache _cache;

        public CustomCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public bool Add(string source, T entity)
        {
            var key = GetCacheKey(source);
            var items = _cache.Get<List<T>>(key);
            if (items == null)
            {
                items = new List<T>();
            }
            items.Add(entity);
            _cache.Set(key, items);
            return true;
        }

        public T Get(string source, Guid id)
        {
            var items = _cache.Get<List<T>>(GetCacheKey(source));
            var item = items?.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public T Update(string source, T entity)
        {
            var key = GetCacheKey(source);
            var items = _cache.Get<List<T>>(key);
            var item = items?.FirstOrDefault(x => x.Id == entity.Id);
            item = entity;
            _cache.Set(key, items);
            return item;
        }

        public bool Delete(string source, Guid id)
        {
            var key = GetCacheKey(source);
            var items = _cache.Get<List<T>>(key);
            var item = items?.FirstOrDefault(x => x.Id == id);
            items.Remove(item);
            _cache.Set(key, items);
            return true;
        }

        public List<T> GetAll(string source)
        {
            var items = _cache.Get<List<T>>(GetCacheKey(source));
            return items;
        }

        public bool SetAll(string source, List<T> items)
        {
            _cache.Set(GetCacheKey(source), items);
            return true;
        }

        private static string GetCacheKey(string source)
        {
            return $"{source}_{ typeof(T).Name}";
        }
    }
}
