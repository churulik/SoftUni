using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using PagedList;
using Twitter.Models;
using Twitter.Web.Models;
using Twitter.Web.Models.BindingModel;
using Twitter.Web.Models.ViewModel;

namespace Twitter.Web.Controllers
{
    public class HomeController : BaseController
    {
        //GET: Home
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var userId = User.Identity.GetUserId();

            if (userId != null)
            {
                return RedirectToAction("Index", "User");
            }

            var tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.CreatedOn)
                .Select(t => new TweetViewModel()
                {
                    Id = t.Id,
                    ChannelId = t.ChannelId,
                    FullName = t.Channel.FullName,
                    Username = t.Channel.Username,
                    CreatedOn = t.CreatedOn,
                    Content = t.Content
                });

            PagedList<TweetViewModel> model = new PagedList<TweetViewModel>(tweets, page, pageSize );

            var channels = this.Data.Channels.All()
                .Where(c => c.OwnerId != userId)
                .Select(c => new ChannelViewModel()
                {
                    ChannelId = c.Id,
                    FullName = c.FullName,
                    Username = c.Username,
                    Description = c.Description
                });

            HomeModel mymodel = new HomeModel
            {
                PageListTweetViewModel = model,
                EnumChannelViewModel = channels
            };

            return View(mymodel);
        }

        //GET
        public ActionResult Channels()
        {
            var channels = this.Data.Channels.All()
                .Select(c => new ChannelViewModel()
                {
                    FullName = c.FullName,
                    Username = c.Username,
                    Description = c.Description
                });
            return View(channels);
        }
    }
}