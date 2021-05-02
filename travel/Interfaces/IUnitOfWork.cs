using System;
namespace travel.Interfaces
{
    public interface IUnitOfWork
    {
        IPassengerRepository Passengers { get; }
    }
}
