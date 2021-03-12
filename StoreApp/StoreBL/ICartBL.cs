using StoreModels;

namespace StoreBL
{
    public interface ICartBL
    {
        Cart AddCart(Cart newCart);
        Cart AddToCart(Cart newCart, int invId, int quantity2Add);
        Cart GetCartById(int custId, int locId);
    }
}