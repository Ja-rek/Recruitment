using AutoFixture.NUnit3;
using FluentAssertions;
using Task1.Application;
using Task1.Infrastructure.BilingEntryAllegro;

namespace UnitTests;

public class BillingEntryMapperTests
{
    [Test, AutoData]
    public void Map_ShouldReturnCorrectBillingEntries(BillingEntryAllegroRootDto billingEntryAllegro)
    {
        // Arrange
        var mapper = new BillingEntryMapper();

        // Act
        var result = mapper.Map(billingEntryAllegro);

        // Assert
        result.Should().HaveCount(billingEntryAllegro.BillingEntries.Count);

        var expectedEntries = billingEntryAllegro.BillingEntries.Select(x => new BillingEntry
        {
            OrderId = x?.Order?.Id ?? Guid.Empty,
            BillingEntryType = new BillingEntryType
            {
                AllegroId = x?.Type?.Id ?? string.Empty,
                Name = x?.Type?.Name ?? string.Empty
            },
            Amount = x?.Value?.Amount ?? 0,
            Currency = x?.Value?.Currency ?? string.Empty,
        }).ToList();

        result.Should().BeEquivalentTo(expectedEntries, options => options.WithStrictOrdering());
    }
}
