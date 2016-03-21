using System;
using System.Linq;
using System.Xml.Linq;
using ProductsShop.Data;

namespace ProductsShop.ConsoleApplication.QueryAndExportData
{
    public class Query4
    {
        public static void UsersAndProducts()
        {
            var context = new ProductsShopEntities();

            var users = context.Users;

            var products = context.Products;

            var getAllUsers = from u in users
                join p in products on u.Id equals p.BuyerId
                where p.BuyerId != null && u.FirstName != null
                orderby u.LastName
                group p by new
                {
                    p.Buyer.FirstName,
                    p.Buyer.LastName,
                    p.Buyer.Age
                }
                into g
                select new
                {
                    g.Key.FirstName,
                    g.Key.LastName,
                    g.Key.Age,
                    Product = from pr in g
                        select new
                        {
                            pr.ProductName,
                            pr.Price
                        }
                };
            var count = 0;
            var totalCaount = 0;

            var xmlUsers = new XElement("users");
            
            foreach (var user in getAllUsers)
            {
                var xmlSingleUser = new XElement("user");
                xmlSingleUser.Add(new XAttribute("first-name", user.FirstName));
                xmlSingleUser.Add(new XAttribute("last-name", user.LastName));
                xmlSingleUser.Add(new XAttribute("age", user.Age));
                
                var xmlSoldProducts = new XElement("sold-products");

                foreach (var product in user.Product)
                {
                    var xmlProduct = new XElement("product");
                    xmlProduct.Add(new XAttribute("name", product.ProductName));
                    xmlProduct.Add(new XAttribute("price", product.Price));
                    xmlSoldProducts.Add(xmlProduct);
                    count++;
                    totalCaount++;
                }

                xmlSoldProducts.Add(new XAttribute("count", count));

                xmlSingleUser.Add(xmlSoldProducts);

                xmlUsers.Add(xmlSingleUser);

                count = 0;
            }
            xmlUsers.Add(new XAttribute("count", totalCaount));

            Console.WriteLine(xmlUsers);

            var xmlDoc = new XDocument(xmlUsers);
            xmlDoc.Save("../../QueryAndExportData/XML/users-and-products.xml");
        }
    }
}
