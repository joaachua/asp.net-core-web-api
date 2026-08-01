using NmqPracticeApi.DTOs;
using NmqPracticeApi.Models;
using NmqPracticeApi.Repositories;

namespace NmqPracticeApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAll()
    {
        return _productRepository.GetAll();
    }

    public Product? GetById(int id)
    {
        return _productRepository.GetById(id);
    }

    public Product Create(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name.Trim(),
            Price = dto.Price,
            Stock = dto.Stock
        };

        return _productRepository.Add(product);
    }

    public bool Update(int id, UpdateProductDto dto)
    {
        var product = _productRepository.GetById(id);

        if (product is null)
        {
            return false;
        }

        product.Name = dto.Name.Trim();
        product.Price = dto.Price;
        product.Stock = dto.Stock;

        return _productRepository.Update(product);
    }

    public bool Delete(int id)
    {
        return _productRepository.Delete(id);
    }
}