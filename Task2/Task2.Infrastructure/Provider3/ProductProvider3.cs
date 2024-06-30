using Task2.Application;

namespace Task2.Infrastructure.Provider3
{
    public class ProductProvider3(IProductReader xmlReader) : IProductProvider
    {
        private readonly IProductReader xmlReader = xmlReader;

        public async Task<IEnumerable<Contract.Product>> GetProductsAsync()
        {
            var xmlProducts = await xmlReader.ReadAsync<Produkty>();

            if (xmlProducts?.ProduktyList == null)
            {
                return Enumerable.Empty<Contract.Product>();
            }

            return xmlProducts.ProduktyList
                .Select(x => new Contract.Product
                {
                    ProviderId = x.Id,
                    Description = x.DlugiOpisPl,
                    Photo = x.Zdjecia?.ZdjecieList.FirstOrDefault()?.Url,
                    Name = x.NazwaPl,
                    Variant = null
                });
        }
    }
}
