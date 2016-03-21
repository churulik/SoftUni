using System;
using System.IO;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using MvcCaching.Models;

namespace MvcCaching.Controllers
{
    public class CachingUsersController : Controller
    {
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();

            var users = context.Users
                .Select(u => new UserVIewModel()
                {
                    Username = u.UserName
                });

            //check if session is null or users' count change
            if (Session["count"] == null || Convert.ToInt32(Session["count"]) != users.Count())
            {
                Session["count"] = users.Count();

                using (var file = new StreamWriter(Server.MapPath("~/Content/users.txt")))
                {
                    foreach (var user in users)
                    {
                        file.WriteLine(user.Username);
                    }
                }
            }

            if (this.HttpContext.Cache["users"] == null)
            {
                var path = Server.MapPath("~/Content/users.txt");

                using (var sr = System.IO.File.OpenText(path))
                {
                    var file = sr.ReadToEnd();
                    var split = file.Split('\n');
                    this.HttpContext.Cache.Insert("users", split, new CacheDependency(path));
                }
            }
            
            var result = this.HttpContext.Cache["users"];

            return View(result);
        }
    }
}