using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() : this(new TwitterData(new TwitterDbContext()))
        {
            
        }

        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        protected ITwitterData Data { get; set; }

        public string CurrentUserId()
        {
            var currentUser = this.User.Identity.GetUserId();
            return currentUser;
        }
    }
}