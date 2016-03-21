using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Data.Migrations;
using Twitter.Models;

namespace Twitter.Data
{
    public class TwitterDbContext : IdentityDbContext<User>
    {
        public TwitterDbContext()
            : base("TwitterConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<Channel> Channels { get; set; }
        public virtual IDbSet<Follow> Follows { get; set; }
        public virtual IDbSet<Favorite> Favorites { get; set; }
        public virtual IDbSet<Report> Reports { get; set; }
        public virtual IDbSet<Replay> Replays { get; set; }
        public virtual IDbSet<Notification> Notifications { get; set; }
    }

    
}