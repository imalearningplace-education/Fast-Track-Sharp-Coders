using ECommerce.Model.Entities;

namespace ECommerce.BaseRepository;

public class ProductRepository : BaseRepository<Product> {

    public ProductRepository() : base("products") {
    }

}