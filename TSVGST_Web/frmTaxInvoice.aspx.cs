using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SKSBUsinessModel;
using System.Text;


public partial class frmTaxInvoice : System.Web.UI.Page
{
    BusinessFacadLayer objBusinessFacadLayer;
    DataTable dtRecords;
    private mdl_BillDetails_temp objmdl_BillDetails_temp;
    private tbl_BillDetails_temp objtbl_BillDetails_temp;
    private ListItem objListDDLSelect = new ListItem("--Select--", "0", true);
    private ListItem objListDDLSearchCustomerSelect = new ListItem("--Search Customer--", "0", true);
    private tbl_CustomerBillingAddress objCustomerBillingAddress;
    private tbl_CustomerShippingAddress objCustomerShippingAddress;
    private tbl_BillMaster objBillMaster;
    private tbl_BillDetails objBillDetails;
    private Int64 intBillInvoiceNumber;
    private DataView dvFilterRecords;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mvwTaxInvoiceBill.SetActiveView(vwTaxInvoiceCustomer);
            //  mvwTaxInvoiceBill.SetActiveView(vwTaxInvoiceBillGeneration);

            hdnGUID.Value = Guid.NewGuid().ToString();

            Fill_CompanyMaster();
            Fill_ProductMaster(Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString()));
            Fill_ProductDetail(Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString()), Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));
            Fill_ProductPrice(Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));

            Fill_BillingCustomerDropdown();
            Fill_ShippingCustomerDropdown();
            Fill_BillDetailsGrid("");
            Fill_TransportationListDropdown();

            txtInvoiceTotal.ReadOnly = true;
          //  txtTotal.Enabled = false;
            //txtTaxableValue.Enabled = false;
            //txtSGSTValue.Enabled = false;
            //txtCGSTValue.Enabled = false;

        }
    }

    private void Fill_BillingCustomerDropdown()
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getBillingCustomerList();
                if (dtRecords.Rows.Count > 0)
                {

                    ddlSearchBillingCustomer.DataSource = dtRecords;
                    ddlSearchBillingCustomer.DataValueField = dtRecords.Columns["BillingID"].ToString();
                    ddlSearchBillingCustomer.DataTextField = dtRecords.Columns["BillingCustomer"].ToString();
                    ddlSearchBillingCustomer.DataBind();
                    ddlSearchBillingCustomer.Items.Insert(0, objListDDLSearchCustomerSelect);

                    //ddlCompany.Items.Insert(0, new ListItem("0","Select"));
                }
                else
                {
                    ddlSearchBillingCustomer.DataSource = null;
                    ddlSearchBillingCustomer.DataBind();

                }

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

    private void Fill_TransportationListDropdown()
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getTransposrationList();
                if (dtRecords.Rows.Count > 0)
                {

                    ddlTransportationType.DataSource = dtRecords;
                    ddlTransportationType.DataValueField = dtRecords.Columns["ID"].ToString();
                    ddlTransportationType.DataTextField = dtRecords.Columns["TransportationName"].ToString();
                    ddlTransportationType.DataBind();
                    ddlTransportationType.Items.Insert(0, objListDDLSelect);

                    //ddlCompany.Items.Insert(0, new ListItem("0","Select"));
                }
                else
                {
                    ddlTransportationType.ClearSelection();
                    ddlTransportationType.DataSource = null;
                    ddlTransportationType.DataBind();

                }

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

    private void Fill_ShippingCustomerDropdown()
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getShippingCustomerList();
                if (dtRecords.Rows.Count > 0)
                {

                    ddlSearchShippingCustomer.DataSource = dtRecords;
                    ddlSearchShippingCustomer.DataValueField = dtRecords.Columns["ShippingID"].ToString();
                    ddlSearchShippingCustomer.DataTextField = dtRecords.Columns["ShippingCustomer"].ToString();
                    ddlSearchShippingCustomer.DataBind();
                    ddlSearchShippingCustomer.Items.Insert(0, objListDDLSearchCustomerSelect);

                    //ddlCompany.Items.Insert(0, new ListItem("0","Select"));
                }
                else
                {
                    ddlSearchShippingCustomer.DataSource = null;
                    ddlSearchShippingCustomer.DataBind();

                }

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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            mvwTaxInvoiceBill.SetActiveView(vwTaxInvoiceBillGeneration);

            #region Setting Billing Address
            lblBillingNameGSTIN.Text = txtCustomerName.Text + "  [ <b>GSTIN No - " + txtGSTINNo.Text + "</b> ]";
            lblBillingAddress.Text = txtAddressLine1.Text + ", " + txtAddressLine2.Text;
            lblBillingCityStatePin.Text = txtCity.Text + ", " + ddlState.SelectedItem.Text.ToString() + ", " + txtPin.Text;
            lblBillingContact.Text = txtPhoneNo.Text + ", " + txtEmail.Text;
            #endregion

            #region Setting Shipping Address
            lblShippingNameGSTIN.Text = txtShippingCustomerName.Text + "  [ <b>GSTIN No - " + txtShippingGSTINNo.Text + "</b> ]";
            lblShippingAddress.Text = txtShippingAddressLine1.Text + ", " + txtShippingAddressLine2.Text;
            lblShippingCityStatePin.Text = txtShippingCity.Text + ", " + ddlShippingState.SelectedItem.Text.ToString() + ", " + txtShippingPin.Text;
            lblShippingContact.Text = txtShippingPhoneNo.Text + ", " + txtShippingEmail.Text;
            #endregion

            Fill_BillDetailsGrid(hdnGUID.Value.ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }

    private void Fill_BillDetailsGrid(string GUID)
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getBillDetails_Temp(GUID);
                if (dtRecords.Rows.Count > 0)
                {
                    gvBillItemDetails.DataSource = dtRecords;
                    gvBillItemDetails.DataBind();

                    //gvBillItemDetails.Columns[16].Visible = false;
                    //gvBillItemDetails.Columns[17].Visible = false;
                    CalculateTotalItemAmountinGrid();

                }
                else
                {
                    lblSummaryTotalQuantity.Text = "000";
                    lblSummaryTotalAmount.Text = "0.00";
                    lblSummarytotaldiscount.Text = "0.00";
                    lblSummaryTaxableAmount.Text = "0.00";
                    lblSummarySGSTAmount.Text = "0.00";
                    lblSummaryCGSTAmount.Text = "0.00";
                    txtInvoiceTotal.Text = "";

                    gvBillItemDetails.DataSource = null;
                    gvBillItemDetails.DataBind();
                }
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
    private void CalculateTotalItemAmountinGrid()
    {
        try
        {
            int SummaryTotalQuantity = 0;
            double SummaryTotalAmount = 0.00, SummaryTotaldiscount = 0.00, SummaryTaxableAmount = 0.00, SummarySGSTAmount = 0.00, SummaryCGSTAmount = 0.00;
            
            if (gvBillItemDetails.Rows.Count > 0)
            {
                for (int i = 0; i < gvBillItemDetails.Rows.Count; i++)
                {
                    //  string dat = gvBillItemDetails.Rows[i].Cells[4].Text.ToString();

                    SummaryTotalQuantity += Convert.ToInt32(gvBillItemDetails.Rows[i].Cells[6].Text.ToString());
                    SummaryTotalAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[9].Text.ToString());
                    SummaryTotaldiscount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[10].Text.ToString());
                    SummaryTaxableAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[11].Text.ToString());
                    SummarySGSTAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[13].Text.ToString());
                    SummaryCGSTAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[15].Text.ToString());
                }

                txtInvoiceTotal.Text =  Convert.ToString(SummaryTotalAmount - SummaryTotaldiscount + SummarySGSTAmount + SummaryCGSTAmount );
                txtTotalCollectedAmount.Value = Convert.ToString(Convert.ToDecimal(string.IsNullOrEmpty(txtInvoiceTotal.Text.Trim()) ? "0" : txtInvoiceTotal.Text.Trim()) +Convert.ToDecimal(string.IsNullOrEmpty(txtLOadingnPackingCharges.Text.Trim()) ? "0" : txtLOadingnPackingCharges.Text.Trim()) + Convert.ToDecimal(string.IsNullOrEmpty(txtFreightCharges.Text.Trim()) ? "0" : txtFreightCharges.Text.Trim()) +Convert.ToDecimal(string.IsNullOrEmpty(txtInsuranceCharges.Text.Trim()) ? "0" : txtInsuranceCharges.Text.Trim()) + Convert.ToDecimal(string.IsNullOrEmpty(txtOtherCharges.Text.Trim()) ? "0" : txtOtherCharges.Text.Trim()));
               // hdnTotalItemPrice.Value = txtTotalCollectedAmount.Text;
            }

            lblSummaryTotalQuantity.Text = SummaryTotalQuantity.ToString();
            lblSummaryTotalAmount.Text = SummaryTotalAmount.ToString();
            lblSummarytotaldiscount.Text = SummaryTotaldiscount.ToString();
            lblSummaryTaxableAmount.Text = SummaryTaxableAmount.ToString();
            lblSummarySGSTAmount.Text = SummarySGSTAmount.ToString();
            lblSummaryCGSTAmount.Text = SummaryCGSTAmount.ToString();
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ResetFormForAddBillItem_Temp()
    {

        try
        {
            ClearItemDetailsForm();
            Fill_CompanyMaster();
            Fill_ProductMaster(Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString()));
            Fill_ProductDetail(Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString()), Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));
            Fill_ProductPrice(Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));

            Fill_BillDetailsGrid(hdnGUID.Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    private void ClearItemDetailsForm()
    {
        txtQuantity.Text = "";
        //  lblTotal.Text = "#";
        txtTotal.Text = "0.00";
        txtDiscount.Text = "0.00";
        //   lblTaxableValue.Text = "#";
        txtTaxableValue.Text = "0.00";
        //  lblSGSTValue.Text = "#";
        txtSGSTValue.Text = "0.00";
        //     lblSGSTValue.Text = "#";
        txtCGSTValue.Text = "0.00";
    }

    private void Fill_CompanyMaster()
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
                   
                    ddlCompany.DataSource = dtRecords;
                    ddlCompany.DataValueField = dtRecords.Columns["ID"].ToString();
                    ddlCompany.DataTextField = dtRecords.Columns["Name"].ToString();
                    ddlCompany.DataBind();
                    ddlCompany.Items.Insert(0, objListDDLSelect);


                    //ddlCompany.Items.Insert(0, new ListItem("0","Select"));
                }
                else
                {
                    ddlCompany.DataSource = null;
                    ddlCompany.DataBind();
                    //  ddlCompany.Items.Insert(0, objListDDLSelect);
                }

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

    private void Fill_ProductMaster(int CompanyID)
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getProductMaster(CompanyID);
                dvFilterRecords = new DataView(dtRecords);
                dvFilterRecords.RowFilter = "IsActive=true and FK_CompanyMasterID=" + CompanyID + "";
                dtRecords = dvFilterRecords.ToTable();
                if (dtRecords.Rows.Count > 0)
                {

                    ddlcompanyProduct.DataSource = dtRecords;
                    ddlcompanyProduct.DataValueField = dtRecords.Columns["ID"].ToString();
                    ddlcompanyProduct.DataTextField = dtRecords.Columns["ProductName"].ToString();
                    ddlcompanyProduct.DataBind();
                    ddlcompanyProduct.Items.Insert(0, objListDDLSelect);

                }
                else
                {
                    ddlcompanyProduct.Items.Clear();
                    ddlcompanyProduct.DataSource = null;
                    ddlcompanyProduct.Items.Insert(0, objListDDLSelect);
                    ddlcompanyProduct.DataBind();
                    //  ddlcompanyProduct.Items.Insert(0, objListDDLSelect);
                }

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

    private void Fill_ProductPrice(int ProductID)
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getProductPrice(ProductID);
                if (dtRecords.Rows.Count > 0)
                {

                    lblRate.Text = dtRecords.Rows[0]["Price"].ToString();
                    lblSGSTRate.Text = dtRecords.Rows[0]["SGSTPercentageRate"].ToString();
                    lblCGSTRate.Text = dtRecords.Rows[0]["CGSTPercentageRate"].ToString();
                }
                else
                {
                    lblRate.Text = "#";
                    lblSGSTRate.Text = "#";
                    lblCGSTRate.Text = "#";

                }
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

    private void Fill_ProductDetail(int CompanyID, int ProductID)
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            using (dtRecords = new DataTable())
            {
                dtRecords = objBusinessFacadLayer.getProductMaster(CompanyID, ProductID);
                if (dtRecords.Rows.Count > 0)
                {
                    lblHSNCode.Text = dtRecords.Rows[0]["HSNCode"].ToString();
                    lblUOM.Text = dtRecords.Rows[0]["UOM"].ToString();
                }
                else
                {
                    lblHSNCode.Text = "#";
                    lblUOM.Text = "#";
                }
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

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Fill_ProductMaster(Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString()));
            Fill_ProductDetail(Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString()), Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));
            Fill_ProductPrice(Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    protected void ddlcompanyProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Fill_ProductDetail(Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString()), Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));
            Fill_ProductPrice(Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString()));
            ClearItemDetailsForm();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        try
        {
            //  objmdl_BillDetails_temp = new mdl_BillDetails_temp();
            objtbl_BillDetails_temp = new tbl_BillDetails_temp();

            objtbl_BillDetails_temp.CompanyID = Convert.ToInt32(ddlCompany.SelectedItem.Value.ToString());
            objtbl_BillDetails_temp.ProductID = Convert.ToInt32(ddlcompanyProduct.SelectedItem.Value.ToString());
            objtbl_BillDetails_temp.Company = ddlCompany.SelectedItem.Text.ToString();
            objtbl_BillDetails_temp.Product = ddlcompanyProduct.SelectedItem.Text.ToString();
            objtbl_BillDetails_temp.HSNNo = lblHSNCode.Text;
            objtbl_BillDetails_temp.Qnty = Convert.ToInt32(txtQuantity.Text.Trim());
            objtbl_BillDetails_temp.UOM = lblUOM.Text;
            objtbl_BillDetails_temp.Rate = Convert.ToDecimal(lblRate.Text.Trim());
            objtbl_BillDetails_temp.Total = Convert.ToDecimal(txtTotal.Text.ToString());
            objtbl_BillDetails_temp.Discount = Convert.ToDecimal(txtDiscount.Text.Trim());
            //objtbl_BillDetails_temp.TaxableValue= Convert.ToDecimal(lblTaxableValue.Text);
            objtbl_BillDetails_temp.TaxableValue = Convert.ToDecimal(txtTaxableValue.Text);
            objtbl_BillDetails_temp.SGSTRate = Convert.ToDecimal(lblSGSTRate.Text.Trim());
            //objtbl_BillDetails_temp.SGSTValue = Convert.ToDecimal(lblSGSTValue.Text.Trim());
            objtbl_BillDetails_temp.SGSTValue = Convert.ToDecimal(txtSGSTValue.Text.Trim());
            objtbl_BillDetails_temp.CGSTRate = Convert.ToDecimal(lblCGSTRate.Text.Trim());
            //objtbl_BillDetails_temp.CGSTValue = Convert.ToDecimal(lblCGSTValue.Text.Trim());
            objtbl_BillDetails_temp.CGSTValue = Convert.ToDecimal(txtCGSTValue.Text.Trim());
            objtbl_BillDetails_temp.CreatedOn = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            objtbl_BillDetails_temp.CreatedBy = "Admin";
            objtbl_BillDetails_temp.IsActive = true;
            objtbl_BillDetails_temp.IsDeleted = false;

            objtbl_BillDetails_temp.GUID = hdnGUID.Value.ToString();
            // objtbl_BillDetails_temp.Id=

            objBusinessFacadLayer = new BusinessFacadLayer();
            objBusinessFacadLayer.AddItemInBillDetailsTemp(objtbl_BillDetails_temp);
            ResetFormForAddBillItem_Temp();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objBusinessFacadLayer = null;
            objmdl_BillDetails_temp = null;
            //   objtbl_BillDetails_temp = null;
        }
    }

    protected void GridView_Button_Click(object sender, EventArgs e)
    {
        try
        {
          int  RowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            if (RowIndex > -1)
            {
              int  intItemID = Convert.ToInt32(gvBillItemDetails.DataKeys[RowIndex].Value.ToString());


                objBusinessFacadLayer = new BusinessFacadLayer();
                objBusinessFacadLayer.DeleteItemInBillDetailsTemp(Convert.ToInt64(intItemID), hdnGUID.Value.ToString());
                ResetFormForAddBillItem_Temp();

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


    protected void gvBillItemDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                string id = e.CommandArgument.ToString();
                objBusinessFacadLayer = new BusinessFacadLayer();
                objBusinessFacadLayer.DeleteItemInBillDetailsTemp(Convert.ToInt64(id), hdnGUID.Value.ToString());
                ResetFormForAddBillItem_Temp();
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        mvwTaxInvoiceBill.SetActiveView(vwTaxInvoiceCustomer);
    }

    protected void CalculateBillDetailSummaryCost()
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    protected void ddlSearchBillingCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtCustomerName.Text = "";
            txtProprietorName.Text = "";
            txtAddressLine1.Text = "";
            txtAddressLine2.Text = "";
            txtCity.Text = "";
            txtPin.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtAadharNo.Text = "";
            txtGSTINNo.Text = "";

            if (ddlSearchBillingCustomer.SelectedItem.Value.ToString() == "0")
            {
                txtCustomerName.Enabled = true;
                txtProprietorName.Enabled = true;
                txtAddressLine1.Enabled = true;
                txtAddressLine2.Enabled = true;
                txtCity.Enabled = true;
                txtPin.Enabled = true;
                txtPhoneNo.Enabled = true;
                txtEmail.Enabled = true;
                txtAadharNo.Enabled = true;
                txtGSTINNo.Enabled = true;
                hdnIsNewBillingCustomer.Value = "Yes";
            }
            else
            {
                txtCustomerName.Enabled = false;
                txtProprietorName.Enabled = false;
                txtAddressLine1.Enabled = false;
                txtAddressLine2.Enabled = false;
                txtCity.Enabled = false;
                txtPin.Enabled = false;
                txtPhoneNo.Enabled = false;
                txtEmail.Enabled = false;
                txtAadharNo.Enabled = false;
                txtGSTINNo.Enabled = false;
                hdnIsNewBillingCustomer.Value = ddlSearchBillingCustomer.SelectedItem.Value.ToString();
                Fill_BillingSearchCustomerDetailinForm(Convert.ToInt32(ddlSearchBillingCustomer.SelectedItem.Value.ToString()));
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }



    protected void btnAddItemInInvoice_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                objBusinessFacadLayer = new BusinessFacadLayer();

                if (Convert.ToInt32(ddlSearchBillingCustomer.SelectedItem.Value.ToString()) == 0 && hdnIsNewBillingCustomer.Value == "Yes")
                {
                    objCustomerBillingAddress = new tbl_CustomerBillingAddress();
                    objCustomerBillingAddress.CustomerName = txtCustomerName.Text.Trim();
                    objCustomerBillingAddress.BillingProprietorName = txtProprietorName.Text.Trim();
                    objCustomerBillingAddress.BillingAddress1 = txtAddressLine1.Text.Trim();
                    objCustomerBillingAddress.BillingAddress2 = txtAddressLine2.Text.Trim();
                    objCustomerBillingAddress.BillingCity = txtCity.Text.Trim();
                    objCustomerBillingAddress.FK_StateID = Convert.ToInt32(ddlState.SelectedItem.Value.ToString());
                    objCustomerBillingAddress.Billingpin = txtPin.Text.Trim();
                    objCustomerBillingAddress.BillingPhone = txtPhoneNo.Text.Trim();
                    objCustomerBillingAddress.BillingEmail = txtEmail.Text.Trim();
                    objCustomerBillingAddress.BillingAadharNo = txtAadharNo.Text.Trim();
                    objCustomerBillingAddress.BillingGSTINNo = txtGSTINNo.Text.Trim();
                    objCustomerBillingAddress.GUID = hdnGUID.Value.ToString();
                    objCustomerBillingAddress.IsActive = true;
                    objCustomerBillingAddress.IsDeleted = false;
                    objCustomerBillingAddress.CreatedBy = "Admin";
                    objCustomerBillingAddress.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString());

                    objBusinessFacadLayer.AddBillingCustomerDetails(objCustomerBillingAddress);
                    hdnIsNewBillingCustomer.Value = Convert.ToString(objCustomerBillingAddress.Id);
                }
                if (Convert.ToInt32(ddlSearchShippingCustomer.SelectedItem.Value.ToString()) == 0 && hdnIsNewShippingCustomer.Value == "Yes")
                {
                    objCustomerShippingAddress = new tbl_CustomerShippingAddress();
                    objCustomerShippingAddress.CustomerName = txtShippingCustomerName.Text.Trim();
                    objCustomerShippingAddress.ShippingProprietorName = txtShippingProprietorName.Text.Trim();
                    objCustomerShippingAddress.ShippingAddress1 = txtShippingAddressLine1.Text.Trim();
                    objCustomerShippingAddress.ShippingAddress2 = txtShippingAddressLine2.Text.Trim();
                    objCustomerShippingAddress.ShippingCity = txtShippingCity.Text.Trim();
                    objCustomerShippingAddress.FK_StateID = Convert.ToInt32(ddlShippingState.SelectedItem.Value.ToString());
                    objCustomerShippingAddress.Shippingpin = txtShippingPin.Text.Trim();
                    objCustomerShippingAddress.ShippingPhone = txtShippingPhoneNo.Text.Trim();
                    objCustomerShippingAddress.ShippingEmail = txtShippingEmail.Text.Trim();
                    objCustomerShippingAddress.ShippingAadharNo = txtShippingAadharNo.Text.Trim();
                    objCustomerShippingAddress.ShippingGSTINNo = txtShippingGSTINNo.Text.Trim();
                    objCustomerShippingAddress.GUID = hdnGUID.Value.ToString();
                    objCustomerShippingAddress.IsActive = true;
                    objCustomerShippingAddress.IsDeleted = false;
                    objCustomerShippingAddress.CreatedBy = "Admin";
                    objCustomerShippingAddress.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString());

                    objBusinessFacadLayer.AddShippingCustomerDetails(objCustomerShippingAddress);
                    hdnIsNewShippingCustomer.Value = Convert.ToString(objCustomerShippingAddress.Id);
                }

                mvwTaxInvoiceBill.SetActiveView(vwTaxInvoiceBillGeneration);

                #region Setting Billing Address
                lblBillingNameGSTIN.Text = txtCustomerName.Text + "  [ <b>GSTIN No - " + txtGSTINNo.Text + "</b> ]";
                lblBillingAddress.Text = txtAddressLine1.Text + ", " + txtAddressLine2.Text;
                lblBillingCityStatePin.Text = txtCity.Text + ", " + ddlState.SelectedItem.Text.ToString() + ", " + txtPin.Text;
                lblBillingContact.Text = txtPhoneNo.Text + ", " + txtEmail.Text;
                #endregion

                #region Setting Shipping Address
                lblShippingNameGSTIN.Text = txtShippingCustomerName.Text + "  [ <b>GSTIN No - " + txtShippingGSTINNo.Text + "</b> ]";
                lblShippingAddress.Text = txtShippingAddressLine1.Text + ", " + txtShippingAddressLine2.Text;
                lblShippingCityStatePin.Text = txtShippingCity.Text + ", " + ddlShippingState.SelectedItem.Text.ToString() + ", " + txtShippingPin.Text;
                lblShippingContact.Text = txtShippingPhoneNo.Text + ", " + txtShippingEmail.Text;
                #endregion

                Fill_BillDetailsGrid(hdnGUID.Value.ToString());

                txtDatenTimeofSupply.Text = Convert.ToString(DateTime.Now.ToString());
                txtDatenTimeofSupply.ReadOnly = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objCustomerBillingAddress = null;
            objCustomerShippingAddress = null;
            objBusinessFacadLayer = null;

        }
    }

    protected void ddlSearchShippingCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtShippingCustomerName.Text = "";
            txtShippingProprietorName.Text = "";
            txtShippingAddressLine1.Text = "";
            txtShippingAddressLine2.Text = "";
            txtShippingCity.Text = "";
            txtShippingPin.Text = "";
            txtShippingPhoneNo.Text = "";
            txtShippingEmail.Text = "";
            txtShippingAadharNo.Text = "";
            txtShippingGSTINNo.Text = "";

            if (ddlSearchShippingCustomer.SelectedItem.Value.ToString() == "0")
            {
                txtShippingCustomerName.Enabled = true;
                txtShippingProprietorName.Enabled = true;
                txtShippingAddressLine1.Enabled = true;
                txtShippingAddressLine2.Enabled = true;
                txtShippingCity.Enabled = true;
                txtShippingPin.Enabled = true;
                txtShippingPhoneNo.Enabled = true;
                txtShippingEmail.Enabled = true;
                txtShippingAadharNo.Enabled = true;
                txtShippingGSTINNo.Enabled = true;
                hdnIsNewShippingCustomer.Value = "Yes";
            }
            else
            {
                txtShippingCustomerName.Enabled = false;
                txtShippingProprietorName.Enabled = false;
                txtShippingAddressLine1.Enabled = false;
                txtShippingAddressLine2.Enabled = false;
                txtShippingCity.Enabled = false;
                txtShippingPin.Enabled = false;
                txtShippingPhoneNo.Enabled = false;
                txtShippingEmail.Enabled = false;
                txtShippingAadharNo.Enabled = false;
                txtShippingGSTINNo.Enabled = false;
                hdnIsNewShippingCustomer.Value = ddlSearchShippingCustomer.SelectedItem.Value.ToString();

                Fill_ShippingSearchCustomerDetailinForm(Convert.ToInt32(ddlSearchShippingCustomer.SelectedItem.Value.ToString()));
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void Fill_BillingSearchCustomerDetailinForm(Int32 BillingSearchCustomerID)
    {
        try
        {
            dtRecords = new DataTable();
            objBusinessFacadLayer = new BusinessFacadLayer();
            dtRecords = objBusinessFacadLayer.getBillingSearchCustomerDetailinForm(BillingSearchCustomerID);
            if (dtRecords.Rows.Count > 0)
            {
                txtCustomerName.Text = dtRecords.Rows[0]["CustomerName"].ToString();
                txtProprietorName.Text= dtRecords.Rows[0]["BillingProprietorName"].ToString();
                txtAddressLine1.Text = dtRecords.Rows[0]["BillingAddress1"].ToString();
                txtAddressLine2.Text = dtRecords.Rows[0]["BillingAddress2"].ToString();
                txtCity.Text = dtRecords.Rows[0]["BillingCity"].ToString();
                txtPin.Text = dtRecords.Rows[0]["Billingpin"].ToString();
                txtPhoneNo.Text = dtRecords.Rows[0]["BillingPhone"].ToString();
                txtEmail.Text = dtRecords.Rows[0]["BillingEmail"].ToString();
                txtAadharNo.Text = dtRecords.Rows[0]["BillingAadharNo"].ToString();
                txtGSTINNo.Text = dtRecords.Rows[0]["BillingGSTINNo"].ToString();


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

    private string get_FinancialYear()
    {
        try
        {
            if(Convert.ToInt16(DateTime.Now.Month.ToString("00")) >=1 && Convert.ToInt16(DateTime.Now.Month.ToString("00"))<=3)
            {
                return Convert.ToString(Convert.ToInt16(DateTime.Now.Year.ToString())-1 ) + "-"+ DateTime.Now.Year.ToString() ;
            }
           
            return DateTime.Now.Year.ToString() + "-" + Convert.ToString(Convert.ToInt16(DateTime.Now.Year.ToString()) + 1);
        }
        catch(Exception ex)
        {
            throw ex;
        }

    }

    private void Fill_ShippingSearchCustomerDetailinForm(Int32 ShippingSearchCustomerID)
    {
        try
        {
            dtRecords = new DataTable();
            objBusinessFacadLayer = new BusinessFacadLayer();
            dtRecords = objBusinessFacadLayer.getShippingSearchCustomerDetailinForm(ShippingSearchCustomerID);
            if (dtRecords.Rows.Count > 0)
            {
                txtShippingCustomerName.Text = dtRecords.Rows[0]["CustomerName"].ToString();
                txtShippingProprietorName.Text = dtRecords.Rows[0]["ShippingProprietorName"].ToString();
                txtShippingAddressLine1.Text = dtRecords.Rows[0]["ShippingAddress1"].ToString();
                txtShippingAddressLine2.Text = dtRecords.Rows[0]["ShippingAddress2"].ToString();
                txtShippingCity.Text = dtRecords.Rows[0]["ShippingCity"].ToString();
                txtShippingPin.Text = dtRecords.Rows[0]["Shippingpin"].ToString();
                txtShippingPhoneNo.Text = dtRecords.Rows[0]["ShippingPhone"].ToString();
                txtShippingEmail.Text = dtRecords.Rows[0]["ShippingEmail"].ToString();
                txtShippingAadharNo.Text = dtRecords.Rows[0]["ShippingAadharNo"].ToString();
                txtShippingGSTINNo.Text = dtRecords.Rows[0]["ShippingGSTINNo"].ToString();


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

    protected void btnGenerateBill_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvBillItemDetails.Rows.Count > 0)
            {
                objBillMaster = new tbl_BillMaster();
                objBillMaster.FK_BillingCustomerID = Convert.ToInt32(hdnIsNewBillingCustomer.Value);
                objBillMaster.InvoiceDate = Convert.ToDateTime(DateTime.Now.ToString());
                objBillMaster.FK_ShippingCustomerID = Convert.ToInt32(hdnIsNewShippingCustomer.Value);
                objBillMaster.InvoiceTotalAmount = Convert.ToDecimal(txtInvoiceTotal.Text.Trim());
                objBillMaster.TotalDiscountonInvoice = Convert.ToDecimal(lblSummarytotaldiscount.Text);
                objBillMaster.TotalCollectedAmount = Convert.ToDecimal(txtTotalCollectedAmount.Value.ToString().Trim());
                objBillMaster.LoadingnPackingCharges = Convert.ToDecimal(txtLOadingnPackingCharges.Text = string.IsNullOrEmpty(txtLOadingnPackingCharges.Text.Trim()) ? "0" : txtLOadingnPackingCharges.Text.Trim());
                // objBillMaster.InsuranceCharges = Convert.ToDecimal(txtInsuranceCharges.Text.Trim());
                objBillMaster.InsuranceCharges = Convert.ToDecimal(txtInsuranceCharges.Text = string.IsNullOrEmpty(txtInsuranceCharges.Text.Trim()) ? "0" : txtInsuranceCharges.Text.Trim());
                // objBillMaster.OtherCharges = Convert.ToDecimal(txtOtherCharges.Text.Trim());
                objBillMaster.OtherCharges = Convert.ToDecimal(txtOtherCharges.Text = string.IsNullOrEmpty(txtOtherCharges.Text.Trim()) ? "0" : txtOtherCharges.Text.Trim());

                objBillMaster.TransportationMode = ddlTransportationType.SelectedItem.Value.ToString();
                objBillMaster.VehivleNumber = txtVehicalNumber.Text.Trim();
                // objBillMaster.FreightCharges = Convert.ToDecimal(txtFreightCharges.Text.Trim());
                objBillMaster.FreightCharges = Convert.ToDecimal(txtFreightCharges.Text = string.IsNullOrEmpty(txtFreightCharges.Text.Trim()) ? "0" : txtFreightCharges.Text.Trim());
                if (Convert.ToInt16(ddlTransportationType.SelectedItem.Value) > 0)
                {
                    objBillMaster.DateNSupplyofTime = Convert.ToDateTime(DateTime.Now.ToString());
                }
                objBillMaster.FinancialYear = get_FinancialYear();
                objBillMaster.PlaceofSupply = txtPLaceofSupply.Text.Trim();
                objBillMaster.GUID = hdnGUID.Value.ToString();
                objBillMaster.InvoiceStatus = "Success";
                objBillMaster.IsActive = true;
                objBillMaster.IsDeleted = false;
                objBillMaster.CreatedBy = "Admin";
                objBillMaster.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString());
                objBillMaster.TotalCGSTAmount = Convert.ToDecimal(lblSummaryCGSTAmount.Text);
                objBillMaster.TotalSGSTAmount = Convert.ToDecimal(lblSummarySGSTAmount.Text);
                objBillMaster.TotalProductQuantity = Convert.ToInt32(lblSummaryTotalQuantity.Text);

                 objBusinessFacadLayer = new BusinessFacadLayer();

                intBillInvoiceNumber = objBusinessFacadLayer.CreateInvoicenGenerateInvoiceNo(objBillMaster);

                if (intBillInvoiceNumber > 0)
                {
                    objBillDetails = new tbl_BillDetails();

                    for (int i = 0; i < gvBillItemDetails.Rows.Count; i++)
                    {
                        objBillDetails.FK_BillMasterID = intBillInvoiceNumber;
                        objBillDetails.CompanyID = Convert.ToInt32(gvBillItemDetails.Rows[i].Cells[16].Text.ToString());
                        objBillDetails.ProductID = Convert.ToInt32(gvBillItemDetails.Rows[i].Cells[17].Text.ToString());
                        objBillDetails.HSNNo = gvBillItemDetails.Rows[i].Cells[5].Text.ToString();
                        objBillDetails.Qnty = Convert.ToInt32(gvBillItemDetails.Rows[i].Cells[6].Text.ToString());
                        objBillDetails.Rate = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[8].Text.ToString());
                        objBillDetails.UOM = gvBillItemDetails.Rows[i].Cells[7].Text.ToString();
                        objBillDetails.Total = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[9].Text.ToString());
                        objBillDetails.Discount = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[10].Text.ToString());
                        objBillDetails.TaxableValue = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[11].Text.ToString());
                        objBillDetails.SGSTRate = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[12].Text.ToString());
                        objBillDetails.SGSTValue = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[13].Text.ToString());
                        objBillDetails.CGSTRate = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[14].Text.ToString());
                        objBillDetails.CGSTValue = Convert.ToDecimal(gvBillItemDetails.Rows[i].Cells[15].Text.ToString());
                        objBillDetails.GUID = hdnGUID.Value.ToString();
                        objBillDetails.IsActive = true;
                        objBillDetails.IsDeleted = false;
                        objBillDetails.CreatedBy = "Admin";
                        objBillDetails.CreatedOn = Convert.ToDateTime(DateTime.Now.ToString());
                        objBusinessFacadLayer.AddBillDetails(objBillDetails);
                    }
                }
                else
                {

                }
                Response.Redirect("frmTaxInvoice.aspx", false);

            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            objBusinessFacadLayer = null;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmTaxInvoice.aspx", false);
    }
}