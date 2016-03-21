using BookShop.Data.Migrations;
using BookShop.Models;

namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopEntities : DbContext
    {
       
        public BookShopEntities()
            : base("name=BookShopEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopEntities, Configuration>());
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }

    
}