using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class Mapper : IMapper
    {
        public CustomerIndexVM cast2CustomerIndexVM(Customer customer2Bcasted)
        {
            return new CustomerIndexVM
            {
                CustomerName = customer2Bcasted.CustomerName,
                CustomerEmail = customer2Bcasted.CustomerEmail
            };
        }
    }
}
