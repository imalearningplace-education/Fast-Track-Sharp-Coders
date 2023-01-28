namespace ECommerce.Entities; 

public class ProductOrder {

    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }

    public double SubTotal {
        get {
            return Product.Price * Quantity;
        }
    }

    public ProductOrder(Product product) {
        Quantity = 1;
        Product = product;
    }

    public ProductOrder(Product product, int quantity) 
        : this(product) {
        Quantity = quantity;
    }

}
