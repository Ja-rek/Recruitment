using FluentNHibernate.Mapping;
using Task1.Application;

namespace Task1.Infrastructure;

public class BillingEntryTypeMap : ClassMap<BillingEntryType>
{
    public BillingEntryTypeMap()
    {
        Id(x => x.Id);
        Map(x => x.AllegroId);
        Map(x => x.Name);
    }
}
