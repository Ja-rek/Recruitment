using Task1.Infrastructure;
using Task1.Infrastructure.BilingEntryAllegro;

namespace Task1.Application;

public class BillingEntryService(BillingEntryProvider billingProvider, 
    OrderProvider orderProvider,
    BillingEntryStore store,
    AllegroAuthService allegroAuthService)
{
    private readonly BillingEntryProvider billingProvider = billingProvider;
    private readonly OrderProvider orderProvider = orderProvider;
    private readonly BillingEntryStore store = store;
    private readonly AllegroAuthService allegroAuthService = allegroAuthService;

    public async Task DownloadAsync()
    {
        var orderIds = await orderProvider.GetOrderIdsAsync();
        var token = await allegroAuthService.GetAccessTokenAsync();
        var billingEntries = await billingProvider.GetBillingEntriesAsync(orderIds, token);

        await store.Save(billingEntries);
    }
}
