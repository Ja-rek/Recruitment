using FluentAssertions;
using Task2.Infrastructure;
using Task2.Infrastructure.Provider3;

namespace Task2.Tests;

public class ProductProvider3Tests
{
    [Test]
    public async Task GetProductsAsync_Should_Return_Products_From_XmlReader()
    {
        // Arrange
        var xmlReader = new XmlProductReader("./Provider3/dostawca3plik1.xml");
        var productProvider = new ProductProvider3(xmlReader);

        // Act
        var result = await productProvider.GetProductsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        var product = result.First();
        product.ProviderId.Should().Be(6);
        product.Name.Should().Be("Softshell Falcon grey M");
        product.Description.Should().Contain("elastyczny materiał zwiększający komfort ruchu");
        product.Photo.Should().Be("https://texar.info.pl/img/towary/1/2019_03/softshell-falcon-grey.jpg");
    }
}
