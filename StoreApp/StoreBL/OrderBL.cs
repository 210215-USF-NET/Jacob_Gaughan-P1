using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepository _repo;
        public OrderBL(IOrderRepository repo){
            _repo = repo;
        }
        public Order AddOrder(Order newOrder)
        {
            return _repo.AddOrder(newOrder);
        }
        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }
    }
}
