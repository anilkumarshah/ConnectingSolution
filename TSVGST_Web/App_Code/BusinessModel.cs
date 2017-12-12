using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BusinessModel
/// </summary>
namespace SKSBUsinessModel
{
    public class BusinessModel
    {
        public BusinessModel()
        {
            //
            // TODO: Add constructor logic here
            //
        }

    }
    public class mdl_BillDetails_temp
    {
        
        public int CompanyID { get; set; }
        public int ProductID { get; set; }
        public string HSNNo { get; set; }
        public int Qnty { get; set; }
        public decimal Rate { get; set; }
        public string UOM { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxableValue { get; set; }
        public decimal SGSTRate { get; set; }
        public decimal SGSTValue { get; set; }
        public decimal CGSTRate { get; set; }
        public decimal CGSTValue { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string GUID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}