using System;
using System.Collections.Generic;
using travel.DTO;

namespace travel.Interfaces
{
    public interface ICustomCache<T>
    {
        bool Add(string source, T entity);
        T Get(string source, Guid id);
        T Update(string source, T entity);
        bool Delete(string source, Guid id);
        List<T> GetAll(string source);
        bool SetAll(string source, List<T> items);
    }
}
