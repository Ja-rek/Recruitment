using System.Text.Json.Serialization;

namespace Task1.Infrastructure.BilingEntryAllegro;

public class BillingEntryAllegroRootDto
{
    [JsonPropertyName("billingEntries")]
    public List<BillingEntryDto> BillingEntries { get; set; } = new List<BillingEntryDto>();
}

public class BillingEntryDto
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("occurredAt")]
    public DateTime OccurredAt { get; set; }

    [JsonPropertyName("type")]
    public BillingEntryTypeDto? Type { get; set; }

    [JsonPropertyName("offer")]
    public OfferDto? Offer { get; set; }

    [JsonPropertyName("value")]
    public ValueDto? Value { get; set; }

    [JsonPropertyName("tax")]
    public TaxDto? Tax { get; set; }

    [JsonPropertyName("balance")]
    public BalanceDto? Balance { get; set; }

    [JsonPropertyName("order")]
    public OrderDto? Order { get; set; }
}

public class BillingEntryTypeDto
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class OfferDto
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class ValueDto
{
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}

public class TaxDto
{
    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }

    [JsonPropertyName("annotation")]
    public string? Annotation { get; set; }
}

public class BalanceDto
{
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}

public class OrderDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}

