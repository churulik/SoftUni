using System.Data.Entity.Migrations.Infrastructure;

namespace ProductsShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShop.Data.ProductsShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProductsShop.Data.ProductsShopEntities";
        }

        protected override void Seed(ProductsShop.Data.ProductsShopEntities context)
        {
           
        }
    }
}
