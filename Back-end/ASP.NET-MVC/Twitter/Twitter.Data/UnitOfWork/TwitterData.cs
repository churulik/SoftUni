using System;
using System.Collections.Generic;
using System.Data.Entity;
using Twitter.Data.Repository;
using Twitter.Models;

namespace Twitter.Data.UnitOfWork
{
    public class TwitterData : ITwitterData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TwitterData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }


        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public IRepository<Message> Messages
        {
            get { return this.GetRepository<Message>(); }
        }

        public IRepository<Channel> Channels
        {
            get { return this.GetRepository<Channel>(); }
        }

        public IRepository<Follow> Follows
        {
            get { return this.GetRepository<Follow>(); }
            
        }

        public IRepository<Favorite> Favorites
        {
            get { return this.GetRepository<Favorite>(); }
        }

        public IRepository<Report> Reports
        {
            get { return this.GetRepository<Report>(); }
        }

        public IRepository<Replay> Replays
        {
            get { return this.GetRepository<Replay>(); }
        }

        public IRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(
                    typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }

    }
}