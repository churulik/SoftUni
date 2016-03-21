using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Ajax.Migrations;
using Ajax.Models;

namespace Ajax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            var context = new ApplicationDbContext();

            if (context.Cities.FirstOrDefault() == null)
            {
                var citiesReader = new StreamReader(Server.MapPath("~/Content/cities.txt"));
                var cities = citiesReader.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var cityName in cities)
                {
                    context.Cities.Add(new City()
                    {
                        Name = cityName
                    });
                }
                context.SaveChanges();
            }

            return View();
        }

        public ActionResult Cities(string city)
        {

            var context = new ApplicationDbContext();

            IEnumerable<string> citiesResult = Enumerable.Empty<string>();

            if (!string.IsNullOrEmpty(city))
            {

                citiesResult = context
                    .Cities.Where(c => c.Name.StartsWith(city))
                    .Select(c => c.Name)
                    .Take(10);
            }
            return this.Json(citiesResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}