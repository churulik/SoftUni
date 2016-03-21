using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductsShop.Data;

namespace ProductsShop.ConsoleApplication.QueryAndExportData
{
    public class Query1
    {
        public static void ProductsInRange()
        {
            var context = new ProductsShopEntities();

            var products = context.Products;

            var getAllProducts = from p in products
                where p.Price >= 500 && p.Price <= 1000
                      && p.BuyerId == null
                orderby p.Price
                select new
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                    SellerName = p.Seller.FirstName + " " + p.Seller.LastName
                };

            var serializeProducts = JsonConvert.SerializeObject(getAllProducts, Formatting.Indented);

            File.WriteAllText(@"../../QueryAndExportData/JSON/product-in-range.json", serializeProducts);
            
            Console.WriteLine(serializeProducts);
        }
    }
}
