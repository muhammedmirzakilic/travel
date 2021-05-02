using System;
using System.Collections.Generic;
using travel.DTO;

namespace travel.Interfaces
{
    public interface IRepository<T> where T: BaseIdentityModel
    {
        List<T> GetAll(string source);
        bool Add(string source, T entity);
        T Get(string source, Guid id);
        T Update(string source, T entity);
        bool Delete(string source, Guid id);
    }
}
