using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using MvcCaching.Models;

namespace MvcCaching.Controllers
{
    public class RssFeedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
            
        [OutputCache(Duration = 60*5, VaryByParam = "none")]
        public PartialViewResult RssFeed()
        {
            var load = XDocument.Load("https://softuni.bg/feed/news");

            var result = load.Descendants("item")
                .Select(r => new RssFeedViewModel()
            {
                Title = r.Element("title").Value,
                Link = r.Element("link").Value
            });
                
            return PartialView("_RssFeed", result);
        }
    }
}