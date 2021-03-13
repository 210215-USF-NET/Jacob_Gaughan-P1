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

        Customer CheckCustomerLoginInfo(string email, string password);

        Customer UpdateCustomer(Customer customer2Bupdated);

        Customer GetCustomerById(int Id);
    }
}