using System.Data.Entity;
using BookShop.Data.Migrations;
using BookShop.Models;
using BookShop.Models.UserAuthentication;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data
{
    public class BookShopEntities : IdentityDbContext<ApplicationUser>
    {
        public BookShopEntities()
            : base("BookShopConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopEntities, Configuration>());
        }

        public static BookShopEntities Create()
        {
            return new BookShopEntities();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
    }
}