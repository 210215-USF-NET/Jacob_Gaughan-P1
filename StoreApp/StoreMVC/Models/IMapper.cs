using StoreModels;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        Customer cast2Customer(CustomerCRVM customer2Bcasted);
        CustomerCRVM cast2CustomerCRVM(Customer customer);
        CustomerIndexVM cast2CustomerIndexVM(Customer customer2Bcasted);
        Location cast2Location(LocationCRVM location2Bcasted);
        LocationCRVM cast2LocationCRVM(Location location);
        LocationIndexVM cast2LocationIndexVM(Location location2Bcasted);
    }
}