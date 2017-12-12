using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class frmProductMaster : System.Web.UI.Page
{
    private BusinessFacadLayer objBusinessFacadLayer;
    static private BusinessFacadLayer objBusinessFacadLayer_Static;
    private DataTable dtRecords;
    static private DataTable dtRecords_Static;
    private int intProductID, RowIndex;
    private bool blnEnableDisable, blnDelete;
    static private DataView dvFilterRecords;
    private ListItem objListDDLSelect = new ListItem("--Select--", "0", true);
    private static tbl_ProductMaster objProductMaster_Static;
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
                Fill_Form_AddProduct();
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
            dtRecords = objBusinessFacadLayer.getProductMaster(0);

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
        intProductID = 0;
        objBusinessFacadLayer = new BusinessFacadLayer();

        try
        {


            if (e.CommandName == "EnableDisable")
            {

                //  dtRecords = new DataTable();
                RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                if (RowIndex > -1)
                {
                    intProductID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value.ToString());


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

                    objBusinessFacadLayer.DeleteorEnableDisableCompanyProduct(intProductID, blnEnableDisable, blnDelete);
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
                    intProductID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value);
                    objBusinessFacadLayer.DeleteorEnableDisableCompany(intProductID, false, true);
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
                intProductID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value.ToString());
                objBusinessFacadLayer = new BusinessFacadLayer();
                objBusinessFacadLayer.DeleteorEnableDisableCompanyProduct(intProductID, Convert.ToBoolean(gvMasterGrid.Rows[RowIndex].Cells[6].Text), true);
                Fill_Master();

            }
            Response.Write("<script>$(\"#btnModal\").click(function () {$(\':input\', \'#modelAddCompany').val(\"\");$('#ContentPlaceHolder_chkIsActive').prop('checked', 'true');$('#modelAddCompany').modal({ backdrop: 'static', keyboard: false }, 'show');});</script>");
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
                intProductID = Convert.ToInt32(gvMasterGrid.DataKeys[RowIndex].Value.ToString());


                if (gvMasterGrid.Rows[RowIndex].Cells[6].Text.ToUpper() == "TRUE")
                {
                    blnEnableDisable = false;
                    blnDelete = false;
                }
                else if (gvMasterGrid.Rows[RowIndex].Cells[6].Text.ToUpper() == "FALSE")
                {
                    blnEnableDisable = true;
                    blnDelete = false;
                }
                objBusinessFacadLayer = new BusinessFacadLayer();
                objBusinessFacadLayer.DeleteorEnableDisableCompanyProduct(intProductID, blnEnableDisable, blnDelete);
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

    [WebMethod]
    public static string AddProduct(int CompanyID, string ProductName, string HSNCode,string UOM,bool Status)
    {
        frmProductMaster objfrmProductMaster = new frmProductMaster();
        try
        {

            objBusinessFacadLayer_Static = new BusinessFacadLayer();
            if (CompanyID <= 0)
            {
                return "false|Select Company Name";
            }
            else if (ProductName.Trim() == "")
            {
                return "false|Enter Product Name";
            }
            else if(HSNCode.Trim()=="")
            {
                return "false|Enter HSN Code";
            }
            else if (UOM.Trim() == "")
            {
                return "false|Enter UOM";
            }
            objBusinessFacadLayer_Static = new BusinessFacadLayer();
            objProductMaster_Static = new tbl_ProductMaster();
            objProductMaster_Static.FK_CompanyMasterID = CompanyID;
            objProductMaster_Static.ProductName  = ProductName;
            objProductMaster_Static.HSNCode  = HSNCode;
            objProductMaster_Static.UOM  = UOM;
            objProductMaster_Static.IsActive = Status;
            objProductMaster_Static.IsDeleted = false;
            objProductMaster_Static.CreatedBy = "Admin";
            objProductMaster_Static.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString());
            isExist = objBusinessFacadLayer_Static.AddProduct(objProductMaster_Static);
            if (isExist > 0)
            {
                return "failed|Product -" + ProductName + ", already exist for Company -";// + objfrmProductMaster.ddlCompanyName.SelectedItem.Text.ToString();
            }
            else
            {
                return "success|New Product -" + ProductName + ", added successfully";// + objfrmProductMaster.ddlCompanyName.SelectedItem.Text.ToString()  + " - Company";
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }  
    public void Fill_Form_AddProduct()
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getCompanyMaster();
                dvFilterRecords = new DataView(dtRecords);
                dvFilterRecords.RowFilter = "IsActive=True";
                dtRecords = dvFilterRecords.ToTable();
                if (dtRecords.Rows.Count > 0)
                {

                    ddlCompanyName.DataSource = dtRecords;
                    ddlCompanyName.DataValueField = dtRecords.Columns["ID"].ToString();
                    ddlCompanyName.DataTextField = dtRecords.Columns["Name"].ToString();
                    ddlCompanyName.DataBind();
                    ddlCompanyName.Items.Insert(0, objListDDLSelect);


                    //ddlCompany.Items.Insert(0, new ListItem("0","Select"));
                }
                else
                {
                    ddlCompanyName.DataSource = null;
                    ddlCompanyName.DataBind();
                    //  ddlCompany.Items.Insert(0, objListDDLSelect);
                }


            }
            
           
        }
        catch(Exception ex)
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