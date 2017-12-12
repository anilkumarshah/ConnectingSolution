using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSVSite.Models;

namespace TSVSite.Controllers
{
    public class CSController : Controller
    {
        BusinessLogicModel objBusinessLogicModel;
        // GET: CS
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            ViewBag.ShowDiv = false;
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(ContactUsModel objContactUsModel)
        {
            ViewBag.ShowDiv = false;
            try
            {
                if (ModelState.IsValid)
                {
                    objBusinessLogicModel = new BusinessLogicModel();
                    if (objBusinessLogicModel.AddContactUs(objContactUsModel))
                    {
                        ModelState.Clear();
                        ViewBag.ShowDiv = true;
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View();
            }
            finally
            {
                objBusinessLogicModel = null;
            }
        }
    }
}