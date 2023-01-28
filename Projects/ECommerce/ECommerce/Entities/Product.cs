namespace ECommerce.Entities; 

public class Product : IComparable<Product> { 
    // Single Responsability Principle
    // Devemos ter apenas um único objetivo para mudar uma classe

    public string? Name { get; set; }
    public double Price { get; set; }

    public int CompareTo(Product? other) {
        return Price.CompareTo(other.Price);
    }

    public override string ToString() {
        return $"Name: {Name} , Price: R${Price:F2}";
    }
}
