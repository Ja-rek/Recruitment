using System.Xml.Serialization;

namespace Task2.Infrastructure.Provider2;

[XmlRoot("products")]
public class Products
{
    [XmlAttribute("lang")]
    public string? Language { get; set; }

    [XmlElement("product")]
    public List<Product> ProductList { get; set; } = new();
}

public class Product
{
    [XmlElement("id")]
    public int Id { get; set; }

    [XmlElement("name")]
    public string? Name { get; set; }

    [XmlElement("desc")]
    public string? Description { get; set; }

    [XmlArray("photos")]
    [XmlArrayItem("photo")]
    public List<Photo> Photos { get; set; } = new();
}

public class Photo
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("main")]
    public int Main { get; set; }

    [XmlText]
    public string? Url { get; set; }
}
