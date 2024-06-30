
using System.Xml.Linq;

namespace Task2.Infrastructure
{
    public interface IProductReader
    {
        Task<T?> ReadAsync<T>() where T : class;
        XDocument ReadAsXDocument();
    }
}