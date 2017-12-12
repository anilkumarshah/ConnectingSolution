using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSVSite.Models;
using TSVSite.ef;

namespace TSVSite.Models
{
    public class BusinessLogicModel
    {
        public bool AddContactUs(ContactUsModel objContactUsModel)
        {
            try
            {
                CSDBEntities objCSDBEntities = new CSDBEntities();
                tbl_ContactUS objtblContactUS = new tbl_ContactUS();
                objtblContactUS.Name = objContactUsModel.Name;
                objtblContactUS.MobileNo = objContactUsModel.MobileNo;
                objtblContactUS.Email= objContactUsModel.Email;
                objtblContactUS.BusinessWebsite = objContactUsModel.BusinessWebsite;
                objtblContactUS.Subject = objContactUsModel.Subject;
                objtblContactUS.BusinessMessage = objContactUsModel.BusinessMessage;
                objCSDBEntities.tbl_ContactUS.Add(objtblContactUS);
                objCSDBEntities.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
    }
}