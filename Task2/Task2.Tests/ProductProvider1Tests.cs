using FluentAssertions;
using Task2.Infrastructure;
using Task2.Infrastructure.Provider1;

namespace Task2.Tests;

public class ProductProvider1Tests
{
    [Test]
    public async Task GetProductsAsync_Should_Return_Products_From_XmlReader()
    {
        // Arrange
        var xmlReader = new XmlProductReader("./Provider1/dostawca1plik2.xml");
        var productProvider = new ProductProvider1(xmlReader);

        // Act
        var result = await productProvider.GetProductsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        var product = result.First();
        product.ProviderId.Should().Be(9944);
        product.Name.Should().Be("Termos HONER 0.5 L");
        product.Description.Should().Contain("to niekwestionowany lider w swojej klasie");
        product.Photo.Should().Be("https://b2b.fjordnansen.pl/hpeciai/1a4abe5da61ab6e6ae9e2e894183cdc2/9944_1.webp");
    }
}