using System;
using System.Xml;

namespace P06_OldAlbums
{
    class Program
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            var albumXPathQuery = "/catalog/album[year <= 2010]";

            var albumList = catalog.SelectNodes(albumXPathQuery);

            foreach (XmlNode album in albumList)
            {
                var name = album.SelectSingleNode("name").InnerText;
                var year = album.SelectSingleNode("year").InnerText;
                var price = album.SelectSingleNode("price").InnerText;

                Console.WriteLine("Album name: {0}({1}) - {2} BGN", name, year, price);
            }
        }
    }
}
