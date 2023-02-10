using ECommerce.Model.Entities;

namespace Ecommerce;

public class Program {

    public static void Main(string[] args) {

        File.AppendAllText("teste.txt", "teste testando");

        List<Product> products = new List<Product> {
            new Product { Name = "Ferrari" , Price = 12.0 },
            new Product { Name = "Óculos", Price = 20.0 },
            new Product { Name = "Lápis", Price = 3.50 }
        };

        products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));

        products.ForEach(Console.WriteLine);
    }

}