using System;
using System.Collections.Generic;

namespace News.Data
{
    using Models;
    public class MockDb
    {
        public static List<News> News()
        {
            var news = new List<News>
            {
                new News()
                {
                    Id = 1,
                    Title = "Novini",
                    Content = "Sadarjanie",
                    PublishedDate = DateTime.Now.ToString("D")
                },
                new News()
                {
                    Id = 2,
                    Title = "Sport",
                    Content = "Sadarjanie",
                    PublishedDate = DateTime.Now.ToString("D")
                },
                new News()
                {
                    Id = 3,
                    Title = "Moda",
                    Content = "Sadarjanie",
                    PublishedDate = DateTime.Now.ToString("D")
                }
            };

            return news;
        }
    }
}