using System;

namespace News.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "News.Data.NewsContext";
        }

        protected override void Seed(NewsContext context)
        {
            //context.News.AddOrUpdate(new News()
            //{
            //    Title = "Novina",
            //    Content = "Ochakvaite poveche...",
            //    PublishedDate = DateTime.Now.ToString("D")
            //},
            //new News()
            //{
            //    Title = "Novina vtora",
            //    Content = "Ochakvaite poveche ot novina vtora...",
            //    PublishedDate = DateTime.Now.ToString("D")
            //},
            //new News()
            //{
            //    Title = "Novina treta",
            //    Content = "Ochakvaite poveche ot novina treta...",
            //    PublishedDate = DateTime.Now.ToString("D")
            //});
        }
    }
}
