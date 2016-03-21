using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Models;

namespace ProductsShop.ConsoleApplication.InsertData
{
    public class InsertCategory
    {
        public static void Insert()
        {
            var context = new ProductsShopEntities();

            var json = File.ReadAllText("../../../categories.json");

            var getCategories = JsonConvert.DeserializeObject<List<GetCategories>>(json);
           
            foreach (var category in getCategories)
            {
                var newCategory = new Category()
                {
                    CategoryName = category.Name
                };
                context.Categories.Add(newCategory);
            }

            context.SaveChanges();
        }
        internal class GetCategories
        {
            public string Name { get; set; }
        }
    }
}
