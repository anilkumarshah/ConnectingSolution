using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class frmInvoiceReport : System.Web.UI.Page
{
    private DataTable dtRecord;
    private BusinessFacadLayer objBusinessFacadLayer;
    private DataSet dsRecord;
    Int32 RowIndex;
    Int64 intInvoiceNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Fill_BillMasterGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    private void Fill_BillMasterGrid()
    {
        try
        {
            objBusinessFacadLayer = new BusinessFacadLayer();
            dtRecord = new DataTable();
            dtRecord = objBusinessFacadLayer.getBillMasterList(123);

            if (dtRecord.Rows.Count > 0)
            {
                gvBillItemDetails.DataSource = dtRecord;
                gvBillItemDetails.DataBind();
            }
            else
            {
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

    //protected void gvBillItemDetails_PageIndexChanged(object sender, EventArgs e)
    //{
    //    gvMasterGrid.PageIndex = e.NewPageIndex;

    //    //rebind your gridview - GetSource(),Datasource of your GirdView
    //    Fill_Master();
    //}

    protected void gvBillItemDetails_PageIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvBillItemDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBillItemDetails.PageIndex = e.NewPageIndex;

        //rebind your gridview - GetSource(),Datasource of your GirdView
        Fill_BillMasterGrid();
    }
    protected void GridView_Print_Click(object sender, EventArgs e)
    {
        try
        {
            RowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            if (RowIndex > -1)
            {
                intInvoiceNo = Convert.ToInt32(gvBillItemDetails.DataKeys[RowIndex].Value.ToString());

                DownloadPDF("Invoice No -" + Convert.ToString(intInvoiceNo), intInvoiceNo);

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

    private void DownloadPDF(string fileName, Int64 InvoiceNo)
    {
        // Variables
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        objBusinessFacadLayer = new BusinessFacadLayer();
        dsRecord = new DataSet();
        dsRecord = objBusinessFacadLayer.getInvoiceDetails(Convert.ToInt64(InvoiceNo), 0, 0);

        if (dsRecord.Tables["tbl_SKSDetails"].Rows.Count == 1 && dsRecord.Tables["vw_BillInvoiceMaster"].Rows.Count == 1 && dsRecord.Tables["vw_Bill_InvoiceDetails"].Rows.Count > 0)
        {
            // Setup the report viewer object and get the array of bytes
            //ReportViewer ReportViewer1 = new ReportViewer();
            ReportViewer1.Reset();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("RptFile\\rptInvoice-Modified.rdlc");
            ReportDataSource rds = new ReportDataSource("StoreDetail", dsRecord.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.DataBind();
            ReportDataSource rds1 = new ReportDataSource("InvoiceMaster", dsRecord.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(rds1);
            ReportViewer1.DataBind();
            ReportDataSource rds2 = new ReportDataSource("InvoiceDetail", dsRecord.Tables[2]);
            ReportViewer1.LocalReport.DataSources.Add(rds2);

            ReportViewer1.DataBind();

            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download
        }


    }
}