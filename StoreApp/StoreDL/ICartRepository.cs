using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICartRepository
    {
        Cart AddCart(Cart newCart);
        Cart AddToCart(Cart newCart, int invId, int quantity2Add);
        Cart GetCartById(int custId, int locId);
    }
}