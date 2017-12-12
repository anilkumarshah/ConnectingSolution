using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSVSite.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult BusinessQuery()
        {
            return View();
        }

        public ActionResult BusinessQueryDetail()
        {
            return View();
        }
    }
}