using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();
           
            var mapper = Mapper.Map<ApplicationUser, AdminViewModel>(new ApplicationUser() {UserName = userName});
            var model = new AdminViewModel()
            {
                Username = userName
            };

            return View(mapper);
        }
    }
}