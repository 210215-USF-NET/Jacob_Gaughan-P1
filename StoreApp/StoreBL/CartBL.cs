﻿using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class CartBL : ICartBL
    {
        private ICartRepository _repo;

        public CartBL(ICartRepository repo)
        {
            _repo = repo;
        }

        public Cart GetCartById(int custId, int locId)
        {
            return _repo.GetCartById(custId, locId);
        }

        public Cart AddToCart(Cart cart2AddTo, int invId, int quantity2Add)
        {
            return _repo.AddToCart(cart2AddTo, invId, quantity2Add);
        }

        public Cart AddCart(Cart newCart)
        {
            return _repo.AddCart(newCart);
        }
    }
}