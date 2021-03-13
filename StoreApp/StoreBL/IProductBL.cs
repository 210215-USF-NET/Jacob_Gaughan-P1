using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IProductBL
    {
        List<Product> GetProducts();

        Product AddProduct(Product newProduct);

        decimal GetProductPrice(int productId);

        Product GetProductById(int productId);

        List<Product> GetProductsAtLocation(int locId);

        Product UpdateProduct(Product product2Bupdated);
    }
}