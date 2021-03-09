using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();

        Customer AddCustomer(Customer newCustomer);

        Customer DeleteCustomer(Customer customer2BDeleted);

        Customer GetCustomerByEmail(string email);


    }
}