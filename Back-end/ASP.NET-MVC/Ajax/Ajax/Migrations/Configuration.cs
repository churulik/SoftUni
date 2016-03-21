using System.IO;
using System.Runtime.Remoting.Channels;
using System.Web.Hosting;
using Ajax.Models;

namespace Ajax.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Ajax.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Ajax.Models.ApplicationDbContext";
        }

        protected override void Seed(Ajax.Models.ApplicationDbContext context)
        {
        }
    }
}
