using Twitter.Data.Repository;
using Twitter.Models;

namespace Twitter.Data.UnitOfWork
{
    public interface ITwitterData
    {
        IRepository<User> Users { get; }
        IRepository<Tweet> Tweets { get; }
        IRepository<Message> Messages { get; }
        IRepository<Channel> Channels { get; }
        IRepository<Follow> Follows { get; }
        IRepository<Favorite> Favorites { get; }
        IRepository<Report> Reports { get; }
        IRepository<Replay> Replays { get; }
        IRepository<Notification> Notifications { get; }
        int SaveChanges();
    }
}