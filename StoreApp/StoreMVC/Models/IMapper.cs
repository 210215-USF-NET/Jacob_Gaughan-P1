using StoreModels;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        CustomerIndexVM cast2CustomerIndexVM(Customer customer2Bcasted);
    }
}