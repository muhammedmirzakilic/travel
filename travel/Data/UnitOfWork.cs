using System;
using Microsoft.Extensions.Caching.Memory;
using travel.Interfaces;

namespace travel.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        IMemoryCache _cache;
        public UnitOfWork(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IPassengerRepository _passengers;
        public IPassengerRepository Passengers
        {
            get
            {
                if (_passengers == null)
                    _passengers = new PassengerRepository(_cache);
                return _passengers;
            }
        }
    }
}
