using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIUtility.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtUserName, string txtPassword)
        {
            if (txtUserName != "" & txtPassword != "")
            {
                Session["UserName"] = txtUserName;

                return RedirectToAction("Home", "Home");
            }
            else
            {
                return View();
            }
        }
        
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            return View();
        }
    }
}