using System;
using System.Linq;
using BookShop.Data;

namespace BookShop.Client
{
    class Client
    {
        static void Main()
        {
            var context = new BookShopEntities();

            Console.WriteLine(context.Books.Count());
        }
    }
}
