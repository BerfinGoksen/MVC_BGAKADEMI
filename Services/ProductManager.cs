using Services.Contracts;
using Repositories.Contracts;
using Entities;
using Entities.Models;
using System; // Eklediğimiz hatayı fırlatmak için System namespace'i ekledik.
using System.Collections.Generic; // IEnumerable kullanabilmek için ekledik.

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateProduct(Product product)
        {
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            var product = GetOneProduct(id, false);
            if (product != null) // "if (product id not null)" kısmını düzelttik
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product GetOneProduct(int id, bool trackChanges)
        {
            Product product = _manager.Product.GetOneProduct(id, trackChanges);

            if (product == null) // "if (product is null)" kısmını düzelttik
            {
                throw new Exception("Product not found!");
            }

            return product;
        }

        public void UpdateOneProduct(Product product)
        {
            var entity = _manager.Product.GetOneProduct(product.ProductId, true);
            entity.ProductName = product.ProductName;
            entity.Price = product.Price;
            _manager.Save();
        }
    }
}
