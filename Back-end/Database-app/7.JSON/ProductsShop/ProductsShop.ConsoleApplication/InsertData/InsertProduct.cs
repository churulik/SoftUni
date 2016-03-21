using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Models;

namespace ProductsShop.ConsoleApplication.InsertData
{
    public class InsertProduct
    {
        public static void Insert()
        {
            var context = new ProductsShopEntities();

            var json = File.ReadAllText("../../../products.json");

            var getProducts = JsonConvert.DeserializeObject<List<GetProducts>>(json);

            //Get the first and last Users Id

            var firstId = context.Users.First().Id;
            var lastId = context.Users.OrderByDescending(i => i.Id).First().Id;
            
            
            //Insert, randomly, into array the BuyerId value

            var rand = new Random();

            var nullIndex = 1;

            var buyerArray = new int?[getProducts.Count];

            for (var i = 0; i < getProducts.Count; i++)
            {
                buyerArray[i] = rand.Next(firstId, lastId);

                nullIndex++;

                //Every 10th row will have a null value

                if (nullIndex != 10) continue;
                buyerArray[i] = null;
                nullIndex = 1;
            }

            //Insert, randomly, into array the SellerId value

            var sellerArray = new int[getProducts.Count];

            for (var i = 0; i < getProducts.Count; i++)
            {
                sellerArray[i] = rand.Next(firstId, lastId);
            }
            
            //Insert into Products

            var index = 0;
            
            foreach (var product in getProducts)
            {
                var newProduct = new Product()
                {
                    ProductName = product.Name,
                    Price = product.Price,
                    SellerId = sellerArray[index],
                    BuyerId = buyerArray[index]
                };
                context.Products.Add(newProduct);
                index++;
            }
            
            context.SaveChanges();
        }

        internal class GetProducts
        {
            public string Name { get; set; }

            public decimal Price { get; set; }
        }
       
    }
}
