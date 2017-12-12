using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class frmCompanyMaster : System.Web.UI.Page
{
    private BusinessFacadLayer objBusinessFacadLayer;
    private DataTable dtRecords;
    private int intCompanyID, RowIndex;
    private bool blnEnableDisable, blnDelete;
    private static BusinessFacadLayer objBusinessFacadLayer_Static;
    private static tbl_CompanyMaster objCompanyMaster_Static;
    private static int isExist;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //trAddNew.Visible = true;
                //trList.Visible = true;
                Fill_Master();
                //trAddNewMaster.Visible = false;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    private void Fill_Master()
    {
        try
        {
            dtRecords = new DataTable();
            objBusinessFacadLayer = new BusinessFacadLayer();
            dtRecords = objBusinessFacadLayer.getCompanyMaster();

            if (dtRecords.Rows.Count > 0)
            {
                gvMasterGrid.DataSource = dtRecords;
                gvMasterGrid.DataBind();
            }
            else
            {
                gvMasterGrid.DataSource = null;
                gvMasterGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objBusinessFacadLayer = null;
        }
    }
    protected void gvMasterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        intCompanyID = 0;
        objBusinessFacadLayer = new BusinessFacadLayer();

        try
        {


            if (e.CommandName == "EnableDisable")
            {

                //  dtRecords = new DataTable();
                RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                if (RowIndex > -1)
                {
                    intCompanyID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value.ToString());


                    if (gvMasterGrid.Rows[RowIndex].Cells[5].Text.ToUpper() == "TRUE")
                    {
                        blnEnableDisable = false;
                        blnDelete = false;
                    }
                    else if (gvMasterGrid.Rows[RowIndex].Cells[5].Text.ToUpper() == "FALSE")
                    {
                        blnEnableDisable = true;
                        blnDelete = false;
                    }

                    objBusinessFacadLayer.DeleteorEnableDisableCompany(intCompanyID, blnEnableDisable, blnDelete);
                    Fill_Master();

                }

            }
            else if (e.CommandName == "EditRow")
            {

                RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                if (RowIndex > -1)
                {
                    //intCompanyID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value);
                    //hdnMasterName.Value = gvMasterGrid.Rows[RowIndex].Cells[1].Text;
                    //hdnMasterID.Value = MasterID.ToString();

                    //objEcom_Entity.Mode = "GetBrandIDDetails";
                    //objEcom_Entity.MasterID = MasterID;
                    //dtRecord = objEcom_BAL.GetBrandGroupCatSubCat(objEcom_Entity);
                    //if (dtRecord.Rows.Count > 0)
                    //{
                    //    txtBrandName.Text = dtRecord.Rows[0]["BrandName"].ToString();
                    //    txtBrandDescription.Text = dtRecord.Rows[0]["BrandDescription"].ToString();
                    //    if (dtRecord.Rows[0][3].ToString().ToUpper() == "YES")
                    //    {
                    //        chkActive.Checked = true;
                    //    }
                    //    else
                    //    {
                    //        chkActive.Checked = false;
                    //    }
                    //    // hdnMasterName.Value = dtRecord.Rows[0][1].ToString();
                    //    trAddNew.Visible = false;
                    //    trAddNewMaster.Visible = true;
                    //    trList.Visible = false;
                    //}
                    //else
                    //{
                    //    //trAddNew.Visible = true;
                    //    //trList.Visible = true;
                    //    //Fill_Master();
                    //    //trAddNewMaster.Visible = false;
                    //}

                }
            }
            else if (e.CommandName == "Del")
            {

                RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                if (RowIndex > -1)
                {
                    intCompanyID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value);
                    objBusinessFacadLayer.DeleteorEnableDisableCompany(intCompanyID, false, true);
                    Fill_Master();



                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //objEcom_Entity = null ;
            //objEcom_BAL = null ;
            // dtRecord.Dispose();
        }
    }
    protected void gvMasterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMasterGrid.PageIndex = e.NewPageIndex;

        //rebind your gridview - GetSource(),Datasource of your GirdView
        Fill_Master();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {

    }

    protected void GridView_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            RowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            if (RowIndex > -1)
            {
                intCompanyID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value.ToString());
                objBusinessFacadLayer = new BusinessFacadLayer();
                objBusinessFacadLayer.DeleteorEnableDisableCompany(intCompanyID, Convert.ToBoolean(gvMasterGrid.Rows[RowIndex].Cells[7].Text), true);
                Fill_Master();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBusinessFacadLayer = null;
        }
    }

    protected void GridView_Button_Click(object sender, EventArgs e)
    {
        try
        {
            RowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            if (RowIndex > -1)
            {
                intCompanyID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value.ToString());


                if (gvMasterGrid.Rows[RowIndex].Cells[7].Text.ToUpper() == "TRUE")
                {
                    blnEnableDisable = false;
                    blnDelete = false;
                }
                else if (gvMasterGrid.Rows[RowIndex].Cells[7].Text.ToUpper() == "FALSE")
                {
                    blnEnableDisable = true;
                    blnDelete = false;
                }
                objBusinessFacadLayer = new BusinessFacadLayer();
                objBusinessFacadLayer.DeleteorEnableDisableCompany(intCompanyID, blnEnableDisable, blnDelete);
                Fill_Master();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBusinessFacadLayer = null;
        }
    }

    [WebMethod()]
    public static string AddCompany(string CompanyName, string CompanyShortName, string CompanyContactPersonName, string CompanyContactPersonMobileNo, string ContactPersonEmailID, string CompanyWebsiteURL, bool Status)
    {
      //  string result = "CompanyName=" + CompanyName + "CompanyShortName=" + CompanyShortName + "CompanyContactPersonName=" + CompanyContactPersonName + "CompanyContactPersonMobileNo=" + CompanyContactPersonMobileNo + "CompanyWebsiteURL=" + CompanyWebsiteURL + "Status=" + Status;

        try
        {
            if(CompanyName.Trim()=="")
            {
                return "false|Enter Company Name";
            }

            objBusinessFacadLayer_Static = new BusinessFacadLayer();
            objCompanyMaster_Static = new tbl_CompanyMaster();
            objCompanyMaster_Static.Name = CompanyName;
            objCompanyMaster_Static.CompanyShortKey = CompanyShortName;
            objCompanyMaster_Static.ContactPersonName = CompanyContactPersonName;
            objCompanyMaster_Static.BusinessWebsite = CompanyWebsiteURL;
            objCompanyMaster_Static.MobileNo = CompanyContactPersonMobileNo;
            objCompanyMaster_Static.Email = ContactPersonEmailID;
            objCompanyMaster_Static.IsActive = Status;
            objCompanyMaster_Static.IsDeleted = false;
            objCompanyMaster_Static.CreatedBy = "Admin";
            objCompanyMaster_Static.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString());
            isExist = objBusinessFacadLayer_Static.AddCompany(objCompanyMaster_Static);
            if(isExist>0)
            {
                return "failed|Company -" + CompanyName + ", already exist";
            }
            else
            {
                return "success|New Company -" + CompanyName + ", added successfully";
            }            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    //protected void gvMasterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{

    //}

    //protected void gvMasterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //}
}