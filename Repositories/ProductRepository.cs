using Microsoft.EntityFrameworkCore;
using NmqPracticeApi.Data;
using NmqPracticeApi.Models;

namespace NmqPracticeApi.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Product> GetAll()
    {
        return _dbContext.Products
            .AsNoTracking()
            .OrderBy(product => product.Id)
            .ToList();
    }

    public Product? GetById(int id)
    {
        return _dbContext.Products
            .AsNoTracking()
            .SingleOrDefault(product => product.Id == id);
    }

    public Product Add(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();

        return product;
    }

    public bool Update(Product product)
    {
        if (!_dbContext.Products.Any(existing =>
                existing.Id == product.Id))
        {
            return false;
        }

        product.UpdatedAt = DateTime.UtcNow;

        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var product = _dbContext.Products.Find(id);

        if (product is null)
        {
            return false;
        }

        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();

        return true;
    }
}