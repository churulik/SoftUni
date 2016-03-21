using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace P02_ExtractAllArtistsAlphabetically
{
    class ArtistsMain
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            XmlNode rootNode = catalog.DocumentElement;

            var artistsList = new SortedSet<string>();
            
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                artistsList.Add(node["artist"].InnerText);
            }

            foreach (var artist in artistsList)
            {
                Console.WriteLine("Artist name: " + artist);
            }
        }
    }
}
