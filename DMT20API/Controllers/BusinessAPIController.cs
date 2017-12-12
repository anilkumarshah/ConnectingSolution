using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMT20API.Controllers
{
    public class BusinessAPIController : Controller
    {
        [ActionName("Disposition")]
        [Route("api/BusinessAPI/Disposition/{disposition}")]
        [HttpGet]
        public string Disposition(int disposition)
        {

            return "Your disposition value is " + Convert.ToString(disposition);
        }
    }
}