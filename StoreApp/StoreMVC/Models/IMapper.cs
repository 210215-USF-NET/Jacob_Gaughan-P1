using StoreModels;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        Customer cast2Customer(CustomerCRVM customer2Bcasted);

        Customer cast2Customer(CustomerEditVM customer2Bcasted);

        CustomerCRVM cast2CustomerCRVM(Customer customer);

        CustomerIndexVM cast2CustomerIndexVM(Customer customer2Bcasted);

        Customer cast2CustomerEditVM(Customer customer2Bcasted);

        Location cast2Location(LocationCRVM location2Bcasted);

        Location cast2Location(LocationEditVM location2Bupdated);

        LocationCRVM cast2LocationCRVM(Location location);

        LocationIndexVM cast2LocationIndexVM(Location location2Bcasted);

        LocationEditVM cast2LocationEditVM(Location location);

        Manager cast2Manager(ManagerCRVM manager2Bcasted);

        Manager cast2Manager(ManagerEditVM manager2Bcasted);

        ManagerCRVM cast2ManagerCRVM(Manager manager);

        ManagerIndexVM cast2ManagerIndexVM(Manager manager2Bcasted);

        Manager cast2ManagerEditVM(Manager manager2Bcasted);

        Product cast2Product(ProductCRVM product2Bcasted);

        Product cast2Product(ProductEditVM product2Bcasted);

        ProductCRVM cast2ProductCRVM(Product product);

        ProductIndexVM cast2ProductIndexVM(Product product);

        ProductEditVM cast2ProductEditVM(Product product);

        CartCRVM cast2CartCRVM(Cart cart);

        Cart cast2Cart(CartCRVM cart2Bcasted);

        OrderIndexVM cast2OrderIndexVM(Order order);

        Order cast2Order(OrderIndexVM order2Bcasted);
    }
}