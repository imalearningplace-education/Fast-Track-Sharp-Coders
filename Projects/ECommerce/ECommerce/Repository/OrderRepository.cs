using ECommerce.BaseRepository;
using ECommerce.Model.Entities;

namespace ECommerce.Repository;

public class OrderRepository : BaseRepository<Order> {
    
    public OrderRepository() : base("orders") {
    }

}
