﻿using ContosoPizzaAngular.Models;
using System.Diagnostics.Contracts;

namespace ContosoPizzaAngular.Services
{
    public class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza {Id = 1, Name = "Capricossa", IsGlutenFree = false, Spicy = false, Price = 10},
                new Pizza {Id = 2, Name = "Slavonska", IsGlutenFree = false, Spicy = true, Price = 15},
            };
        }
        public static List<Pizza> GetAll() => Pizzas;
        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;
            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;
            Pizzas[index] = pizza;
        }

    }
}
