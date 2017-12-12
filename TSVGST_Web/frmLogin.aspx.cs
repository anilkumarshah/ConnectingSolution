using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmLogin : System.Web.UI.Page
{
    private DataTable dtRecord;
    private BusinessFacadLayer objBusinessFacadLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        if(!IsPostBack)
        {
            txtUserName.Value = "anil";
            txtPassword.Value = "anilshah";
        }

    }

    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if(Page.IsValid)
    //        {

    //        }


    //    }
    //    catch(Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {

    //    }
    //}

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                objBusinessFacadLayer = new BusinessFacadLayer();
                dtRecord = new DataTable();
                dtRecord = objBusinessFacadLayer.getUserLoginDetail(txtUserName.Value.Trim(), txtPassword.Value.Trim());
                if(dtRecord.Rows.Count>0)
                {
                    Session["UserName"] = txtUserName.Value.Trim();
                    Response.Redirect("frmDashboard.aspx",false);
                }
                else
                {
                    dvError.Visible = true;
                    dvError.InnerHtml = "Invalid UserName / Password";
                }
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
}