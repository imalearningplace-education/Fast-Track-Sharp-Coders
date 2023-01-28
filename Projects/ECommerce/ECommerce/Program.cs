using ECommerce.Entities;

namespace Ecommerce;

public class Program {

    public static void Main(string[] args) {

        List<Product> products = new List<Product> {
            new Product { Name = "Ferrari" , Price = 12.0 },
            new Product { Name = "Óculos", Price = 20.0 },
            new Product { Name = "Lápis", Price = 3.50 }
        };

        products.Sort();

        products.ForEach(Console.WriteLine);
    }

}