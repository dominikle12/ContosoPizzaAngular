namespace ContosoPizzaAngular.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool Spicy { get; set; }
        public float Price { get; set; }
        public int Size { get; set; }
    }
}
