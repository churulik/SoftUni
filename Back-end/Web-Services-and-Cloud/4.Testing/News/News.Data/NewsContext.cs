using News.Data.Migrations;

namespace News.Data
{
    using System.Data.Entity;
    using Models;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=NewsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsContext, Configuration>());
        }

        public virtual DbSet<News> News { get; set; }

        public virtual DbSet<TempNews> TempNews { get; set; } 
    }
}