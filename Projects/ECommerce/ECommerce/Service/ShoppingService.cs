using ECommerce.BaseRepository;
using ECommerce.Model.Entities;

namespace ECommerce.Service;

public class ShoppingService {

    // algum vs um
    // ponte
    private ProductRepository _productRepository; 

    public ShoppingService() {
        _productRepository = new ProductRepository();
    }

    public List<Product> GetAllOrderByPrice() {
        var products = _productRepository.GetAll();
        return products.OrderBy(x => x.Price).ToList();
    }


}
