using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Twitter.Models;
using Twitter.Web.Hubs;
using Twitter.Web.Models;
using Twitter.Web.Models.ViewModel;

namespace Twitter.Web.Controllers
{
    public class TweetController : BaseController
    {
        // GET: Tweet
        public ActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }

        // POST: Tweet/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(HomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "User", model.TweetBindingModel);
            }

            var currentUserId = CurrentUserId();

            var channelId = this.Data.Channels.All()
                .Where(c => c.OwnerId == currentUserId)
                .Select(c => c.Id)
                .FirstOrDefault();

            var tweet = new Tweet()
            {
                
                CreatedByUserId = currentUserId,
                ChannelId = channelId,
                Content = model.TweetBindingModel.Content,
                CreatedOn = DateTime.Now.ToString("G")
            };

            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();

            TempData["NewTweet"] = "You add a new tweet!";

            //SignalR
            var channelName = this.Data.Channels.All()
                .Where(c => c.OwnerId == currentUserId)
                .Select(c => new
                {
                    c.FullName,
                    c.ImageUrl,
                    c.Username
                })
                .FirstOrDefault();

            var hub = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
            hub.Clients.All.postTweet(new HubViewModel()
            {
                FullName = channelName.FullName,
                ImageUrl = channelName.ImageUrl,
                Username = channelName.Username,
                Content = model.TweetBindingModel.Content,
                TweetId = tweet.Id,
                CreatedOn = tweet.CreatedOn
            });

            return RedirectToAction("Index", "User");
        }

        // GET: Tweet/Replay/{Id}
        [System.Web.Mvc.Authorize]
        public ActionResult Replay(int? id)
        {
            
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            //Get a tweet
            var tweet = Data.Tweets.All()
                .Where(t => t.Id == id)
                .Select(t => new TweetViewModel
                {
                    Id = t.Id,
                    Username = t.Channel.Username,
                    Content = t.Content,
                    CreatedOn = t.CreatedOn,
                    ImageUrl = t.Channel.ImageUrl

                }).FirstOrDefault();

            if (tweet == null)
            {
                return RedirectToAction("Index");
            }

            //Get replays
            var replays = this.Data.Replays.All()
                .Where(r => r.TweetId == id)
                .OrderByDescending(r => r.PostedOn)
                .Select(r => new ReplayViewModel()
                {
                    Username = r.Channel.Username,
                    ReplayText = r.ReplayText,
                    PostedOn = r.PostedOn,
                    ImageUrl = r.Channel.ImageUrl
                });

            var model = new HomeModel()
            {
                TweetViewModel = tweet,
                EnumReplayViewModel = replays
            };

            return View(model);
        }

        //POST: Tweet/Replay
        [System.Web.Mvc.Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Replay(HomeModel model)
        {
            var currentUserId = CurrentUserId();

            //Gew ch username
            var channelId = this.Data.Channels.All()
                .Where(u => u.OwnerId == currentUserId)
                .Select(u => u.Id)
                .FirstOrDefault();

            //Add replay to db
            var replay = new Replay()
            {
                ReplayText = model.ReplayBindingModel.ReplayText,
                TweetId = model.ReplayBindingModel.TweetId,
                UserId = currentUserId,
                PostedOn = DateTime.Now.ToString("G"),
                ChannelId = channelId
            };

            this.Data.Replays.Add(replay);

            //Update 'Reaplay' count in dbo.Tweets
            var tweet = this.Data.Tweets.All().FirstOrDefault(t => t.Id == model.ReplayBindingModel.TweetId);
            tweet.Replays += 1;

            this.Data.SaveChanges();

            return RedirectToAction("Replay", "Tweet", new {id = model.ReplayBindingModel.TweetId});
        }
        

        //POST: Tweet/Retweet
        [HttpPost]
        public ActionResult Retweet(HomeModel model)
        {
            var currentUserId = CurrentUserId();

            var username = this.Data.Channels.All()
               .Where(c => c.OwnerId == currentUserId)
               .Select(c => c.Username)
               .FirstOrDefault();

            var tweetOwnerId = this.Data.Tweets.All()
                .Where(t => t.Id == model.RetweetBindigModel.TweetId)
                .Select(t => t.Channel.Id).FirstOrDefault();

            //Retweet
            var retweet = new Tweet()
            {
                ChannelId = model.RetweetBindigModel.ChannelId,
                CreatedOn = model.RetweetBindigModel.CreatedOn,
                Content = model.RetweetBindigModel.Content,
                RetweetBy = currentUserId
            };

            this.Data.Tweets.Add(retweet);

            //Add notification
            var notification = new Notification()
            {
                User = username,
                ChannelId = tweetOwnerId,
                Message = "retweet your Tweet",
                Date = DateTime.Now.ToString("g")
            };

            this.Data.Notifications.Add(notification);
            this.Data.SaveChanges();
            
            //SignalR
            var notyCount = this.Data.Notifications.All().Count(n => n.ChannelId == tweetOwnerId && n.Read == false);
            var hub = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
            hub.Clients.All.newNoty(Session["increment"] = notyCount);

            return RedirectToAction("Index", "User");
        }

        //POST: Tweet/Favorite
        [HttpPost]
        public ActionResult Favorite(HomeModel model)
        {
            var currentUserId = CurrentUserId();

            var username = this.Data.Channels.All()
                .Where(c => c.OwnerId == currentUserId)
                .Select(c => c.Username)
                .FirstOrDefault();

            var alreadyFavorited = this.Data.Favorites.All()
                .FirstOrDefault(f => f.UserId == currentUserId && f.TweetId == model.FavoriteBindingModel.TweetId);

            var tweetOwnerId = this.Data.Tweets.All()
                .Where(t => t.Id == model.FavoriteBindingModel.TweetId)
                .Select(t => t.Channel.Id).FirstOrDefault();

            if (alreadyFavorited == null)
            {
                //Update dbo.Tweets > Favorites
                var tweet = this.Data.Tweets.Find(model.FavoriteBindingModel.TweetId);

                tweet.Favorites += 1;

                //Add the user that liked the tweet
                var favorite = new Favorite()
                {
                    UserId = currentUserId,
                    Username = username,
                    TweetId = model.FavoriteBindingModel.TweetId
                };

                this.Data.Favorites.Add(favorite);

                //Add notification
                var notification = new Notification()
                {
                    User = username,
                    ChannelId = tweetOwnerId,
                    Message = "favorited your Tweet",
                    Date = DateTime.Now.ToString("g")
                };

                this.Data.Notifications.Add(notification);

                this.Data.SaveChanges();
                //SignalR
                var notyCount = this.Data.Notifications.All().Count(n => n.ChannelId == tweetOwnerId && n.Read == false);
                var hub = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
                hub.Clients.All.newNoty(Session["increment"] = notyCount);
            }
            

            return RedirectToAction("Index", "User");
        }

        //POST: Tweet/Report
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report(HomeModel model)
        {
            var currentUserId = CurrentUserId();

            var report = new Report()
            {
                ReportProblem = model.ReportBindingModel.ReportProblem,
                UserId = currentUserId,
                TweetId = model.ReportBindingModel.TweetId
            };

            this.Data.Reports.Add(report);
            this.Data.SaveChanges();
            TempData["reportmsg"] = "Your request has been successfully send.";
            return RedirectToAction("Index", "User");
        }

        //DELETE: Tweet/Delete/{Id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "User");
            }

            var currentUserId = CurrentUserId();

            var tweet = this.Data.Tweets.All().FirstOrDefault(c => c.Id == id && c.CreatedByUserId == currentUserId);

            if (tweet == null)
            {
                return RedirectToAction("Index", "User");
            }
            this.Data.Tweets.Delete(tweet);
            this.Data.SaveChanges();

            TempData["deletemsg"] = "Tweet deleted";

            return RedirectToAction("Index", "User");
        }
    }
}