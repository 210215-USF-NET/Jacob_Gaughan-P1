using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ICustomerBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer newCustomer);
        Customer GetCustomerByEmail(string email);
        Customer DeleteCustomer(Customer customer2BDeleted);
    }
}