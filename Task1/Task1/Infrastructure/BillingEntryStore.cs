using NHibernate;
using Task1.Application;

namespace Task1.Infrastructure
{
    public class BillingEntryStore(ISessionFactory sessionFactory)
    {
        private readonly ISessionFactory sessionFactory = sessionFactory;

        public async Task Save(IEnumerable<BillingEntry> billingEntries)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                foreach (var billingEntry in billingEntries)
                {
                    await session.SaveAsync(billingEntry);
                }

                await transaction.CommitAsync();
            }
        }
    }
}
