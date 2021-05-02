using System;
using System.Collections.Generic;
using travel.DTO;
using travel.Enums;
using travel.Interfaces;

namespace travel.Services
{
    public class PassengerService : IPassengerService
    {
        IUnitOfWork _unitOfWork;
        public PassengerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Passenger> ReadAll(Source source)
        {
            var items = _unitOfWork.Passengers.GetAll(source.ToString());
            return items;
        }

        public bool Create(Source source, Passenger passenger)
        {
            passenger.Id = Guid.NewGuid();
            return _unitOfWork.Passengers.Add(source.ToString(), passenger);
        }

        public bool Delete(Source source, Guid id)
        {
            return _unitOfWork.Passengers.Delete(source.ToString(), id);
        }

        public Passenger Read(Source source, Guid id)
        {
            return _unitOfWork.Passengers.Get(source.ToString(), id);
        }

        public Passenger Update(Source source, Passenger passenger)
        {
            return _unitOfWork.Passengers.Update(source.ToString(), passenger);
        }
    }
}
