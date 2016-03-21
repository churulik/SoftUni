using System.Linq;
using System.Xml.Linq;
using ProductsShop.Data;
using ProductsShop.Models;

namespace ProductsShop.ConsoleApplication.InsertData
{
    class InsertUser
    {
        public static void Insert()
        {
            var context = new ProductsShopEntities();

            var loadUsersXml = XDocument.Load("../../../users.xml");

            var getAttributesValue = from u in loadUsersXml.Descendants("users").Elements("user")
                          where u.Attribute("age") != null
                          select new
                          {
                              FirstName = u.Attribute("first-name") != null ? u.Attribute("first-name").Value : null,
                              LastName = u.Attribute("last-name").Value,
                              Age = u.Attribute("age").Value
                          };

            foreach (var getAttributeValue in getAttributesValue)
            {
                var newUser = new User()
                {
                    FirstName = getAttributeValue.FirstName,
                    LastName = getAttributeValue.LastName,
                    Age = int.Parse(getAttributeValue.Age)
                };

                context.Users.Add(newUser);
            }
            context.SaveChanges();
        }
    }
}
