namespace Task1.Application;

public class BillingEntry
{
    public virtual int Id { get; set; }
    public required virtual Guid OrderId { get; init; }
    public required virtual BillingEntryType BillingEntryType { get; set; }
    public required virtual decimal Amount { get; set; }
    public required virtual string Currency { get; set; }
}
