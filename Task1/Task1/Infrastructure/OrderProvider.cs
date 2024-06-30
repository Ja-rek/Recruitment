using NHibernate;

namespace Task1.Infrastructure;

public class OrderProvider(ISessionFactory sessionFactory)
{
    private readonly ISessionFactory sessionFactory = sessionFactory;

    public async Task<IEnumerable<Guid>> GetOrderIdsAsync()
    {
        using (var session = sessionFactory.OpenStatelessSession())
        {
            return await session
                .CreateSQLQuery("SELECT OrderId FROM OrderTable")
                .ListAsync<Guid>();
        }
    }
}
