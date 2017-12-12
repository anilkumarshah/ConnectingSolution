<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInvoiceDetails.aspx.cs" Inherits="frmInvoiceDetails" EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="form-group">


            <asp:MultiView ID="mvInvoice" runat="server">
                <asp:View ID="vwInvoiceDetail" runat="server">
                    <div class="container text-uppercase">
                        <fieldset>
                            <legend>
                                <h3>Invoice No -[
                                    <asp:Label ID="lblInvoiceNoValue" runat="server" Style="color: maroon"></asp:Label>
                                    ] </h3>
                            </legend>
                        </fieldset>
                        <div class="row text-uppercase">
                            <br />
                            <div class="col-md-6">
                                <fieldset>
                                    <legend>Billing Address </legend>
                                    <asp:Label ID="lblBillingNameGSTIN" runat="server" Text="#" CssClass="text-uppercase"></asp:Label><br />
                                    <asp:Label ID="lblBillingAddress" runat="server" Text="#" CssClass="text-uppercase"></asp:Label><br />
                                    <asp:Label ID="lblBillingCityStatePin" runat="server" Text="#" CssClass="text-uppercase"></asp:Label><br />
                                    <asp:Label ID="lblBillingContact" runat="server" Text="#" CssClass="text-uppercase"></asp:Label>
                                </fieldset>
                            </div>
                            <div class="col-md-6">
                                <fieldset>
                                    <legend>Shipping Address </legend>
                                    <asp:Label ID="lblShippingNameGSTIN" runat="server" Text="#"></asp:Label><br />
                                    <asp:Label ID="lblShippingAddress" runat="server" Text="#"></asp:Label><br />
                                    <asp:Label ID="lblShippingCityStatePin" runat="server" Text="#"></asp:Label><br />
                                    <asp:Label ID="lblShippingContact" runat="server" Text="#"></asp:Label>
                                </fieldset>
                            </div>
                        </div>

                        <fieldset>
                            <legend></legend>
                            <div class="row text-uppercase alert alert-info" style="font-weight:bold;">
                               
                                    <div class="form-group form-inline col-lg-2 text-uppercase">
                                        Total Quantity&nbsp;-&nbsp;
                                    <asp:Label ID="lblSummaryTotalQuantity" runat="server" Text="000"></asp:Label>
                                    </div>
                                    <div class="form-group form-inline col-lg-2 text-uppercase">
                                        Total Amount&nbsp;-&nbsp;
                                    <asp:Label ID="lblSummaryTotalAmount" runat="server" Text="0.00"></asp:Label>
                                    </div>
                                    <div class="form-group form-inline col-lg-2">
                                        Total Discount&nbsp;-&nbsp;
                                    <asp:Label ID="lblSummarytotaldiscount" runat="server" Text="0.00"></asp:Label>
                                    </div>

                                    <div class="form-group form-inline col-lg-2 ">
                                        Taxable total&nbsp;-&nbsp;
                                    <asp:Label ID="lblSummaryTaxableAmount" runat="server" Text="0.00"></asp:Label>
                                    </div>
                                    <div class="form-group form-inline col-lg-2 ">
                                        Total SGST amount&nbsp;-&nbsp;
                                    <asp:Label ID="lblSummarySGSTAmount" runat="server" Text="0.00"></asp:Label>
                                    </div>
                                    <div class="form-group form-inline col-lg-2 ">
                                        Total CGST amount&nbsp;-&nbsp;
                                    <asp:Label ID="lblSummaryCGSTAmount" runat="server" Text="0.00" Style="font-weight: bold;"></asp:Label>
                                    </div>
                               
                            </div>
                        </fieldset>
                        <div class="row">
                            <div class="table-responsive">
                                <b>
                                    <asp:GridView ID="gvBillItemDetails" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-condensed table-hover table-bordered table-striped" EmptyDataText="No item !" PageSize="10">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                                                <asp:BoundField DataField="GUID" HeaderText="GUID" Visible="false" />--%>
                                            <asp:BoundField DataField="CompanyName" HeaderText="Company" Visible="true" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product" />
                                            <asp:BoundField DataField="HSNNo" HeaderText="HSN Code" />
                                            <asp:BoundField DataField="Qnty" HeaderText="Qty" />
                                            <asp:BoundField DataField="UOM" HeaderText="UOM" />
                                            <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                            <asp:BoundField DataField="Total" HeaderText="Total" />
                                            <asp:BoundField DataField="Discount" HeaderText="Discount" />
                                            <asp:BoundField DataField="TaxableValue" HeaderText="Taxable Value" />
                                            <asp:BoundField DataField="SGSTRate" HeaderText="SGST Rate" />
                                            <asp:BoundField DataField="SGSTValue" HeaderText="SGST Value" />
                                            <asp:BoundField DataField="CGSTRate" HeaderText="CGST Rate" />
                                            <asp:BoundField DataField="CGSTValue" HeaderText="CGST Value" />
                                            <%-- <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                                                <asp:BoundField DataField="ProductID" HeaderText="ProductID" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />--%>
                                            <%--  <asp:TemplateField ShowHeader="False" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="gvbtnEdit" runat="server" AlternateText="EDIT" CommandName="Edit" Text="EDIT" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="gvbtnDelete" runat="server" AlternateText="Delete" CommandArgument='<%#Eval("ID") %>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this event?');" Text="DELETE" OnClick="GridView_Button_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                        </Columns>
                                        <%--<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />--%>
                                    </asp:GridView>
                                </b>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-lg-4">


                                <div id="dvTransportationDetails" style="display: block;">
                                    <div class="row">
                                        <div class="form-group form-inline col-lg-6 text-uppercase">
                                            <b>Transportation Type</b>
                                            <asp:TextBox ID="txtTransportationType" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-6">
                                            <b>Vehical number</b>
                                            <asp:TextBox ID="txtVehicalNumber" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-lg-6">
                                            <b>Date & Time of Supply</b>
                                            <asp:TextBox ID="txtDatenTimeofSupply" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>

                                        <div class="form-group col-lg-6">
                                            <b>Place of Supply</b>
                                            <asp:TextBox ID="txtPLaceofSupply" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="col-lg-4">


                                <div id="dvAdditionalCharges" style="display: block;">
                                    <div class="row">
                                        <div class="form-group form-inline col-lg-6 text-uppercase">
                                            <b>Frieght Charges</b>
                                            <asp:TextBox ID="txtFreightCharges" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-lg-6">
                                            <b>Loading &amp; Packing Charges</b>
                                            <asp:TextBox ID="txtLOadingnPackingCharges" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-lg-6">
                                            <b>Insurance Charges</b>
                                            <asp:TextBox ID="txtInsuranceCharges" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>

                                        <div class="form-group col-lg-6">
                                            <b>Other Charges</b>
                                            <asp:TextBox ID="txtOtherCharges" runat="server" CssClass="form-control form-inline" Text="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="col-lg-2">
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-2 control-label">Invoice Total</label>
                                    <div class="col-lg-2"></div>
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtInvoiceTotal" runat="server" class="form-control" placeholder="Invoice Total" ReadOnly="true"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCollectedTotal" class="col-sm-2 control-label">Collected Total</label>
                                    <div class="col-lg-2"></div>
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <%--  <asp:TextBox ID="txtTotalCollectedAmount" runat="server" class="form-control" placeholder="Collected Total"></asp:TextBox>--%>
                                            <input type="text" id="txtTotalCollectedAmount" runat="server" class="form-control" placeholder="Collected Total" readonly="true" />

                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>


                    </div>
                </asp:View>
                <asp:View ID="vcInvoiceRDLC" runat="server">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                        <LocalReport ReportPath="RptFile\Report2.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource6" Name="DataSet1" />
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource7" Name="DataSet2" />
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource8" Name="DataSet3" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" SelectMethod="Copy" TypeName="dsInvoiceDetails"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="Copy" TypeName="dsInvoiceMaster"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="Clone" TypeName="dsStoreDetail"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="BillInvoiceDetailsDataSetTableAdapters.vw_Bill_InvoiceDetailsTableAdapter"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="BillInvoiceMasterDataSetTableAdapters.vw_BillInvoiceMasterTableAdapter"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SKSDetailsDataSetTableAdapters.tbl_SKSDetailsTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_Id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ShopName" Type="String" />
                            <asp:Parameter Name="ShopProperiterName" Type="String" />
                            <asp:Parameter Name="ShopAddressLine1" Type="String" />
                            <asp:Parameter Name="ShopAddressLine2" Type="String" />
                            <asp:Parameter Name="ShopCity" Type="String" />
                            <asp:Parameter Name="ShopState" Type="String" />
                            <asp:Parameter Name="ShopPin" Type="String" />
                            <asp:Parameter Name="ShopPhoneNo" Type="String" />
                            <asp:Parameter Name="ShopEmail" Type="String" />
                            <asp:Parameter Name="MobileNo" Type="String" />
                            <asp:Parameter Name="ShopWebsite" Type="String" />
                            <asp:Parameter Name="ShopGSTINNo" Type="String" />
                            <asp:Parameter Name="ShopPropriterSignature" Type="Object" />
                            <asp:Parameter Name="ContactPersonName" Type="String" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="IsDeleted" Type="Boolean" />
                            <asp:Parameter Name="CreatedBy" Type="String" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="UpdatedBy" Type="String" />
                            <asp:Parameter Name="UpdatedOn" Type="DateTime" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ShopName" Type="String" />
                            <asp:Parameter Name="ShopProperiterName" Type="String" />
                            <asp:Parameter Name="ShopAddressLine1" Type="String" />
                            <asp:Parameter Name="ShopAddressLine2" Type="String" />
                            <asp:Parameter Name="ShopCity" Type="String" />
                            <asp:Parameter Name="ShopState" Type="String" />
                            <asp:Parameter Name="ShopPin" Type="String" />
                            <asp:Parameter Name="ShopPhoneNo" Type="String" />
                            <asp:Parameter Name="ShopEmail" Type="String" />
                            <asp:Parameter Name="MobileNo" Type="String" />
                            <asp:Parameter Name="ShopWebsite" Type="String" />
                            <asp:Parameter Name="ShopGSTINNo" Type="String" />
                            <asp:Parameter Name="ShopPropriterSignature" Type="Object" />
                            <asp:Parameter Name="ContactPersonName" Type="String" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="IsDeleted" Type="Boolean" />
                            <asp:Parameter Name="CreatedBy" Type="String" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="UpdatedBy" Type="String" />
                            <asp:Parameter Name="UpdatedOn" Type="DateTime" />
                            <asp:Parameter Name="Original_Id" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SKSDetailsDataSetTableAdapters.tbl_SKSDetailsTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_Id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ShopName" Type="String" />
                            <asp:Parameter Name="ShopProperiterName" Type="String" />
                            <asp:Parameter Name="ShopAddressLine1" Type="String" />
                            <asp:Parameter Name="ShopAddressLine2" Type="String" />
                            <asp:Parameter Name="ShopCity" Type="String" />
                            <asp:Parameter Name="ShopState" Type="String" />
                            <asp:Parameter Name="ShopPin" Type="String" />
                            <asp:Parameter Name="ShopPhoneNo" Type="String" />
                            <asp:Parameter Name="ShopEmail" Type="String" />
                            <asp:Parameter Name="MobileNo" Type="String" />
                            <asp:Parameter Name="ShopWebsite" Type="String" />
                            <asp:Parameter Name="ShopGSTINNo" Type="String" />
                            <asp:Parameter Name="ShopPropriterSignature" Type="Object" />
                            <asp:Parameter Name="ContactPersonName" Type="String" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="IsDeleted" Type="Boolean" />
                            <asp:Parameter Name="CreatedBy" Type="String" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="UpdatedBy" Type="String" />
                            <asp:Parameter Name="UpdatedOn" Type="DateTime" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ShopName" Type="String" />
                            <asp:Parameter Name="ShopProperiterName" Type="String" />
                            <asp:Parameter Name="ShopAddressLine1" Type="String" />
                            <asp:Parameter Name="ShopAddressLine2" Type="String" />
                            <asp:Parameter Name="ShopCity" Type="String" />
                            <asp:Parameter Name="ShopState" Type="String" />
                            <asp:Parameter Name="ShopPin" Type="String" />
                            <asp:Parameter Name="ShopPhoneNo" Type="String" />
                            <asp:Parameter Name="ShopEmail" Type="String" />
                            <asp:Parameter Name="MobileNo" Type="String" />
                            <asp:Parameter Name="ShopWebsite" Type="String" />
                            <asp:Parameter Name="ShopGSTINNo" Type="String" />
                            <asp:Parameter Name="ShopPropriterSignature" Type="Object" />
                            <asp:Parameter Name="ContactPersonName" Type="String" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="IsDeleted" Type="Boolean" />
                            <asp:Parameter Name="CreatedBy" Type="String" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="UpdatedBy" Type="String" />
                            <asp:Parameter Name="UpdatedOn" Type="DateTime" />
                            <asp:Parameter Name="Original_Id" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SKSDetailsDataSetTableAdapters.tbl_SKSDetailsTableAdapter"></asp:ObjectDataSource>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <link href="Content/Site.css" rel="stylesheet" />
</body>

</html>
