using System;
using System.Xml.Linq;

namespace P08_DirectoryContentsAsXML
{
    class DirectoryContentsAsXmlMain
    {
        static void Main()
        {
            var xDocument = new XDocument(
                    new XElement("root-dir", new XAttribute("path", "C:\\Example"),
                        new XElement("dir", new XAttribute("name", "docs"),
                            new XElement("file", new XAttribute("name", "tutorial.pdf")),
                            new XElement("file", new XAttribute("name", "TODO.txt")),
                            new XElement("file", new XAttribute("name", "Presentation.pptx"))
                            ),
                        new XElement("dir", new XAttribute("name", "photos"),
                            new XElement("dir", new XAttribute("name", "birthday-4-march"),
                                    new XElement("file", new XAttribute("name", "friends.jpg")),
                                    new XElement("file", new XAttribute("name", "the_cake.jpg")),
                                    new XElement("file", new XAttribute("name", "baloons.jpg"))),

                             new XElement("dir", new XAttribute("name", "travel"),
                                 new XElement("file", new XAttribute("name", "IMG24152.jpg"))))));


            xDocument.Save("../../../dir-xdoc.xml");
            //Console.WriteLine(xDocument);
        }
    }
}
