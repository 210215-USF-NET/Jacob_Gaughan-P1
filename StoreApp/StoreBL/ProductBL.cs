using StoreDL;
using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public class ProductBL : IProductBL
    {
        private IProductRepository _repo;

        public ProductBL(IProductRepository repo)
        {
            _repo = repo;
        }

        public Product AddProduct(Product newProduct)
        {
            return _repo.AddProduct(newProduct);
        }

        public decimal GetProductPrice(int productId)
        {
            return _repo.GetProductPrice(productId);
        }

        public Product GetProductById(int productId)
        {
            return _repo.GetProductById(productId);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public List<Product> GetProductsAtLocation(int locId)
        {
            return _repo.GetProductsAtLocation(locId);
        }

        public Product UpdateProduct(Product product2Bupdated)
        {
            return _repo.UpdateProduct(product2Bupdated);
        }
    }
}