using NmqPracticeApi.Models;

namespace NmqPracticeApi.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();

    Product? GetById(int id);

    Product Add(Product product);

    bool Update(Product product);

    bool Delete(int id);
}