using System;
using System.Collections.Generic;
using System.Xml;

namespace P03_ExtractArtistsAndNumberOfAlbums
{
    class ArtistsAndNumberOfAlbumsMain
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            XmlNode albumNode = catalog.DocumentElement;

            var albumDictionary = new Dictionary<string, int>();

            foreach (XmlNode artistAndNumOfAlbums in albumNode.ChildNodes)
            {
                var artist = artistAndNumOfAlbums["artist"].InnerText;

                if (albumDictionary.ContainsKey(artist))
                {
                    albumDictionary[artist] += 1;
                }
                else
                {
                    albumDictionary.Add(artist, 1);
                }
            }

            foreach (var artistName in albumDictionary)
            {
                Console.WriteLine("Artist name: {0} -- Number of albums: {1}", 
                    artistName.Key, artistName.Value);
               
            }
        }
    }
}
