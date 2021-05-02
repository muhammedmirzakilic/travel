using System;
using Microsoft.Extensions.Caching.Memory;
using travel.DTO;
using travel.Interfaces;

namespace travel.Data
{
    public class PassengerRepository : Repository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(IMemoryCache memoryCache)
            : base(memoryCache)
        {
            
        }

        //public override bool Add(Passenger entity)
        //{

        //    _customCache.Add(entity.Source.ToString(), entity);
        //}

        //public List<Passenger> GetAll(string source)
        //{
        //    var items = _customCache.GetAll(source);
        //    return items;
        //}
    }
}
