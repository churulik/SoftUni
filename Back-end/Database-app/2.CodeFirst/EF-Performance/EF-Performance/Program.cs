using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;

namespace EF_Performance
{
    class Program
    {
        static void Main()
        {
            var context = new AdsEntities();

            var ads = context.Ads                
                .Where(a => a.AdStatus.Status == "Published")
                .Where(a => a.CategoryId != null)
                .Where(a => a.TownId != null)
                .Select(a => new
                {
                    a.Title,
                    a.CategoryId,
                    a.TownId,
                    a.Date
                })
                .OrderBy(a => a.Date).ToList();
           
           

            var stopwatch = new Stopwatch();
           

            var avg = stopwatch.Elapsed;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                foreach (var ad in ads)
                {
                    Console.WriteLine("{0} {1} {2}", ad.Title, ad.TownId, ad.CategoryId);
                }

                Console.WriteLine("To list : {0}", stopwatch.Elapsed);
                Console.WriteLine();
                avg += stopwatch.Elapsed;
                stopwatch.Restart();
            }
            Console.WriteLine("To list avg: {0}", avg);
            Console.WriteLine("To list avg: {0}", avg.Milliseconds);
            Console.WriteLine("To list avg: {0}", avg.Milliseconds / 10);
            stopwatch.Stop();
            
        }
    }
}
