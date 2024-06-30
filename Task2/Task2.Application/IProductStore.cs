using Task2.Contract;

namespace Task2.Application
{
    public interface IProductStore
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task SaveAsync(IEnumerable<Product> products);
        Task ChangeStatusAsync(int id);
    }
}
