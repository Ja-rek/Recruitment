using Task2.Contract;

namespace Task2.Application;

public interface IProductProvider
{
    Task<IEnumerable<Product>> GetProductsAsync();
}
