using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using Moq;
using Task1.Infrastructure.BilingEntryAllegro;

namespace UnitTests;

public class BillingEntryProviderTests
{
    private Mock<IHttpRestClient> _mockClient;
    private Mock<IBillingEntryMapper> _mockMapper;

    [SetUp]
    public void Setup()
    {
        _mockClient = new Mock<IHttpRestClient>();
        _mockMapper = new Mock<IBillingEntryMapper>();
    }

    [Test, AutoData]
    public async Task GetBillingEntry_ShouldCallMapWithResult(
        List<Guid> ids,
        string token,
        BillingEntryAllegroRootDto result)
    {
        var id1 = ids[0];

        // Arrange
        _mockClient.Setup(c => c.GetBillingEntry(It.Is<Guid>(id => id == id1), It.IsAny<int>(), token))
            .ReturnsAsync(result);

        _mockClient.Setup(c => c.GetBillingEntry(It.Is<Guid>(id => id == id1), It.Is<int>(offset => offset == 100), token))
            .ReturnsAsync(new BillingEntryAllegroRootDto());

        var provider = new BillingEntryProvider(_mockClient.Object, _mockMapper.Object);

        // Act
        await provider.GetBillingEntriesAsync(ids, token);

        // Assert
        _mockMapper.Verify(m => m.Map(It.IsAny<BillingEntryAllegroRootDto>()), Times.AtLeastOnce);
    }
}
