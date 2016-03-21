using System;

namespace _02.LaptopShop
{
    class Application
    {
        static void Main()
        {
            var hp = new Laptop("HP 250 G2", 699.096m);

            var lenovo = new Laptop("Lenovo Yoga 2 Pro", "Lenovo", 
                "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "Intel HD Graphics 4400", 
                "128GB SSD", "13.3\"(33.78 cm) – 3200 x 1800(QHD +), IPS sensor display",2259, 
                new Battery()
                {
                    Type = "Li-Ion",
                    Cells = 4,
                    MAh = 2550,
                    Life = 4.5
                });

            var dell = new Laptop("Dell XPS 13", "Dell", "5th Generation Intel® Core™ i3-5010U Processor (3M Cache, 2.10 GHz)", 
                "12 GB", "Intel (R) HD Graphics 5500", "128GB Solid State Drive", 
                "13.3-inch FHD (1920 x 1080) InfinityEdge Display", 1549.99m);

            Console.WriteLine(hp);
            Console.WriteLine(lenovo);
            Console.WriteLine(dell);
        }
    }
}
