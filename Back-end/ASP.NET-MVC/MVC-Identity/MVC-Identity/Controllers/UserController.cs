using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();

            var model = new UserViewModel()
            {
                Username = userName
            };
            
            return View(model);
        }
    }
}