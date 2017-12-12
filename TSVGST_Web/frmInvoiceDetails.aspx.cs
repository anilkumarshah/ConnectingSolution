using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class frmInvoiceDetails : System.Web.UI.Page
{
    BusinessFacadLayer objBusinessFacadLayer;
    DataSet dsRecord;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                mvInvoice.SetActiveView(vwInvoiceDetail);
                if (Request.QueryString.Count == 1)
                {
                    if (Request.QueryString["InvoiceNo"] != null && Request.QueryString["InvoiceNo"].ToString() != "")
                    {
                        objBusinessFacadLayer = new BusinessFacadLayer();
                        dsRecord = new DataSet();
                        dsRecord = objBusinessFacadLayer.getInvoiceDetails(Convert.ToInt64(Request.QueryString["InvoiceNo"].ToString()), 0, 0);

                        if (dsRecord.Tables["tbl_SKSDetails"].Rows.Count == 1 && dsRecord.Tables["vw_BillInvoiceMaster"].Rows.Count == 1 && dsRecord.Tables["vw_Bill_InvoiceDetails"].Rows.Count > 0)
                        {
                            this.ReportViewer1.Reset();
                            ReportViewer1.ProcessingMode = ProcessingMode.Local;
                            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("RptFile\\rptInvoice-Modified.rdlc");
                            ReportDataSource rds = new ReportDataSource("StoreDetail", dsRecord.Tables[0]);
                            this.ReportViewer1.LocalReport.DataSources.Clear();
                            this.ReportViewer1.LocalReport.DataSources.Add(rds);
                            this.ReportViewer1.DataBind();
                            ReportDataSource rds1 = new ReportDataSource("InvoiceMaster", dsRecord.Tables[1]);
                            this.ReportViewer1.LocalReport.DataSources.Add(rds1);
                            this.ReportViewer1.DataBind();
                            ReportDataSource rds2 = new ReportDataSource("InvoiceDetail", dsRecord.Tables[2]);
                            this.ReportViewer1.LocalReport.DataSources.Add(rds2);

                            this.ReportViewer1.DataBind();

                            this.ReportViewer1.LocalReport.Refresh();

                            Fill_Billing_N_ShippingAddress_Transportation_AdditionalCharges(dsRecord);
                            Fill_InvoiceItemDetails(dsRecord);
                            Fill_PriceSummaryFor_InvoiceItem();
                            //Fill_Transportation_Details(dsRecord.Tables["InvoiceMaster"]);
                            //Fill_Invoice_OtherCharges(dsRecord.Tables["InvoiceMaster"]);
                        }

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
                dsRecord.Dispose();
            }
        }
    }

  private void Fill_Billing_N_ShippingAddress_Transportation_AdditionalCharges(DataSet dtInvoiceMaster)
    {
        try
        {
            #region Setting Billing Address
            lblBillingNameGSTIN.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["CustomerName"].ToString() + "  [ <b>GSTIN No - " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["BillingGSTINNo"].ToString() + "</b> ]";
            lblBillingAddress.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["BillingAddress1"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["BillingAddress2"].ToString();
            lblBillingCityStatePin.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["BillingCity"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["BillingStateName"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["Billingpin"].ToString();
            lblBillingContact.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["BillingPhone"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["BillingEmail"].ToString();
            #endregion

            #region Setting Shipping Address
            lblShippingNameGSTIN.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingCustomerName"].ToString() + "  [ <b>GSTIN No - " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingGSTINNo"].ToString() + "</b> ]";
            lblShippingAddress.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingAddress1"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingAddress2"].ToString();
            lblShippingCityStatePin.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingCity"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingStateName"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["Billingpin"].ToString();
            lblShippingContact.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingPhone"].ToString() + ", " + dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["ShippingEmail"].ToString();
            #endregion

            #region Transportation Charges
            txtTransportationType.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["TransportationMode"].ToString();
            txtPLaceofSupply.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["PlaceofSupply"].ToString();
            txtDatenTimeofSupply.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["DateNSupplyofTime"].ToString();
            txtVehicalNumber.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["VehivleNumber"].ToString();
            #endregion

            #region Additional Charges
            txtFreightCharges.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["FreightCharges"].ToString();
            txtInsuranceCharges.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["InsuranceCharges"].ToString();
            txtLOadingnPackingCharges.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["LoadingnPackingCharges"].ToString();
            txtOtherCharges.Text = dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["OtherCharges"].ToString();
            #endregion

            lblInvoiceNoValue.Text= dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["FinancialYear"].ToString().Trim() +"/" +dtInvoiceMaster.Tables["vw_BillInvoiceMaster"].Rows[0]["InvoiceID"].ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtInvoiceMaster.Dispose();
        }
    }

    private void Fill_InvoiceItemDetails(DataSet dtInvoiceDetails)
    {
        try
        {
            if (dtInvoiceDetails.Tables["vw_Bill_InvoiceDetails"].Rows.Count > 0)
            {
                gvBillItemDetails.DataSource = dtInvoiceDetails.Tables["vw_Bill_InvoiceDetails"];
                gvBillItemDetails.DataBind();

                //gvBillItemDetails.Columns[16].Visible = false;
                //gvBillItemDetails.Columns[17].Visible 
                //CalculateTotalItemAmountinGrid();

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
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    private void Fill_PriceSummaryFor_InvoiceItem()
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

                    SummaryTotalQuantity += Convert.ToInt32(gvBillItemDetails.Rows[i].Cells[4].Text.ToString());
                    SummaryTotalAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[7].Text.ToString());
                    SummaryTotaldiscount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[8].Text.ToString());
                    SummaryTaxableAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[9].Text.ToString());
                    SummarySGSTAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[11].Text.ToString());
                    SummaryCGSTAmount += Convert.ToDouble(gvBillItemDetails.Rows[i].Cells[13].Text.ToString());
                }

                txtInvoiceTotal.Text = Convert.ToString(SummaryTotalAmount - SummaryTotaldiscount + SummarySGSTAmount + SummaryCGSTAmount);
                txtTotalCollectedAmount.Value = Convert.ToString(Convert.ToDecimal(string.IsNullOrEmpty(txtInvoiceTotal.Text.Trim()) ? "0" : txtInvoiceTotal.Text.Trim()) + Convert.ToDecimal(string.IsNullOrEmpty(txtLOadingnPackingCharges.Text.Trim()) ? "0" : txtLOadingnPackingCharges.Text.Trim()) + Convert.ToDecimal(string.IsNullOrEmpty(txtFreightCharges.Text.Trim()) ? "0" : txtFreightCharges.Text.Trim()) + Convert.ToDecimal(string.IsNullOrEmpty(txtInsuranceCharges.Text.Trim()) ? "0" : txtInsuranceCharges.Text.Trim()) + Convert.ToDecimal(string.IsNullOrEmpty(txtOtherCharges.Text.Trim()) ? "0" : txtOtherCharges.Text.Trim()));
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
        finally
        {

        }
    }
    //private void Fill_Transportation_Details(DataTable dtInvoiceMaster)
    //{
    //    try
    //    {
           
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {

    //    }
    //}
    //private void Fill_Invoice_OtherCharges(DataTable dtInvoiceMaster)
    //{
    //    try
    //    {
            
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {

    //    }
    //}
}