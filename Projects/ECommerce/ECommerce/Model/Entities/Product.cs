namespace ECommerce.Model.Entities;

public class Product
{
    // Single Responsability Principle
    // Devemos ter apenas um único objetivo para mudar uma classe

    public long Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Name: {Name} , Price: R${Price:F2}";
    }
}
