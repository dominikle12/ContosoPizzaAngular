using ContosoPizzaAngular.Models;
using Microsoft.AspNetCore.SignalR;
using System.Data;

namespace ContosoPizzaAngular.Services
{
    public class OrderService
    {
        public static List<Order> Orders { get; }
        
        static int nextId = 0;
        static OrderService()
        {
            Orders = new List<Order>
            {
                new Order { Id = nextId++, Card = false, Distance = "Close", Pizzas = new List<Pizza>(), PrefferedCar = CarService.Get(0), Price = 10}
            };
        }

        public static List<Order> GetAll() => Orders;

        public static Order? Get(int id) => Orders.FirstOrDefault(p => p.Id == id);

        public static void Add(Order order)
        {
            //order.Id = nextId++;
            Orders.Add(order);
        }
        public static void Delete(int id)
        {
            var order = Get(id);
            if (order is null)
                return;
            Orders.Remove(order);
        }
        public static void Update(Order order)
        {
            var index = order.Pizzas.FindIndex(o => o.Id == order.Id);
            if (index == -1)
                return;
            Orders[index] = order;
        }

        public static List<Pizza> GetAllPizzasFromOrder(int orderId) => Orders[orderId].Pizzas;
        public static Pizza? GetPizzaFromOrder(int orderId, int pizzaId) => Orders[orderId].Pizzas.FirstOrDefault(p => p.Id == pizzaId);

        public static void DeletePizzaFromOrder(int orderId, int pizzaId) 
        {
            var pizza = GetPizzaFromOrder(orderId ,pizzaId);
            if (pizza is null)
                return;
            Orders[orderId].Pizzas.Remove(pizza);
        }
        public static void UpdatePizzaOrder(int orderId, int pizzaId, Pizza newPizza)
        {
            var pizza = GetPizzaFromOrder(orderId, pizzaId);
            if (pizza is null)
                return;
            Orders[orderId].Pizzas[pizzaId] = newPizza;
            return;
        }

        public static float GetTotal(int orderId)
        {
            float total = 0;
            foreach (var pizza in Orders[orderId].Pizzas)
            {
                total += pizza.Price;
            }
            return total;
        }
        public static int GetTotalPizzaSlices(int orderId)
        {
            int totalSlices = 0;
            foreach(var pizza in Orders[orderId].Pizzas)
            {
                totalSlices += 8;
            }
            return totalSlices;
        }

        public static void PickCar(int orderId)
        {
            foreach(Car car in CarService.GetAll())
            {
                foreach(Pizza pizza in Orders[orderId].Pizzas)
                {
                    if(pizza.Size <= car.Size)
                    {                       
                        switch (Orders[orderId].Distance)
                        {
                            case "Close":
                                Orders[orderId].PrefferedCar = CarService.GetCarConsumptioType("Close");
                                break;
                            case "Nearby":
                                Orders[orderId].PrefferedCar = CarService.GetCarConsumptioType("Nearby");
                                break;
                            case "Far":
                                Orders[orderId].PrefferedCar = CarService.GetCarConsumptioType("Far");
                                break;
                        }
                    }
                }
            }

            
        }

    }
}
