using Task2.Contract;

namespace Task2.Application;

public class ProductDownloader(IEnumerable<IProductProvider> productProviders, 
    IProductStore productStore)
{
    private readonly IEnumerable<IProductProvider> productProviders = productProviders;
    private readonly IProductStore productStore = productStore;

    public async Task DownloadProductsAsync()
    {
        var products = await GetProductsAsync();

        await productStore.SaveAsync(products);
    }

    private async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var tasks = productProviders.Select(x => x.GetProductsAsync());

        var productGroups = await Task.WhenAll(tasks);

        return productGroups.SelectMany(x => x);
    }
}
