using Task2.Application;

namespace Task2.Infrastructure.Provider2
{
    public class ProductProvider2(IProductReader xmlReader) : IProductProvider
    {
        private readonly IProductReader xmlReader = xmlReader;

        public async Task<IEnumerable<Contract.Product>> GetProductsAsync()
        {
            var xmlProducts = await xmlReader.ReadAsync<Products>();

            if (xmlProducts?.ProductList == null)
            {
                return Enumerable.Empty<Contract.Product>();
            }

            return xmlProducts.ProductList
                .Select(x => new Contract.Product
                {
                    ProviderId = x.Id,
                    Description = x.Description,
                    Photo = x?.Photos.FirstOrDefault()?.Url,
                    Name = x?.Name,
                    Variant = null
                });
        }
    }
}
