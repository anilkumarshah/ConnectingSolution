<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmInvoiceReport.aspx.cs" Inherits="frmInvoiceReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
   

   <%-- <div class="form-group">
        <label class="label">Name</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control text-uppercase"></asp:TextBox><br />
        <input type="text" id="name" class="form-control text-uppercase" />
    </div>--%>



  <%--  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
      <%--  <fieldset>
            <legend>Invoice Report </legend>--%>

    <div class="col-lg-12"><h3>Invoice Report</h3><hr /></div>
            
                <div class="table-responsive">
                  
                        <asp:GridView ID="gvBillItemDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table table-condensed table-hover table-bordered table-striped" EmptyDataText="No item added!" PageSize="25" OnPageIndexChanging="gvBillItemDetails_PageIndexChanging" DataKeyNames="BillId" PagerStyle-CssClass="pagination">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice No">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("BillId", "~/frmInvoiceDetails.aspx?InvoiceNo={0}") %>' onclick="javascript:w= window.open(this.href,'Download Image','left=20,top=20,width=1100,height=600,toolbar=0,resizable=1,scrollbars=1');return false;"
                                            Text='<%# Eval("BillId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%--  <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("BillId", "~/frmInvoiceDetails.aspx?InvoiceNo={0}") %>' onclick="javascript:w= window.open(this.href,'Download Image','left=20,top=20,width=1000,height=600,toolbar=0,resizable=1,scrollbars=1');return false;"
                                            Text="Invoice Detail" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" />
                               <%-- <asp:BoundField DataField="CustomerName" HeaderText="Billing Customer" />--%>
                                 <asp:BoundField DataField="TotalProductQuantity" HeaderText="Total Bag Count" />
                                 <asp:BoundField DataField="InvoiceTotalAmount" HeaderText="Invoice Total Amount" />
                                  <asp:BoundField DataField="TotalSGSTAmount" HeaderText=" Total SGST Value" />
                                 <asp:BoundField DataField="TotalCGSTAmount" HeaderText="Total CGST Value" />
                               
                                <asp:BoundField DataField="TotalDiscountonInvoice" HeaderText="Discount" />
                                <asp:BoundField DataField="TotalCollectedAmount" HeaderText="Total Collected Amount" />
                                <asp:BoundField DataField="PlaceofSupply" HeaderText="Place of Supply" />
                                <asp:BoundField DataField="FreightCharges" HeaderText="Freight Charges" />
                                
                                
                                <%--<asp:BoundField DataField="Total" HeaderText="Total" />
                                    <asp:BoundField DataField="Discount" HeaderText="Discount" />
                                    <asp:BoundField DataField="TaxableValue" HeaderText="Taxable Value" />
                                    <asp:BoundField DataField="SGSTRate" HeaderText="SGST Rate" />
                                    <asp:BoundField DataField="SGSTValue" HeaderText="SGST Value" />
                                    <asp:BoundField DataField="CGSTRate" HeaderText="CGST Rate" />
                                   
                                    <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" Visible="true" />--%>
                                <asp:BoundField DataField="InvoiceStatus" HeaderText="Status" />
                                <%--  <asp:TemplateField ShowHeader="False" Visible="true">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="gvbtnEdit" runat="server" AlternateText="InvoiceDetail" CommandName="InvoiceDetail" Text="Invoice Detail" OnClientClick="window.open('frmInvoiceDetails.aspx?InvoiceNo={0}','','left=100,top=50,width=400,height=300,scrollbars=1');return false;"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("BillId", "~/frmInvoiceDetails.aspx?InvoiceNo={0}") %>' onclick="javascript:w= window.open(this.href,'Download Image','left=20,top=20,width=1100,height=600,toolbar=0,resizable=1,scrollbars=1');return false;"
                                            Text="VIEW" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="gvbtnDelete" runat="server" AlternateText="Delete" CommandArgument='<%#Eval("BillId") %>' CommandName="Print" OnClientClick="return confirm('Are you sure you want to print this Invoice?');" Text="DOWNLOAD" OnClick="GridView_Print_Click"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                          
                            <%--<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />--%>
                        </asp:GridView>
                   
                </div>
           

     <%--   </fieldset>--%>
   <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>


