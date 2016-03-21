using NewsDd.Models;

namespace NewsDb.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsDbEntities : DbContext
    {
        // Your context has been configured to use a 'NewsDbEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'NewsDb.Data.NewsDbEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NewsDbEntities' 
        // connection string in the application configuration file.
        public NewsDbEntities()
            : base("name=NewsDbEntities")
        {
        }

        public virtual DbSet<News> News { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}