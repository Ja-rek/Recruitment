using Task1.Application;

namespace Task1.Infrastructure.BilingEntryAllegro
{
    public interface IBillingEntryMapper
    {
        IEnumerable<BillingEntry> Map(BillingEntryAllegroRootDto billingEntryAllegro);
    }
}