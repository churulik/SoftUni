using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsDb.Data;
using NewsDd.Models;

namespace NewsDb.Client
{
    class AddNews
    {
        public static void ComputerScience()
        {
            var context = new NewsDbEntities();

            var newsA = new News()
            {
                Text = "The future of data science looks spectacular"
            };

            var newsB = new News()
            {
                Text = "New computer program first to recognise sketches more accurately than a human"
            };

            var newsC = new News()
            {
                Text = "How artificial intelligence is changing economic theory"
            };

            var newsD = new News()
            {
                Text = "Computer program fixes old code faster than expert engineers"
            };

            var newsE = new News()
            {
                Text = "A beautiful algorithm? The risks of automating online transactions"
            };


            context.News.Add(newsA);
            context.News.Add(newsB);
            context.News.Add(newsC);
            context.News.Add(newsD);
            context.News.Add(newsE);

            context.SaveChanges();
            Console.WriteLine("The 'Computer Science' news were successefully add in the NewsDb database.");
        }

        public static void Football()
        {

            var context = new NewsDbEntities();

            var newsA = new News()
            {
                Text = "Juventus - Milan"
            };

            var newsB = new News()
            {
                Text = "Barcelona - Real Madrid"
            };

            var newsC = new News()
            {
                Text = "Arsenal - Liverpool"
            };

            var newsD = new News()
            {
                Text = "PSG - Monaco"
            };

            var newsE = new News()
            {
                Text = "Bayern Munich - Borussia Dortmund"
            };

            context.News.Add(newsA);
            context.News.Add(newsB);
            context.News.Add(newsC);
            context.News.Add(newsD);
            context.News.Add(newsE);

            context.SaveChanges();

            Console.WriteLine("The 'Football' news were successefully add in the NewsDb database.");
        }
    }
}
