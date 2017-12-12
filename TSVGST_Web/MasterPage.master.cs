using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null && Session["UserName"].ToString() == "")
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("frmLogin.aspx", false);
            }
            else
            {
                lblLoginUser.Text = Session["UserName"].ToString();
            }
        }
        catch
        {
            Response.Redirect("frmLogin.aspx", false);
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
       
        Session.Abandon();
        Session.Clear();
        Response.Redirect("frmLogin.aspx", false);
    }
}
