using System;
using System.Collections.ObjectModel;
using System.Linq;
using ProductsShop.Data;
using ProductsShop.Models;

namespace ProductsShop.ConsoleApplication.InsertData
{
    public class InsertProductCategories
    {
        public static void Insert()
        {
            var context = new ProductsShopEntities();
           
            var productsToList = context.Products.ToList();
            var categoriesToList = context.Categories.ToList();

            var rand = new Random();

            var collectCategories = new Collection<Category>();

            for (int i = 0; i < productsToList.Count; i++)
            {
                var index = rand.Next(0, categoriesToList.Count);

                collectCategories.Add(categoriesToList[index]);

                productsToList[i].Categories.Add(collectCategories[i]);
            }
           
            context.SaveChanges();
        }
    }
}
