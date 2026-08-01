using NmqPracticeApi.Models;

namespace NmqPracticeApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products =
    [
        new Product
        {
            Id = 1,
            Name = "Keyboard",
            Price = 199.90m,
            Stock = 10
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 89.90m,
            Stock = 20
        }
    ];

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(product => product.Id == id);
    }

    public Product Add(Product product)
    {
        product.Id = _products.Count == 0
            ? 1
            : _products.Max(existingProduct => existingProduct.Id) + 1;

        _products.Add(product);

        return product;
    }

    public bool Update(Product product)
    {
        var existingProduct = GetById(product.Id);

        if (existingProduct is null)
        {
            return false;
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;
        existingProduct.UpdatedAt = DateTime.UtcNow;

        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);

        if (product is null)
        {
            return false;
        }

        _products.Remove(product);

        return true;
    }
}