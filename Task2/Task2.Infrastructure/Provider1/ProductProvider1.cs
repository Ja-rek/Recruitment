using System.Xml.Linq;
using Task2.Application;

namespace Task2.Infrastructure.Provider1
{
    public class ProductProvider1(IProductReader xmlReader) : IProductProvider
    {
        private readonly IProductReader xmlReader = xmlReader;
        private const string lang = "pol";

        public async Task<IEnumerable<Contract.Product>> GetProductsAsync()
        {
            var doc = xmlReader.ReadAsXDocument();

            XNamespace iaiext = "http://www.iai-shop.com/developers/iof/extensions.phtml";

            var products = doc.Descendants("product");

            return products.Select(x => new Contract.Product
            {
                ProviderId = ((int?)x?.Attribute("id")) ?? 0,

                Name = x?.Element("description")?.Elements("name")
                    .FirstOrDefault(e => e.Name.LocalName == "name" && (string?)e?.Attribute(XNamespace.Xml + "lang") == lang)?.Value,

                Description = x?.Element("description")?.Elements("long_desc")
                    .FirstOrDefault(x => (string?)x.Attribute(XNamespace.Xml + "lang") == lang)?.Value
                    ?.Replace("/data/include/cms/newsletter-Jacek/honer_do_opisu.png", "https://sklep.fjordnansen.pl/data/include/cms/newsletter-Jacek/honer_do_opisu.png"), // fix for presentation

                Photo = x?.Descendants("image")
                    .Select(x => (string?)x.Attribute("url"))
                    .FirstOrDefault(),
                Variant = null 
            }).ToList();
        }
    }
}
