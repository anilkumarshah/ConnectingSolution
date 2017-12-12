using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APIUtility.Models;
using APIUtility.EF;

namespace APIUtility.Controllers
{
    public class RemittanceController : Controller
    {
        // GET: Remittance
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgentCreation()
        {
            //RemittanceDataModal obj = new RemittanceDataModal();

            //EF_TranServEntities objEF_TranServEntities = new EF_TranServEntities();
            //List<tbl_StateMaster> objddlStateMaster = (from StateMaster in objEF_TranServEntities.tbl_StateMaster where StateMaster.IsActive == true && StateMaster.IsDeleted == false select StateMaster).ToList();
            //ViewBag.CategoryList = new SelectList(objddlStateMaster, "StateID", "StateName");
            List<SelectListItem> ObjItem = new List<SelectListItem>()
            {
          new SelectListItem {Text="Select",Value="0",Selected=true },
          new SelectListItem {Text="ASP.NET",Value="1" },
          new SelectListItem {Text="C#",Value="2"},
          new SelectListItem {Text="MVC",Value="3"},
          new SelectListItem {Text="SQL",Value="4" },
            };
            ViewBag.ListItem = ObjItem;
            ViewBag.RemoteIP=System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            return View();
        }
        [HttpPost]
        public ActionResult AgentCreation(RemittanceDataModal objRemittanceDataModal)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                
                return View();
            }
        }
        public ActionResult SendMail()
        {
            return View();
        }
    }
}