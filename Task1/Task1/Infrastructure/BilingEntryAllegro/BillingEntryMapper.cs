using Task1.Application;

namespace Task1.Infrastructure.BilingEntryAllegro;

public class BillingEntryMapper : IBillingEntryMapper
{
    public IEnumerable<BillingEntry> Map(BillingEntryAllegroRootDto billingEntryAllegro)
    {
        return billingEntryAllegro.BillingEntries.Select(x => new BillingEntry
        {
            OrderId = x?.Order?.Id ?? Guid.Empty,
            BillingEntryType = new BillingEntryType
            {
                AllegroId = x?.Type?.Id ?? string.Empty,
                Name = x?.Type?.Name ?? string.Empty,
            },
            Amount = x?.Value?.Amount ?? 0,
            Currency = x?.Value?.Currency ?? string.Empty
        });
    }
}
