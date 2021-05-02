using System;
using System.Collections.Generic;
using travel.DTO;
using travel.Enums;

namespace travel.Interfaces
{
    public interface IPassengerService
    {
        bool Create(Source source, Passenger passenger);
        List<Passenger> ReadAll(Source source);
        Passenger Read(Source source, Guid id);
        Passenger Update(Source source, Passenger passenger);
        bool Delete(Source source, Guid id);
    }
}
