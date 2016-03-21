using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XMLLibraryReader
{
    class Program
    {
        static void Main()
        {
            //var doc = new XmlDocument();
            //doc.Load("../../library.xml");

            //var bookNodes = doc.DocumentElement.ChildNodes;


            ////foreach (XmlNode bookNode in bookNodes)
            ////{
            ////    Console.WriteLine(bookNode.FirstChild.InnerText);
            ////}

            //var titleNodes = doc.SelectNodes("/library/book");
            //foreach (XmlElement titleNode in titleNodes)
            //{
            //    Console.WriteLine("Title: " + GetInnerValue(titleNode, "title"));
            //    Console.WriteLine("Author: " + GetInnerValue(titleNode, "author"));
            //    Console.WriteLine();
            //}

            XDocument doc = XDocument.Load("../../library.xml");
            var books = from book in doc.Descendants("book")
                let xElement = book.Element("title")
                where xElement != null
                where xElement.Value.Contains("4.0")
                select new
                {
                    Title = xElement.Value
                };

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }

        static string GetInnerValue(XmlElement element, string tagName)
        {
            if (element[tagName] != null)
            {
                return element[tagName].InnerText;
            }
            return "No " + tagName;
        }
    }
}
