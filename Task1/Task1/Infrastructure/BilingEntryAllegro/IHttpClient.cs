
namespace Task1.Infrastructure.BilingEntryAllegro
{
    public interface IHttpRestClient
    {
        Task<T?> Post<T>(string url, string content) where T : class;
        Task<BillingEntryAllegroRootDto?> GetBillingEntry(Guid id, int offset, string? token);
    }
}