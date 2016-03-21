using System;
using System.Linq;
using System.Xml.Linq;

namespace P07_OldAlbumsLINQ
{
    class OldAlbumsLinqMain
    {
        static void Main()
        {
            var catalog = XDocument.Load("../../../catalog.xml");

            var selectAlbums = from album in catalog.Descendants("album")
                where (int) album.Element("year") <= 2010
                select new
                {
                    Name = album.Element("name").Value,
                    Year = album.Element("year").Value,
                    Price = album.Element("price").Value
                };

            foreach (var selectAlbum in selectAlbums)
            {
                Console.WriteLine("Album name: {0}({1}) - {2} BGN", 
                    selectAlbum.Name, selectAlbum.Year, selectAlbum.Price);
            }

        }
    }
}
