using System.Xml.Serialization;

namespace Task2.Infrastructure.Provider1;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot(ElementName = "offer", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
public class Offer
{
//    [XmlElement(ElementName = "products")]
//    public Products Products { get; set; }
}

public class Products
{
    [XmlElement(ElementName = "product")]
    public List<Product> ProductList { get; set; } = new();

    [XmlAttribute(AttributeName = "language")]
    public string? Language { get; set; }
}

public class Product
{
    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlElement(ElementName = "description")]
    public Description? Description { get; set; }

    [XmlElement(ElementName = "price")]
    public Price? Price { get; set; }

    [XmlElement(ElementName = "images")]
    public Images? Images { get; set; }

}

public class Producer
{
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string? Name { get; set; }
}

public class Category
{
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [XmlAttribute(AttributeName = "xml:lang")]
    public string? Lang { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string? Name { get; set; }
}

public class Unit
{
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [XmlAttribute(AttributeName = "xml:lang")]
    public string? Lang { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string? Name { get; set; }
}


public class Description
{
    [XmlElement(ElementName = "name")]
    public List<Name> Names { get; set; } = new();

    [XmlElement(ElementName = "version")]
    public Version? Version { get; set; }

    [XmlElement(ElementName = "long_desc")]
    public List<LongDescription> LongDescriptions { get; set; } = new();

    [XmlElement(ElementName = "short_desc")]
    public List<ShortDescription> ShortDescriptions { get; set; } = new();
}

public class Name
{
    [XmlAttribute(AttributeName = "xml:lang")]
    public string? Lang { get; set; }

    [XmlText]
    public string? Value { get; set; }
}


public class LongDescription
{
    [XmlAttribute(AttributeName = "xml:lang")]
    public string? Lang { get; set; }

    [XmlText]
    public string? Value { get; set; }
}

public class ShortDescription
{
    [XmlAttribute(AttributeName = "xml:lang")]
    public string? Lang { get; set; }

    [XmlText]
    public string? Value { get; set; }
}

public class Price
{
    [XmlAttribute(AttributeName = "gross")]
    public decimal Gross { get; set; }

    [XmlAttribute(AttributeName = "net")]
    public decimal Net { get; set; }

    [XmlAttribute(AttributeName = "vat")]
    public decimal Vat { get; set; }
}

public class Images
{
    [XmlElement(ElementName = "large")]
    public List<Image> LargeImages { get; set; } = new();
}

public class Image
{
    [XmlAttribute(AttributeName = "url")]
    public string? Url { get; set; }

}

public class Icons
{
    [XmlElement(ElementName = "icon")]
    public List<Icon> IconList { get; set; } = new();
}

public class Icon
{
    [XmlAttribute(AttributeName = "url")]
    public string? Url { get; set; }
}

public class Originals
{
    [XmlElement(ElementName = "iaiext:image", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
    public List<OriginalImage> OriginalImages { get; set; } = new();
}

public class OriginalImage
{
    [XmlAttribute(AttributeName = "url")]
    public string? Url { get; set; }

    [XmlAttribute(AttributeName = "width")]
    public int Width { get; set; }

    [XmlAttribute(AttributeName = "height")]
    public int Height { get; set; }
}

public class Sizes
{
    [XmlElement(ElementName = "size")]
    public List<Size> SizeList { get; set; } = new();
}

public class Size
{
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [XmlAttribute(AttributeName = "code_producer")]
    public string? CodeProducer { get; set; }

    [XmlAttribute(AttributeName = "code")]
    public string? Code { get; set; }

    [XmlAttribute(AttributeName = "weight")]
    public decimal Weight { get; set; }

    [XmlElement(ElementName = "price")]
    public Price? Price { get; set; }

    [XmlElement(ElementName = "srp")]
    public Price? SRP { get; set; }

    [XmlElement(ElementName = "stock")]
    public Stock? Stock { get; set; }
}

public class Stock
{
    [XmlAttribute(AttributeName = "unit")]
    public string? Unit { get; set; }

    [XmlText]
    public int Quantity { get; set; }
}

public class Parameters
{
    [XmlElement(ElementName = "parameter")]
    public List<Parameter> ParameterList { get; set; } = new();
}

public class Parameter
{
    [XmlAttribute(AttributeName = "iaiext:unit", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
    public string? Unit { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string? Value { get; set; }

    [XmlAttribute(AttributeName = "iaiext:value", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
    public string? ExtendedValue { get; set; }

    [XmlAttribute(AttributeName = "iaiext:xml:lang", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
    public string? Lang { get; set; }

    [XmlAttribute(AttributeName = "iaiext:name", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
    public string? Name { get; set; }
}

public class Group
{
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string? Name { get; set; }

    [XmlAttribute(AttributeName = "unit")]
    public string? Unit { get; set; }

    [XmlElement(ElementName = "description")]
    public string? Description { get; set; }
}

