using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ContosoPizzaAngular.Models;
using ContosoPizzaAngular.Services;
namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        public CarController() { }
        [HttpGet]
        public ActionResult<List<Car>> GetAll() => CarService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            var car = CarService.Get(id);
            if (car == null) return NotFound();
            return car;
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            CarService.Add(car);
            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Car car)
        {
            if (id != car.Id) return BadRequest();
            var existingCar = CarService.Get(id);
            if (existingCar is null) return NotFound();
            CarService.Update(car);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = CarService.Get(id);
            if (car is null) return NotFound();
            CarService.Delete(id);
            return NoContent();
        }

    }
}

