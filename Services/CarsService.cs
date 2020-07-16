using System;
using System.Collections.Generic;
using fullstack_gregslist.Models;
using fullstack_gregslist.Repositories;

namespace fullstack_gregslist.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> GetAll()
        {
            return _repo.GetAll();
        }

        internal IEnumerable<Car> GetByUserId(string userId)
        {
            return _repo.GetCarsByUserId(userId);
        }

        public Car GetById(int id)
        {
            Car foundCar = _repo.GetById(id);
            if (foundCar == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundCar;
        }

        internal Car Create(Car newCar)
        {
            return _repo.Create(newCar);
        }

        internal Car Edit(Car carToUpdate, string userId)
        {
            Car foundCar = GetById(carToUpdate.Id);
            // NOTE Check if not the owner, and price is increasing
            if (foundCar.UserId != userId && foundCar.Price < carToUpdate.Price)
            {
                if (_repo.BidOnCar(carToUpdate))
                {
                    foundCar.Price = carToUpdate.Price;
                    return foundCar;
                }
                throw new Exception("Could not bid on that car");
            }
            if (foundCar.UserId == userId && _repo.Edit(carToUpdate, userId))
            {
                return carToUpdate;
            }
            throw new Exception("You cant edit that, it is not yo car!");
        }

        internal string Delete(int id, string userId)
        {
            Car foundCar = GetById(id);
            if (foundCar.UserId != userId)
            {
                throw new Exception("This is not your car!");
            }
            if (_repo.Delete(id, userId))
            {
                return "Sucessfully delorted.";
            }
            throw new Exception("Somethin bad happened");
        }
    }
}