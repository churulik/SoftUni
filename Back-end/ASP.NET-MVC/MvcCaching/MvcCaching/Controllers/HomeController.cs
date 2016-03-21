using System.Web.Mvc;
using System.Web.UI;

namespace MvcCaching.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 15, VaryByParam = "none", Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}