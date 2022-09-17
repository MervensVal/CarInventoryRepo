using CarInventoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventoryAPI.CarData
{
    public class CarRepositoryUsingEFC : ICarRepository
    {
        private readonly CarContext _carContext;
        public CarRepositoryUsingEFC(CarContext carContext)
        {
            _carContext = carContext;
        }
        public Car AddCar(Car car)
        {
            car.CarID = Guid.NewGuid();
            _carContext.Car.Add(car);
            _carContext.SaveChanges();
            return car;
        }

        public void DeleteCar(Car car)
        {
            _carContext.Car.Remove(car);
            _carContext.SaveChanges();
        }

        public Car EditCar(Car car)
        {
            var existingCar = _carContext.Car.Find(car.CarID);
            if (existingCar != null) 
            {
                //Allows to update entity and track changes
                existingCar.Make = car.Make;
                existingCar.Model = car.Model;
                existingCar.Price = car.Price;
                existingCar.Description = car.Description;

                _carContext.Car.Update(existingCar);
                _carContext.SaveChanges();
            }

            return car;
        }

        public Car GetCar(Guid CarID)
        {
            var car = _carContext.Car.Find(CarID);
            return car;
        }

        public List<Car> GetCars()
        {
            return _carContext.Car.ToList();
        }
    }
}

