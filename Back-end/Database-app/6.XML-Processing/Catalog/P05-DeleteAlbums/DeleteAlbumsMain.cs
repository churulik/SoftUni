using System;
using System.Xml;

namespace P05_DeleteAlbums
{
    class DeleteAlbumsMain
    {
        static void Main()
        {
            //Load catalog.xml
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            //Load cheap-albums-catalog.xml
            var cheapAlbumsCatalog = new XmlDocument();
            cheapAlbumsCatalog.Load("../../../cheap-albums-catalog.xml");
           
            //Get the albums with price > 20 using XPath
            var albumXPathQuery = "/catalog/album[price>20]";

            var albumsList = catalog.SelectNodes(albumXPathQuery);

            foreach (XmlNode album in albumsList)
            {
                //Import the albums with price > 20 into cheap-albums-catalog.xml
                var getAlbum = cheapAlbumsCatalog.ImportNode(album, true);
                cheapAlbumsCatalog.DocumentElement.AppendChild(getAlbum);
                
                cheapAlbumsCatalog.Save("../../../cheap-albums-catalog.xml");

                //Remove the albums with price > 20 from catalog.xml
                catalog.DocumentElement.RemoveChild(album);
                catalog.Save("../../../catalog.xml");
                
            }
            Console.WriteLine("The new albums were inserted into 'cheap-albums-catalog.xml' " +
                              "and the albums with price > 20 were removed from 'catalog.xml'");
     
        }
    }
}
