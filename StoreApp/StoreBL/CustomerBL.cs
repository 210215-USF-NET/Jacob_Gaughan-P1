using StoreDL;
using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository _repo;

        public CustomerBL(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            return _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _repo.GetCustomerByEmail(email);
        }

        public Customer GetCustomerById(int Id)
        {
            return _repo.GetCustomerById(Id);
        }

        public Customer CheckCustomerLoginInfo(string email, string password)
        {
            return _repo.CheckCustomerLoginInfo(email, password);
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            return _repo.DeleteCustomer(customer2BDeleted);
        }

        public Customer UpdateCustomer(Customer customer2Bupdated)
        {
            return _repo.UpdateCustomer(customer2Bupdated);
        }
    }
}