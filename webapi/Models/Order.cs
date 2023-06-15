using ContosoPizzaAngular.Models;
namespace ContosoPizzaAngular.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public float Price { get; set; }
        public bool Card { get; set; }
        public string Distance { get; set; }
        //public List<Car> Cars{ get; set; }
        public Car PrefferedCar { get; set; }
    }
}
