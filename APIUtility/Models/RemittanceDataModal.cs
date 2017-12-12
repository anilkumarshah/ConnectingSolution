using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using APIUtility.EF;
using APIUtility.Models;

namespace APIUtility.Models
{
    public class tbl_RemittanceAgentDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Agentid { get; set; }

        [DisplayName("Distributor Mobile No")]
        [Required(ErrorMessage = "Enter Distributor Mobile Number")]
        public string DistributorMobileNo { get; set; }

        [Required]
        [DisplayName("Distributor Email ID")]
        public string DistributorEmailID { get; set; }

        [Required]
        [DisplayName("Agent Mobile No")]
        public string AgentMobileNo { get; set; }

        [Required]
        [DisplayName("Agent Email ID")]
        public string AgentEmailID { get; set; }

        [Required]
        [DisplayName("Agent API User Name")]
        public string AgentAPIUserName { get; set; }

        [Required]
        [DisplayName("Agent API Password")]
        public string AgentAPIPassword { get; set; }

        [DisplayName("Agent API Confirm Password")]
        public string AgentAPIConfirmPassword { get; set; }

        [Required]
        [DisplayName("Agent System IP")]
        public string AgentSystemIP { get; set; }

        [DisplayName("Distributor Code")]
        public string DistributorCode { get; set; }

        [DisplayName("Agent Code")]
        public string AgentCode { get; set; }

        [DisplayName("State")]
        public string ddlStateID { get; set; }
        //  public string AgentSystemIP { get; set; }
    }
    public class RemittanceDataModal : tbl_RemittanceAgentDetails
    {
        [Key]
        public string TrNo { get; set; }

        public IEnumerable<tbl_StateMaster> getStateName()
        {
            try
            {
                EF_TranServEntities objEF_TranServEntities = new EF_TranServEntities();
                List<tbl_StateMaster> ObjStateMaster =(from StateMaster in objEF_TranServEntities.tbl_StateMaster where StateMaster.IsActive == true && StateMaster.IsDeleted == false select StateMaster).ToList();
                return ObjStateMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }



    }
    public class ddlStateMaster
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
    public class mSendMail
    {
        [DisplayName("To")]
        [Required(ErrorMessage = "Enter Mail Address")]
        public string strMailTo { get; set; }

        [DisplayName("CC")]
        public string StrMailCC { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "Enter Mail Subject")]
        public string strMailSubject { get; set; }

        public bool boolMailIsHTML { get; set; }

        public string strMailSMTPServer { get; set; }

        public string strMailSMTPPort { get; set; }

        public string strMailCredentialUserName { get; set; }

        public string strMailCredentialPassword { get; set; }
    }
}