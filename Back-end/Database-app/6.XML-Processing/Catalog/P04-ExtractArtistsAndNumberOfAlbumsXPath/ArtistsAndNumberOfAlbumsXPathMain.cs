using System;
using System.Collections.Generic;
using System.Xml;

namespace P04_ExtractArtistsAndNumberOfAlbumsXPath
{
    class ArtistsAndNumberOfAlbumsXPathMain
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            var albumXPathQuery = "/catalog/album";

            var albumsList = catalog.SelectNodes(albumXPathQuery);

            var albumDictionary = new Dictionary<string, int>();

            foreach (XmlNode album in albumsList)
            {
                var artist = album.SelectSingleNode("artist").InnerText;

                if (albumDictionary.ContainsKey(artist))
                {
                    albumDictionary[artist] += 1;
                }
                else
                {
                    albumDictionary.Add(artist, 1);
                }
            }

            foreach (var artistAndNumOfAlbums in albumDictionary)
            {
                Console.WriteLine("Artist name: {0} -- Number of albums: {1}",
                    artistAndNumOfAlbums.Key, artistAndNumOfAlbums.Value);
            }
            
        }
    }
}
