using Services.Contracts;
using Repositories.Contracts;
using Entities.Models;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            var product = GetOneProduct(id, false);
            if (product != null)
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

            if (product == null)
            {
                throw new Exception("Product not found!");
            }

            return product;
        }

        public ProductDtoForUpdate GetProductDtoForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDtoForUpdate = _mapper.Map<ProductDtoForUpdate>(product);
            return productDtoForUpdate;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            // var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            // entity.ProductName = productDto.ProductName;
            // entity.Price = productDto.Price;
            // entitiy.CategoryId = productDto.CategoryId;
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int productId, bool includeRelatedEntities)
        {
            var product = GetOneProduct(productId, includeRelatedEntities);
            var productDtoForUpdate = _mapper.Map<ProductDtoForUpdate>(product);
            return productDtoForUpdate;
        }
    }
}
