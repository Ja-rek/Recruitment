using Microsoft.EntityFrameworkCore;
using Task2.Application;
using Task2.Contract;

namespace Task2.Infrastructure
{
    public class ProductStore(AppDbContext appDbContext) : IProductStore
    {
        private readonly AppDbContext appDbContext = appDbContext;

        public async Task ChangeStatusAsync(int id)
        {
            var product = await appDbContext.Products.FirstAsync(x => x.Id == id);

            product.State = product.State switch
            {
                State.Incorrect => State.Correct,
                _ => State.Incorrect,
            };

            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await appDbContext.Products.ToListAsync();
        }

        public async Task SaveAsync(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                var productExist = await appDbContext.Products
                    .AnyAsync(x => x.ProviderId == product.ProviderId);

                if (!productExist)
                {
                    appDbContext.Products.Add(product);
                }
            }

            await appDbContext.SaveChangesAsync();
        }
    }
}
