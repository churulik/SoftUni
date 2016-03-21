using System;
using System.Xml;

namespace P01_ExtractAlbumsNames
{
    class AlbumNamesMain
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            XmlNode rootNode = catalog.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                Console.WriteLine("Album name: " + node["name"].InnerText);
            }
        }
    }
}
