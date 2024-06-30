namespace Task1.Application;

public class BillingEntryType
{
    public virtual int Id { get; init; }
    public required virtual string AllegroId { get; set; }
    public required virtual string Name { get; set; }
}
