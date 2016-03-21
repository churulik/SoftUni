using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PCCatalog
{
    class Catalog
    {
        static void Main()
        {
            var lenovo = new Computer("Lenovo", 1300);

            var apple = new Computer("Apple",
                new List<Component>()
                {
                    new Component()
                    {
                        Name = "Ram",
                        Price = 120.00m
                    },
                    new Component()
                    {
                        Name = "Graphic card",
                        Details = "Intel Core 7",
                        Price = 150
                    }
                }, 
                1999.99m);

            var acer = new Computer("Acer",
                new List<Component>()
                {
                    new Component()
                    {
                        Name = "Screen",
                        Price = 300.50m
                    }
                }, 
                1199.99m);
            
            var listComputers = new List<Computer> {acer, apple, lenovo};
            var sort = listComputers.OrderBy(c => c.Price);
           
            foreach (var computer in sort)
            {
                Console.WriteLine(computer);
            }
            
          
        }
    }
}
