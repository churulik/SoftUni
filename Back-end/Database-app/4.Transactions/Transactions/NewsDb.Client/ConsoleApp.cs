using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Services;
using NewsDb.Data;

namespace NewsDb.Client
{
    class ConsoleApp
    {
        public static void Load()
        {
            var context = new NewsDbEntities();

            var loadNews = context.News;

            foreach (var news in loadNews)
            {
                Console.WriteLine("--{0}", news.Text);
            }
        }

        /// <summary>
        /// Enter the news Id that needs to be update; then the details.
        /// </summary>
        /// <param name="news">enter the Id of the news.</param>
        /// <param name="details">enter details.</param>
        public static void Update(int news,string details)
        {
            var contextUserA = new NewsDbEntities();

            var contextUserB = new NewsDbEntities();

            try
            {
                var chooseNewsA = contextUserA.News.First(n => n.Id == news);
                chooseNewsA.Text = chooseNewsA.Text + " --> " + details;

                var chooseNewsB = contextUserB.News.First(n => n.Id == news);
                chooseNewsB.Text = chooseNewsB.Text + " --> " + details;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: Enter a valid news Id.");
                Console.WriteLine(ex);
            }
            
            try
            {
                contextUserA.SaveChanges();
                Console.WriteLine("User A will see: Changes were successfully saved.");
                Console.WriteLine();
                Console.WriteLine("User B will see:");
                contextUserB.SaveChanges();
            }
            catch (DbUpdateConcurrencyException){
               var chooseNews = contextUserA.News.First(n => n.Id == news);
                var displayChanges = chooseNews.Text;

                Console.WriteLine("Error: One more person works on this news and his/her changes were saved.");
                Console.WriteLine();
                Console.WriteLine("The new text is: {0}", displayChanges);
                Console.WriteLine();
            }


            var contextUserC = new NewsDbEntities();

            var chooseNewsC = contextUserC.News.First(n => n.Id == news);
            
            Console.WriteLine("Enter the new update: ");

            var line = Console.ReadLine();

            var displayNewChanges = chooseNewsC.Text = chooseNewsC.Text + " --> " + line;

            contextUserC.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Changes were successfully saved.");
            Console.WriteLine();
            Console.WriteLine("The new news is: {0}", displayNewChanges);
           
        }
        
    }
}
