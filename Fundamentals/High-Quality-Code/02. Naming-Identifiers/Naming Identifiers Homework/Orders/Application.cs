using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Orders.Models;

namespace Orders
{
    class Application
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var getAllCategories = dataMapper.GetAllCategories();
            var getAllProducts = dataMapper.GetAllProducts();
            var getAllOrders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            var allProducts = getAllProducts as Product[] ?? getAllProducts.ToArray();
            var fiveMostExpensiceProducts = allProducts
                .OrderByDescending(p => p.UnitPrice)
                .Select(p => p.Name)
                .Take(5);
            Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiceProducts));

            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var numberOfProductsInEachCategory = allProducts
                .GroupBy(p => p.CategoryId)
                .Select(groupByCategoryId => new
                {
                    Name = getAllCategories.First(c => c.Id == groupByCategoryId.Key).Name,
                    Count = groupByCategoryId.Count()
                })
                .ToList();

            foreach (var category in numberOfProductsInEachCategory)
            {
                Console.WriteLine("{0}: {1}", category.Name, category.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var allOrders = getAllOrders as Order[] ?? getAllOrders.ToArray();

            var topFiveProducts = allOrders
                .GroupBy(o => o.ProductId)
                .Select(groupByProductId => new
                {
                    Name = allProducts.First(p => p.Id == groupByProductId.Key).Name,
                    Quantity = groupByProductId.Sum(p => p.Quantity)
                })
                .OrderByDescending(p => p.Quantity)
                .Take(5);

            foreach (var product in topFiveProducts)
            {
                Console.WriteLine("{0}: {1}", product.Name, product.Quantity);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var mostProfitableCategory = allOrders
                .GroupBy(o => o.ProductId)
                .Select(groupByProductId => new
                {
                    CategoryId = allProducts.First(p => p.Id == groupByProductId.Key).CategoryId,
                    ProductPrice = allProducts.First(p => p.Id == groupByProductId.Key).UnitPrice,
                    ProductQuantity = groupByProductId.Sum(p => p.Quantity)
                })
                .GroupBy(p => p.CategoryId)
                .Select(groupByCategoryId => new
                {
                    CategoryName = getAllCategories.First(c => c.Id == groupByCategoryId.Key).Name,
                    TotalQuantity = groupByCategoryId.Sum(c => c.ProductQuantity * c.ProductPrice)
                })
                .OrderByDescending(c => c.TotalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.CategoryName, mostProfitableCategory.TotalQuantity);
        }
    }
}
