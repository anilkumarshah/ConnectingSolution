using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data;
using TSVSite_Admin.ef;

namespace TSVSite_Admin.Models
{
    public class BusinessContactUsReplyModel
    {
        public Int64 ContactUsId { get; set;}
        public string BusinessMessageReplied { get; set; }
        public DateTime ReplySentOn { get; set;}
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        
        public List<ContactUSList> objContactUsList { get; set; }

        private DataTable dtRecord;
        private CSDBEntities objCSDBEntities;

        public List<vw_ContactUs> getContactUsDetailByID(Int64 ContactUsID)
        {
            List<vw_ContactUs> objvw_ContactUsList = new List<vw_ContactUs>();
            try
            {
                objCSDBEntities = new CSDBEntities();
                
               

                objvw_ContactUsList = (from Data in objCSDBEntities.vw_ContactUs where Data.Id == ContactUsID select Data).ToList();
                //dtRecord= tmpRecord.to
                return objvw_ContactUsList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objvw_ContactUsList = null;
                objCSDBEntities = null;
            }
        }
    }
    public class ContactUSList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
        public string MobileNo { get; set;}
        public string BusinessWebsite { get; set;}
        public string Subject { get; set;}
        public string BusinessMessage { get; set;}
        public string hasReplied { get; set;}
        public string ReplySentOn { get; set;}
        public string CreatedBy { get; set;}
        public string CreatedOn { get; set;}
        public string UpdatedBy { get; set;}
        public string UpdatedOn { get; set;}
    }

}