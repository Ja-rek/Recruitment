using FluentNHibernate.Mapping;
using Task1.Application;

namespace Task1.Infrastructure.OrmMapping;

public class BillingEntryMap : ClassMap<BillingEntry>
{
    public BillingEntryMap()
    {
        Id(x => x.Id);
        Map(x => x.OrderId);
        Map(x => x.Amount);
        Map(x => x.Currency);
        References(x => x.BillingEntryType);
    }
}
