using ContosoPizzaAngular.Models;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ContosoPizzaAngular.Services
{
    public class CarService
    {
        static List<Car> Cars {  get; set; }
        static int nextId = 0;
        static CarService()
        {
            Cars = new List<Car> 
            { 
                new Car { Id = nextId, Model = "Renault", PizzaCapacity = 3, Consumption100Km = 4.5f, Size = 1 },
                new Car { Id = nextId, Model = "Dacia", PizzaCapacity = 4, Consumption100Km = 7f, Size = 3 },
                new Car { Id = nextId, Model = "Audi", PizzaCapacity = 5, Consumption100Km = 8.5f, Size = 4 }

        };
        }

        public static List<Car> GetAll() => Cars;
        public static Car? Get(int id) => Cars.FirstOrDefault(c => c.Id == id);
        public static void Add(Car car)
        {
            car.Id = nextId++;
            Cars.Add(car);
        }
        public static void Update(Car car)
        {
            var index = Cars.FindIndex(c => c.Id == car.Id);
            if (index == -1) return;
            Cars[index] = car;
        }
        public static void Delete(int id)
        {
            var car = Get(id);
            if (car is null) return;
            Cars.Remove(car);
        }

        public static Car GetCarConsumptioType(string distance)
        {
            foreach(Car car in Cars)
            {
                if (car.Consumption100Km <= 6 && distance == "Far")
                    return car;
                else if (car.Consumption100Km <= 8 && distance == "Nearby")
                    return car;
                else if (car.Consumption100Km >= 8 && distance == "Close") 
                    return car;
            }
            return new Car { Id = nextId, Model = "Opel", PizzaCapacity = 5, Consumption100Km = 5.5f, Size = 2 };
        }

    }
}
