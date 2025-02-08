using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class SiteInfoController : Controller
    {
        // GET: IpInfo
        public async Task<ActionResult> Index()
        {
            var weatherService = new WeatherForecastProvider();
            var res = await weatherService.GetAuthToken();
            return View(res);
        }

        
    }
}