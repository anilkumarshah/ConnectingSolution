using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRCode.Controllers
{
    public class BusinessAPIController : Controller
    {
        // GET: BusinessAPI
        //public ActionResult Index()
        //{
        //    return View();
        //}

       
        [Route("Disposition")]
        [HttpGet,HttpPost]
        public string Disposition(int disposition)
        {
            
            return "Your disposition value is " + Convert.ToString(disposition);
        }
    }
}