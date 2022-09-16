using CarInventoryAPI.CarData;
using CarInventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventoryAPI.Controllers
{
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllCars()
        {
            return Ok(_carRepository.GetCars());
        }

        [HttpGet]
        [Route("api/[controller]/{CarID}")]
        public IActionResult GetCar(Guid CarID)
        {
            var car = _carRepository.GetCar(CarID);

            if (car != null)
            {
                return Ok(car);
            }

            return NotFound($"Car with ID: {CarID} is not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddCar(Car car) 
        {
            _carRepository.AddCar(car);
            return Ok("Car created successfully");
        }

        [HttpDelete]
        [Route("api/[controller]/{CarID}")]
        public IActionResult DeleteCar(Guid CarID) 
        {
            var car = _carRepository.GetCar(CarID);
            if (car != null) 
            {
                _carRepository.DeleteCar(car);
                return Ok("Car deleted successfully from inventory");
            }
            return NotFound($"Car with ID: {CarID} is not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{CarID}")]
        public IActionResult EditCar(Guid CarID, Car car) 
        {
            var existingcar = _carRepository.GetCar(CarID);
            if (existingcar != null)
            {
                car.CarID = existingcar.CarID;
                _carRepository.EditCar(car);
                return Ok("Car edited successfully");
            }
            return NotFound($"Car with ID: {CarID} is not found");
        }
    }
}
