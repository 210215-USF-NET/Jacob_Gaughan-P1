﻿using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository _repo;
        public CustomerBL(ICustomerRepository repo){
            _repo = repo;
        }
        public void AddCustomer(Customer newCustomer)
        {
            _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _repo.GetCustomerByEmail(email);
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            throw new NotImplementedException();
        }
    }
}
