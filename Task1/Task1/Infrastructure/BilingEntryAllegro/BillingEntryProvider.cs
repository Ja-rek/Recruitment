using FluentNHibernate.Conventions;
using Task1.Application;

namespace Task1.Infrastructure.BilingEntryAllegro
{
    public class BillingEntryProvider(IHttpRestClient client, IBillingEntryMapper mapper)
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(20);
        private readonly IHttpRestClient client = client;
        private readonly IBillingEntryMapper mapper = mapper;

        public async Task<IEnumerable<BillingEntry>> GetBillingEntriesAsync(IEnumerable<Guid> ids, string? token)
        {
            var tasks = ids.Select(id => GetBillingEntry(id, token));
            var results = await Task.WhenAll(tasks);

            return results.SelectMany(result => result);
        }

        private async Task<IEnumerable<BillingEntry>> GetBillingEntry(Guid id, string? token)
        {
            var bilings = new List<BillingEntry>();

            var offset = 0;
            while (true)
            {
                await semaphore.WaitAsync();
                try
                {
                    var result = await client.GetBillingEntry(id, offset, token);

                    if(result != null && result.BillingEntries.IsNotEmpty())
                    {
                        var billingEntry = mapper.Map(result);
                        bilings.AddRange(billingEntry);
                        offset += 100;

                        continue;
                    }

                    break;
                }
                catch
                {
                    break;
                    throw;
                }
                finally
                {
                    semaphore.Release();
            }
            }

            return bilings;
        }
    }
}
