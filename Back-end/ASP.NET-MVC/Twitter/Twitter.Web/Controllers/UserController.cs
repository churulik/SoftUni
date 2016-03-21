using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using PagedList;
using Twitter.Models;
using Twitter.Web.Hubs;
using Twitter.Web.Models;
using Twitter.Web.Models.ViewModel;

namespace Twitter.Web.Controllers
{
    [System.Web.Mvc.Authorize]
    public class UserController : BaseController
    {
        // GET: User/Index
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var currentUserId = CurrentUserId();

            var getChannel = this.Data.Channels.All()
                .Where(c => c.OwnerId == currentUserId)
                .Select(c => new ChannelViewModel()
                {
                    ChannelId = c.Id,
                    FullName = c.FullName,
                    Username = c.Username,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl

                }).FirstOrDefault();

            if (getChannel == null)
            {
                return RedirectToAction("Set", "User");
            }
            
            //Display tweets
            var tweets = this.Data.Follows.All()
                .Where(f => f.UserId == currentUserId)
                .OrderByDescending(f => f.Id)
                .Select(f => new FollowViewModel()
                {
                    Tweets = f.Channel
                    .Tweets
                    .Where(t => t.RetweetBy == null)
                    .OrderByDescending(t => t.Id)
                    .Select(
                    t => new TweetViewModel()
                    {
                        Id = t.Id,
                        ChannelId = t.ChannelId,
                        FullName = t.Channel.FullName,
                        Username = t.Channel.Username,
                        ImageUrl = t.Channel.ImageUrl,
                        CreatedOn = t.CreatedOn,
                        Content = t.Content,
                        FavoritesCount = t.Favorites,
                        ReplaysCount = t.Replays
                    })
                });
            
            var model = new PagedList<FollowViewModel>(tweets, page, pageSize);

         
            //Who to follow - Sidebar
            var channels = this.Data.Channels.All()
                .Where(c => c.OwnerId != currentUserId)
                .Select(c => new ChannelViewModel()
                {
                    ChannelId = c.Id,
                    FullName = c.FullName,
                    Username = c.Username,
                    Description = c.Description
                });

            //Get notifications count
            var notifications = this.Data.Notifications.All()
                .Count(n => n.ChannelId == getChannel.ChannelId && n.Read == false);

            Session["noty"] = notifications;

            var mymodel = new HomeModel
            {
                FollowViewModel = model,
                EnumChannelViewModel = channels,
                ChannelViewModel = getChannel
            };

            return View(mymodel);
        }

        //GET: Tweet/Show/{ChannelId}
        [AllowAnonymous]
        public ActionResult Show(string channelName)
        {

            var currentUserId = CurrentUserId();

            var getChannel = this.Data.Channels.All().FirstOrDefault(c => c.OwnerId == currentUserId);

            if (getChannel == null && currentUserId != null)
            {
                return RedirectToAction("Set", "User");
            }

            if (channelName == null)
            {
                return RedirectToAction("Index", "Tweet");
            }

            var channel = this.Data.Channels.All()
                .Where(c => c.Username == channelName)
                .Select(c => new ChannelViewModel()
                {
                    ChannelId = c.Id,
                    FullName = c.FullName,
                    Username = c.Username,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl

                }).FirstOrDefault();
            
            var tweets = this.Data.Tweets.All()
              .Where(t => t.Channel.Username == channelName || t.RetweetBy != null)
              .OrderByDescending(t => t.CreatedOn)
              .Select(t => new TweetViewModel()
              {
                  Id = t.Id,
                  FullName = t.Channel.FullName,
                  Username = t.Channel.Username,
                  CreatedOn = t.CreatedOn,
                  Content = t.Content,
                  ImageUrl = t.Channel.ImageUrl,
                  FavoritesCount = t.Favorites,
                  ReplaysCount = t.Replays,
                  MyUsername = channelName
              });

            //Following
            var following = this.Data.Follows.All()
                .Where(f => f.FollowerUsername == channelName)
                .Select(c => new ChannelViewModel()
                {
                    FullName = c.Channel.FullName,
                    Username = c.Channel.Username
                });

            //Followers
            var followers = this.Data.Follows.All()
                .Where(c => c.ChannelId == channel.ChannelId)
                .Select(c => new FollowersViewModel()
                {
                    FullName = c.FollowerFullName,
                    Username = c.FollowerUsername
                });

            //Favorites
            var favorites = this.Data.Favorites.All()
                .Where(f => f.Username == channelName)
                .Select(f => new FavoriteViewModel()
                {
                    Id = f.TweetId,
                    FullName = f.Tweet.Channel.FullName,
                    Username = f.Tweet.Channel.Username,
                    Content = f.Tweet.Content,
                    CreatedOn = f.Tweet.CreatedOn
                });

            var model = new HomeModel()
            {
                ChannelViewModel = channel,
                EnumTweetViewModel = tweets,
                EnumChannelViewModel = following,
                EnumFollowersViewModel = followers,
                EnumFavoriteViewModel = favorites
            };

            return View(model);

        }

        // GET: User/Set
        public ActionResult Set()
        {
            //Check if the user created a channel
            var currentUserId = CurrentUserId();
            var getChannel = this.Data.Channels.All().FirstOrDefault(c => c.OwnerId == currentUserId);
            if (getChannel != null)
            {
                return RedirectToAction("New", "Tweet");
            }
            return View();
        }

        // POST: User/Set
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Set(HomeModel model)
        {
            //Check if model is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var getChannel = this.Data.Channels.All()
                .FirstOrDefault(c => c.Username == model.ChannelBindingModel.Username);
            if (getChannel != null)
            {
                ModelState.AddModelError(string.Empty, "The username already exists.");
                return View();
            }

            //Add channel
            var userId = User.Identity.GetUserId();
            var addChannel = new Channel()
            {
                FullName = model.ChannelBindingModel.FullName,
                Username = model.ChannelBindingModel.Username,
                Description = model.ChannelBindingModel.Description,
                OwnerId = userId,
                ImageUrl = model.ChannelBindingModel.ImageUrl ?? "https://www.socialhub.directory/sites/all/themes/core/images/default-user.png"
            };

            this.Data.Channels.Add(addChannel);
            this.Data.SaveChanges();

            return RedirectToAction("Index", "User");
        }

        //GET User/Follow/{id}
        public ActionResult Follow(int id)
        {
            var currentUserId = CurrentUserId();
            var username = this.Data.Channels.All()
                .Where(c => c.OwnerId == currentUserId)
                .Select(c => new
                {
                    c.FullName,
                    c.Username

                }).FirstOrDefault();

            var tweetOwnerId = this.Data.Tweets.All()
               .Where(t => t.Id == id)
               .Select(t => t.Channel.Id).FirstOrDefault();

            var dbFollow = this.Data.Follows.All().FirstOrDefault(f => f.ChannelId == id && f.UserId == currentUserId);
            if (dbFollow == null)
            {
                var follow = new Follow()
                {
                    UserId = currentUserId,
                    ChannelId = id,
                    FollowerUsername = username.Username,
                    FollowerFullName = username.FullName
                };

                this.Data.Follows.Add(follow);

                //Add notification
                var notification = new Notification()
                {
                    User = username.Username,
                    ChannelId = tweetOwnerId,
                    Message = "followed you",
                    Date = DateTime.Now.ToString("g")
                };

                this.Data.Notifications.Add(notification);
                this.Data.SaveChanges();

                //SignalR
                var notyCount = this.Data.Notifications.All().Count(n => n.ChannelId == tweetOwnerId && n.Read == false);
                var hub = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
                hub.Clients.All.newNoty(Session["increment"] = notyCount);
            }
            return RedirectToAction("Index");
        }

        //DELETE User/Unfollow/{id}

        //public ActionResult Unfollow(int id)
        //{
        //    var unfollow = this.Data.Follows.All().FirstOrDefault(unf => unf.Id == id);
        //    this.Data.Follows.Delete(unfollow);
        //    this.Data.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}