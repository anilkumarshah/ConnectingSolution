using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Vision()
        {
            return View();
        }
        public ActionResult Culture()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Affix()
        {
            return View();
        }
    }
}