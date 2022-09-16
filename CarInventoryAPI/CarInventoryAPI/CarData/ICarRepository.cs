using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInventoryAPI.Models;

namespace CarInventoryAPI.CarData
{
   public interface ICarRepository
    {
        List<Car> GetCars();
        Car GetCar(Guid CarID);
        Car AddCar(Car car);
        void DeleteCar(Car car);
        Car EditCar(Car car);
    }
}
