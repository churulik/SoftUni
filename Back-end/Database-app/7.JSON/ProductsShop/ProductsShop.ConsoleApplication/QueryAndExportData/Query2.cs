using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductsShop.Data;

namespace ProductsShop.ConsoleApplication.QueryAndExportData
{
    public class Query2
    {
        public static void SuccessfullySoldProducts()
        {
            var context = new ProductsShopEntities();

            var users = context.Users;

            var products = context.Products;

            var getAllUsers = from u in users
                join p in products on u.Id equals p.BuyerId
                where p.BuyerId != null
                orderby u.LastName, u.FirstName
                group p by new
                {
                    LastName = p.Seller.LastName,
                    FirstName = p.Seller.FirstName ?? "Unknown"
                }
                into g
                select new
                {
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    SoldProducts = from pr in g
                        select new
                        {
                            ProductName = pr.ProductName,
                            Price = pr.Price,
                            BuyerFirstName = pr.Buyer.FirstName ?? "Unknown",
                            BuyerLastNaem = pr.Buyer.LastName
                        }
                };

            var serializeUsers = JsonConvert.SerializeObject(getAllUsers, Formatting.Indented);

            File.WriteAllText(@"../../QueryAndExportData/JSON/successfully-sold-products.json", serializeUsers);

            Console.WriteLine(serializeUsers);

        }
    }
}
