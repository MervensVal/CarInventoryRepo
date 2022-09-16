using CarInventoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventoryAPI.CarData
{
    public class CarRepository : ICarRepository
    {
        private List<Car> cars = new List<Car>()
        {
            new Car()
            {
                CarID = Guid.NewGuid(),
                Make = "TestMake1",
                Model = "TestModel1",
                Description = "TestDescription1",
                Price = 1.00
            },

            new Car()
            {
                CarID = Guid.NewGuid(),
                Make = "TestMake2",
                Model = "TestModel2",
                Description = "TestDescription2",
                Price = 2.00
            }
        };

        public Car AddCar(Car car)
        {
            car.CarID = Guid.NewGuid();
            cars.Add(car);
            return car;
        }

        public void DeleteCar(Car car)
        {
            cars.Remove(car);
        }

        public Car EditCar(Car car)
        {
            var existingCar = GetCar(car.CarID);
            existingCar.Make = car.Make;
            existingCar.Model = car.Model; 
            existingCar.Price = car.Price;
            existingCar.Description = car.Description;

            return existingCar;
        }

        public Car GetCar(Guid CarID)
        {
            return cars.SingleOrDefault(c => c.CarID == CarID);
        }

        public List<Car> GetCars()
        {
            return cars;
        }
    }
}
