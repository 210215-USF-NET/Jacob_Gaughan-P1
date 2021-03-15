using StoreModels;

namespace StoreBL
{
    public interface ICartBL
    {
        Cart AddCart(Cart newCart);

        Cart AddToCart(Cart cartToAddTo);

        Cart GetCartById(int custId, int locId);

        Cart GetCartByCartId(int cartId);

        Cart EmptyCart(Cart cart2Bemptied);
    }
}