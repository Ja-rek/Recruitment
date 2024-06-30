using System.Xml.Linq;
using System.Xml.Serialization;

namespace Task2.Infrastructure
{
    public class XmlProductReader(string file) : IProductReader
    {
        private readonly string file = file;

        public XDocument ReadAsXDocument()
        {
            var filePath = GetPath();

            return XDocument.Load(filePath); 
        }

        public async Task<T?> ReadAsync<T>() where T : class
        {
            var filePath = GetPath();

            var xml = await File.ReadAllTextAsync(filePath);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                return (T?)serializer.Deserialize(reader);
            }
        }

        private string GetPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../", 
                "./Task2.Infrastructure/", 
                file);
        }
    }
}
