using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSVSite_Admin.Models;
using TSVSite_Admin.ef;

namespace TSVSite_Admin.Controllers
{
    public class BusinessController : Controller
    {
        CSDBEntities objCSDBEntities;
        BusinessContactUsReplyModel objBusinessContactUsReplyModel;
        // GET: Business
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult BusinessQuery()
        //{
        //    return View();
        //}
        public ActionResult ContactUsQuery()
        {
            objBusinessContactUsReplyModel = new BusinessContactUsReplyModel();
            objCSDBEntities = new CSDBEntities();
            var ContactUsItem = (from data in objCSDBEntities.vw_ContactUs
                                 select data).ToList();
            ViewBag.ContactUsList = ContactUsItem;
            //objBusinessContactUsReplyModel.objContactUsList = ProductData();
            //return View(objBusinessContactUsReplyModel);
            return View();
        }

        public ActionResult ContactUsQueryDetail(Int64 ContactUsID)
        {
            objBusinessContactUsReplyModel = new BusinessContactUsReplyModel();

            ViewBag.ContactUsIDDetails = new List<vw_ContactUs>(objBusinessContactUsReplyModel.getContactUsDetailByID(ContactUsID));
            return View();
        }

        [HttpPost]
        public ActionResult ContactUsQueryDetail(string txtContactUsID,string txtReply)
        {
            return View();
        }
        private List<ContactUSList> ProductData()
        {
            List<ContactUSList> objContactUsList = new List<ContactUSList>();
            CSDBEntities objCSDBEntities = new CSDBEntities();
            var ContactUsItem = (from data in objCSDBEntities.vw_ContactUs
                              select data).ToList();
            //objContactUsList=new List<ContactUSList>(ContactUsItem);
            //List<ContactUSList> objContactUsList1 = new List<ContactUSList>(ContactUsItem);
            //List<MyType> copy = new List<MyType>(original);
            //objContactUsList = (from data in objCSDBEntities.vw_ContactUs
            //                 select data).ToList();
            foreach (var item in ContactUsItem)
            {
                objContactUsList.Add(new ContactUSList
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    MobileNo = item.MobileNo,
                    BusinessWebsite = item.BusinessWebsite,
                    Subject = item.Subject,
                    BusinessMessage = item.BusinessMessage,
                    hasReplied = item.hasReplied,
                    ReplySentOn = Convert.ToString(item.ReplySentOn),
                    CreatedBy = item.CreatedBy,
                    CreatedOn = item.CreatedOn,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedOn = Convert.ToString(item.UpdatedOn)
                });
            }
            return objContactUsList;
        }
    }
}