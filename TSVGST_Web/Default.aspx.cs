using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    private String strConnString = ConfigurationManager.ConnectionStrings["SKSConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        string strQuery = "select CustomerID,ContactName,CompanyName" +
                           " from customers";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        GridView1.DataSource = GetData(cmd);
        GridView1.DataBind();
    }

    protected void AddNewCustomer(object sender, EventArgs e)
    {
        string CustomerID = ((TextBox)GridView1.FooterRow.FindControl("txtCustomerID")).Text;
        string Name = ((TextBox)GridView1.FooterRow.FindControl("txtContactName")).Text;
        string Company = ((TextBox)GridView1.FooterRow.FindControl("txtCompany")).Text;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.CommandText = "insert into customers(ContactName, CompanyName) " +
        "values(@ContactName, @CompanyName);" +
        "select CustomerID,ContactName,CompanyName from customers";
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID;
        cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = Name;
        cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = Company;
        GridView1.DataSource = GetData(cmd);
        GridView1.DataBind();
    }
    protected void EditCustomer(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
    {
        string CustomerID = ((Label)GridView1.Rows[e.RowIndex]
                            .FindControl("lblCustomerID")).Text;
        string Name = ((TextBox)GridView1.Rows[e.RowIndex]
                            .FindControl("txtContactName")).Text;
        string Company = ((TextBox)GridView1.Rows[e.RowIndex]
                            .FindControl("txtCompany")).Text;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update customers set ContactName=@ContactName," +
         "CompanyName=@CompanyName where CustomerID=@CustomerID;" +
         "select CustomerID,ContactName,CompanyName from customers";
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID;
        cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = Name;
        cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = Company;
        GridView1.EditIndex = -1;
        GridView1.DataSource = GetData(cmd);
        GridView1.DataBind();
    }
    protected void DeleteCustomer(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  customers where " +
        "CustomerID=@CustomerID;" +
         "select CustomerID,ContactName,CompanyName from customers";
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value
            = lnkRemove.CommandArgument;
        GridView1.DataSource = GetData(cmd);
        GridView1.DataBind();
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        BindData();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    private DataTable GetData(SqlCommand cmd)
    {
        SqlConnection SQLCon = new SqlConnection(strConnString);
        if(SQLCon.State==ConnectionState.Closed)
        {
            SQLCon.Open();
        }
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            using (DataTable dt = new DataTable())
            {
                da.Fill(dt);
                return dt;
            }
        }
    }
}