using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationRestService.Controllers
{
    public class PointsController : ApiController
    {
        [HttpGet]
        public double Distance(int startX, int startY, int endX, int endY)
        {
            var result = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
            return result;
        }
    }
}
