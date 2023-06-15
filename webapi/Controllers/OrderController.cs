using Microsoft.AspNetCore.Mvc;
using ContosoPizzaAngular.Models;
using ContosoPizzaAngular.Services;
using System.Text.Encodings.Web;
using System.Web;
namespace webapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        public OrderController() { }
        [HttpGet]
        public ActionResult<List<Order>> GetAll() => OrderService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = OrderService.Get(id);
            if (order == null)
                return NotFound();
            return order;
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            OrderService.Add(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Order order)
        {
            if (id != order.Id)
                return BadRequest();
            var existingOrder = OrderService.Get(id);
            if (existingOrder is null)
                return NotFound();
            OrderService.Update(order);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = OrderService.Get(id);
            if (order is null) return NotFound();
            OrderService.Delete(id);
            return NoContent();
        }
        [HttpGet("/total/{id}")]
        public float GetTotal(int id)
        {
            var price = OrderService.GetTotal(id);
            return price;

        }
        [HttpGet("/totalSlices/{id}")]
        public int GetTotalSlices(int id)
        {
            var slices = OrderService.GetTotalPizzaSlices(id);
            return slices;
        }
        [HttpGet("/pickCar/{id}")]
        public IActionResult PickCar(int id)
        {
            OrderService.PickCar(id);
            return NoContent();
        }
        
    }
}
