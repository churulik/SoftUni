using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductsShop.Data;

namespace ProductsShop.ConsoleApplication.QueryAndExportData
{
    public class Query3
    {
        public static void CategoriesByProductsCount()
        {
            var context = new ProductsShopEntities();

            var categories = context.Categories;

            var getAllCategories = from c in categories
                orderby c.Products.Count
                select new
                {
                    CategoryName = c.CategoryName,
                    ProductsCount = c.Products.Count,
                    AveragePrice = c.Products.Average(a => a.Price),
                    TotalRevenue = c.Products.Sum(s => s.Price)
                };

            var serializeCategories = JsonConvert.SerializeObject(getAllCategories, Formatting.Indented);

            File.WriteAllText(@"../../QueryAndExportData/JSON/categories-by-products.json", serializeCategories);

            Console.WriteLine(serializeCategories);
        }
    }
}
