using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.Web.Models;
using Twitter.Web.Models.ViewModel;

namespace Twitter.Web.Controllers
{
    [System.Web.Mvc.Authorize]
    public class NotificationsController : BaseController
    {
        // GET: Notifications

        public ActionResult Notifications()
        {
            var userId = User.Identity.GetUserId();
            var channelId = this.Data.Channels.All()
                .Where(c => c.OwnerId == userId)
                .Select(c => c.Id).FirstOrDefault();

            var notifications = this.Data.Notifications.All()
                .Where(n => n.ChannelId == channelId)
                .OrderByDescending(n => n.Date)
                .Select(n => new NotificationsViewModel()
                {
                    Id = n.Id,
                    User = n.User,
                    Message = n.Message,
                    Date = n.Date,
                    Read = n.Read
                });

            //Update column 'Read'
            var updateNoty = this.Data.Notifications.All()
                .Where(n => n.ChannelId == channelId);
            foreach (var notification in updateNoty)
            {
                notification.Read = true;

            }
            this.Data.SaveChanges();

            Session["noty"] = 0;

            var model = new HomeModel()
            {
                EnumNotificationsViewModel = notifications
            };

         
            return View(model);
        }

        // GET: Notification
        public ActionResult Notification(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Notifications", "Notifications");
            }

            var userId = User.Identity.GetUserId();
            var channeId = this.Data.Channels.All()
                .Where(c => c.OwnerId == userId)
                .Select(c => c.Id).FirstOrDefault();

            var notification = this.Data.Notifications.All()
                .Where(n => n.Id == id && n.ChannelId == channeId)
                .Select(n => new NotificationsViewModel()
                {
                    User = n.User,
                    Message = n.Message,
                    Date = n.Date
                }).FirstOrDefault();

            if (notification == null)
            {
                return RedirectToAction("Notifications", "Notifications");
            }
            var model = new HomeModel()
            {
                NotificationsViewModel = notification
            };
            return View(model);
        }
    }
}