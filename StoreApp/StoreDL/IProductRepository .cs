using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product AddProduct(Product newProduct);

        decimal GetProductPrice(int prodId);

        Product GetProductById(int prodId);

        List<Product> GetProductsAtLocation(int locId);
    }
}