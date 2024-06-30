using AutoFixture.NUnit3;
using FluentAssertions;
using Task2.Infrastructure;
using Task2.Infrastructure.Provider2;

namespace Task2.Tests;

public class ProductProvider2Tests
{
    [Test]
    public async Task GetProductsAsync_Should_Return_Products_From_XmlReader()
    {
        // Arrange
        var xmlReader = new XmlProductReader("./Provider2/dostawca2plik2.xml");
        var productProvider = new ProductProvider2(xmlReader);

        // Act
        var result = await productProvider.GetProductsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        var product = result.First();
        product.ProviderId.Should().Be(51);
        product.Name.Should().Be("Pędzelek Lens Pen");
        product.Description.Should().Contain("Flamaster do czyszczenia soczewek");
        product.Photo.Should().Be("https://b2b.deltaoptical.pl/zasoby/import/l/lens-pen_4_1_2.jpg");
    }
}
