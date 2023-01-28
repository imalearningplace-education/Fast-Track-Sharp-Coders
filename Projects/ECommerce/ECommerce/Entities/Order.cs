namespace ECommerce.Entities; 

public class Order {

    public List<ProductOrder> products { get; set; }

    public double Total {
        get {
            return products.Sum(p => p.SubTotal);
        }
    }

}
     