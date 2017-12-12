<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmTaxInvoice.aspx.cs" Inherits="frmTaxInvoice" UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style>
        .Hide {
            display: none;
        }
    </style>
    <asp:MultiView ID="mvwTaxInvoiceBill" runat="server">
        <asp:View ID="vwTaxInvoiceCustomer" runat="server">
            <asp:ValidationSummary ID="validationsummary2" runat="server" ShowMessageBox="true" DisplayMode="List" ValidationGroup="AddCustomerDetails" ShowSummary="false" />
            <div class="row ">

                <div class="col-md-3 text-uppercase">
                    <br />'
                    <br />
                    <fieldset>
                        <legend>Billing Address:</legend>
                        <div class="form-group">
                            <%--  <div class="row">--%>
                            <div class="label">Search Customer</div>
                            <asp:DropDownList ID="ddlSearchBillingCustomer" runat="server" CssClass="custom-select" OnSelectedIndexChanged="ddlSearchBillingCustomer_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0" Text="--Select--" Selected="True" />
                            </asp:DropDownList>
                            <%-- </div>--%>
                        </div>
                        <div class="form-group text-uppercase">
                            <div class="label">Customer Name</div>
                            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control" placeholder="Customer Name" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtCustomerName" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="Enter Billing Customer Name" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                         <div class="form-group text-uppercase">
                            <div class="label">proprietor Name</div>
                            <asp:TextBox ID="txtProprietorName" runat="server" CssClass="form-control" placeholder="Customer Name" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProprietorName" ErrorMessage="Enter Billing Proprietor Name" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="label">Address Line 1</div>
                            <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="form-control text-uppercase" placeholder="Address Line 1" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtAddressLine1" runat="server" ControlToValidate="txtAddressLine1" ErrorMessage="Enter Billing Customer Address Line 1" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group text-uppercase">
                            <div class="label">Address Line 2</div>
                            <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control text-uppercase" placeholder="Address Line 2" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="label">City</div>
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City" MaxLength="25"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtCity" runat="server" ControlToValidate="txtCity" ErrorMessage="Enter Billing Customer City" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="label">State</div>
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Enabled="false">
                                <asp:ListItem Text="Mumbai" Value="1" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <div class="label">Pin</div>
                            <asp:TextBox ID="txtPin" runat="server" CssClass="form-control" placeholder="Pin" MaxLength="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtPin" runat="server" ControlToValidate="txtPin" ErrorMessage="Enter Billing Customer Pin" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <div class="label">Phone No</div>
                            <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" placeholder="Phone No" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtPhoneNo" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="Enter Billing Customer Phone" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="label">E-Mail</div>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="label">Aadhar No</div>
                            <asp:TextBox ID="txtAadharNo" runat="server" CssClass="form-control" placeholder="Aadhar No" MaxLength="25"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGSTINNo" ErrorMessage="Enter Billing Customer GSTIN No" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None" ></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group">
                            <div class="label">GSTIN No</div>
                            <asp:TextBox ID="txtGSTINNo" runat="server" CssClass="form-control" placeholder="GSTIN Number" MaxLength="25"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtGSTINNo" runat="server" ControlToValidate="txtGSTINNo" ErrorMessage="Enter Billing Customer GSTIN No" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:CheckBox ID="chkSameShippingAddress" runat="server" placeholder="Customer Name" Text="Same as Billing"></asp:CheckBox>
                    </div>
                    <fieldset>
                        <legend>Shipping Address:</legend>
                        <div class="form-group">
                            <div class="row">
                                <div class="label">Search Customer</div>
                                <asp:DropDownList ID="ddlSearchShippingCustomer" runat="server" CssClass="form-control custom-select" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchShippingCustomer_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="--Select--" Selected="True" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">

                            <div class="label">Customer Name</div>
                            <asp:TextBox ID="txtShippingCustomerName" runat="server" CssClass="form-control" placeholder="Customer Name" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtShippingCustomerName" runat="server" ControlToValidate="txtShippingCustomerName" ErrorMessage="Enter Shipping Customer Name" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                          <div class="form-group">

                            <div class="label">Proprietor Name</div>
                            <asp:TextBox ID="txtShippingProprietorName" runat="server" CssClass="form-control" placeholder="Customer Name" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtShippingProprietorName" ErrorMessage="Enter Shipping Proprietor Name" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="label">Address Line 1</div>
                            <asp:TextBox ID="txtShippingAddressLine1" runat="server" CssClass="form-control" placeholder="Address Line 1" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtShippingAddressLine1" runat="server" ControlToValidate="txtShippingAddressLine1" ErrorMessage="Enter Shipping Customer Address Line 1" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="label">Address Line 2</div>
                            <asp:TextBox ID="txtShippingAddressLine2" runat="server" CssClass="form-control" placeholder="Address Line 2" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="label">City</div>
                            <asp:TextBox ID="txtShippingCity" runat="server" CssClass="form-control" placeholder="City" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtShippingCity" runat="server" ControlToValidate="txtShippingCity" ErrorMessage="Enter Shipping Customer City" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="label">State</div>
                            <asp:DropDownList ID="ddlShippingState" runat="server" CssClass="form-control" Enabled="false">
                                <asp:ListItem Text="Mumbai" Value="1" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <div class="label">Pin</div>
                            <asp:TextBox ID="txtShippingPin" runat="server" CssClass="form-control" placeholder="Pin" MaxLength="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtShippingPin" runat="server" ControlToValidate="txtShippingPin" ErrorMessage="Enter Shipping Customer Pin" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <div class="label">Phone No</div>
                            <asp:TextBox ID="txtShippingPhoneNo" runat="server" CssClass="form-control" placeholder="Phone No" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtShippingPhoneNo" runat="server" ControlToValidate="txtShippingPhoneNo" ErrorMessage="Enter Shipping Customer Phone" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="label">E-Mail</div>
                            <asp:TextBox ID="txtShippingEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="label">Aadhar No</div>
                            <asp:TextBox ID="txtShippingAadharNo" runat="server" CssClass="form-control" placeholder="Aadhar No" MaxLength="15"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGSTINNo" ErrorMessage="Enter Billing Customer GSTIN No" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None" ></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group">
                            <div class="label">GSTIN No</div>
                            <asp:TextBox ID="txtShippingGSTINNo" runat="server" CssClass="form-control" placeholder="GSTIN Number" MaxLength="25"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtShippingGSTINNo" runat="server" ControlToValidate="txtShippingGSTINNo" ErrorMessage="Enter Shipping Customer GSTIN No" SetFocusOnError="true" InitialValue="" ValidationGroup="AddCustomerDetails" Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="col-md-12 btn-group">
                <asp:Button ID="btnAddItemInInvoice" runat="server" CssClass="btn btn-success " Text="Add Item In Tax Invoice" ValidationGroup="AddCustomerDetails" OnClick="btnAddItemInInvoice_Click" />
                <asp:Button ID="btnReset" runat="server" CssClass="btn btn-info " Text="Reset" />
            </div>

        </asp:View>
        <asp:View ID="vwTaxInvoiceBillGeneration" runat="server">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Add Item" ShowMessageBox="true" ValidationGroup="AddItem" ShowSummary="false" />
            <div class="row text-uppercase">
                <br />
                <div class="col-md-6">
                    <fieldset>
                        <legend>Billing Address <small>[<asp:LinkButton ID="lnkbtnBillingAddChange" runat="server">  EDIT </asp:LinkButton>]</small></legend>
                        <asp:Label ID="lblBillingNameGSTIN" runat="server" Text="#" CssClass="text-uppercase"></asp:Label><br />
                        <asp:Label ID="lblBillingAddress" runat="server" Text="#" CssClass="text-uppercase"></asp:Label><br />
                        <asp:Label ID="lblBillingCityStatePin" runat="server" Text="#" CssClass="text-uppercase"></asp:Label><br />
                        <asp:Label ID="lblBillingContact" runat="server" Text="#" CssClass="text-uppercase"></asp:Label>
                    </fieldset>
                </div>
                <div class="col-md-6">
                    <fieldset>
                        <legend>Shipping Address <small>[<asp:LinkButton ID="lnkbtnShippingAddChange" runat="server">  EDIT </asp:LinkButton>]</small></legend>
                        <asp:Label ID="lblShippingNameGSTIN" runat="server" Text="#"></asp:Label><br />
                        <asp:Label ID="lblShippingAddress" runat="server" Text="#"></asp:Label><br />
                        <asp:Label ID="lblShippingCityStatePin" runat="server" Text="#"></asp:Label><br />
                        <asp:Label ID="lblShippingContact" runat="server" Text="#"></asp:Label>
                    </fieldset>
                </div>
            </div>
            <p></p>
            <div class="row">

                <fieldset>
                    <legend>Item Details</legend>
                    <div class="col-md-1">
                        <div>&nbsp;</div>
                        <div class="form-group">
                            <label>Company</label>
                            <asp:DropDownList CssClass="form-control" runat="server" ID="ddlCompany" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlCompany" runat="server" ErrorMessage="Select Company" ControlToValidate="ddlCompany" InitialValue="0" SetFocusOnError="true" ValidationGroup="AddItem" Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div>&nbsp;</div>
                        <div class="form-group">
                            <label>Product</label>
                            <asp:DropDownList CssClass="form-control" runat="server" ID="ddlcompanyProduct" OnSelectedIndexChanged="ddlcompanyProduct_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlcompanyProduct" runat="server" ErrorMessage="Select Product" ControlToValidate="ddlcompanyProduct" InitialValue="0" SetFocusOnError="true" ValidationGroup="AddItem" Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div>&nbsp;</div>
                        <div class="form-group">
                            <label>HSN</label>
                            <%--   <asp:TextBox ID="txtHSNNo" runat="server" CssClass="form-control"></asp:TextBox>--%>
                            <asp:Label ID="lblHSNCode" runat="server" CssClass="form-control" Text="#"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div>&nbsp;</div>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Qty</label>
                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtQuantity" runat="server" ErrorMessage="Enter Item Quantity" ControlToValidate="txtQuantity" InitialValue="" SetFocusOnError="true" ValidationGroup="AddItem" Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>UOM</label>
                                    <%--    <asp:TextBox ID="txtUOM" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:Label ID="lblUOM" runat="server" CssClass="form-control" Text="#"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Rate</label>
                                    <%--  <asp:TextBox ID="txtRate" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:Label ID="lblRate" runat="server" CssClass="form-control" Text="#"></asp:Label>
                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Product Rate can not be 0" ControlToValidate="lblRate" InitialValue="#" SetFocusOnError="true" ValidationGroup="AddItem" Display="None"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="col-md-1">
                        <div>&nbsp;</div>
                        <div class="form-group">
                            <label>Total</label>
                            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Product Total can not be 0" ControlToValidate="txtTotal" InitialValue="" SetFocusOnError="true" ValidationGroup="AddItem" Display="None"></asp:RequiredFieldValidator>
                            <%--<asp:Label ID="lblTotal" runat="server" CssClass="form-control" Text="#"></asp:Label>--%>
                        </div>
                    </div>

                    <div class="col-md-1">
                        <div>&nbsp;</div>
                        <div class="form-group">
                            <label>Discount</label>
                            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" Text="0.00"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div>&nbsp;</div>
                        <div class="form-group">
                            <label>Taxable Value</label>
                            <asp:TextBox ID="txtTaxableValue" runat="server" CssClass="form-control"></asp:TextBox>
                            <%-- <asp:Label ID="lblTaxableValue" runat="server" CssClass="form-control" Text="#"></asp:Label>--%>
                        </div>
                    </div>

                    <div class="col-md-1">
                        <div>
                            <center><b>SGST</b></center>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Rate</label>
                                    <%-- <asp:TextBox ID="txtCGSTRate" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:Label ID="lblSGSTRate" runat="server" CssClass="form-control" Text="#"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Value</label>
                                    <asp:TextBox ID="txtSGSTValue" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%-- <asp:Label ID="lblSGSTValue" runat="server" CssClass="form-control" Text="#"></asp:Label>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-1">
                        <div>
                            <center><b>CGST</b></center>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Rate</label>
                                    <%-- <asp:TextBox ID="txtCGSTRate" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:Label ID="lblCGSTRate" runat="server" CssClass="form-control" Text="#"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Value</label>
                                    <asp:TextBox ID="txtCGSTValue" runat="server" CssClass="form-control" Style="display: marker; visibility: visible"></asp:TextBox>
                                    <%--<asp:Label ID="lblCGSTValue" runat="server" CssClass="form-control" Text="#"></asp:Label>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-1">
                        <div>&nbsp;</div>
                        <div class="row">
                            <div class="col-md-3"></div>
                            <div class="col-md-9">
                                <div class="form-group">
                                    <center> <label>ADD</label></center>
                                    <%--  <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:Button ID="btnAddItem" runat="server" CssClass="btn btn-success " Text="Add Item" OnClick="btnAddItem_Click" ValidationGroup="AddItem" />
                                </div>
                            </div>
                        </div>

                    </div>


                </fieldset>
            </div>

            <fieldset>
                <legend></legend>
                <div class="row text-uppercase">

                    <div class="form-group form-inline col-lg-2 text-uppercase">
                        <b>Total Quantity</b>
                        <asp:Label ID="lblSummaryTotalQuantity" runat="server" Text="000"></asp:Label>
                    </div>
                    <div class="form-group form-inline col-lg-2 text-uppercase">
                        <b>Total Amount</b>
                        <asp:Label ID="lblSummaryTotalAmount" runat="server" Text="0.00"></asp:Label>
                    </div>
                    <div class="form-group form-inline col-lg-2">
                        <b>Total Discount</b>
                        <asp:Label ID="lblSummarytotaldiscount" runat="server" Text="0.00"></asp:Label>
                    </div>

                    <div class="form-group form-inline col-lg-2 ">
                        <b>Taxable total</b>
                        <asp:Label ID="lblSummaryTaxableAmount" runat="server" Text="0.00"></asp:Label>
                    </div>
                    <div class="form-group form-inline col-lg-2 ">
                        <b>Total SGST amount</b>
                        <asp:Label ID="lblSummarySGSTAmount" runat="server" Text="0.00"></asp:Label>
                    </div>
                    <div class="form-group form-inline col-lg-2 ">
                        <b>Total CGST amount</b>
                        <asp:Label ID="lblSummaryCGSTAmount" runat="server" Text="0.00"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="table-responsive">
                        <b>
                            <asp:GridView ID="gvBillItemDetails" runat="server" AllowPaging="false" AutoGenerateColumns="false" CssClass="table table-condensed table-hover table-bordered table-striped" EmptyDataText="No item added!" PageSize="10" DataKeyNames="Id">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                                    <asp:BoundField DataField="GUID" HeaderText="GUID" Visible="false" />
                                    <asp:BoundField DataField="Company" HeaderText="Company" Visible="true" />
                                    <asp:BoundField DataField="Product" HeaderText="Product" />
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
                                    <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                                    <asp:TemplateField ShowHeader="False" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="gvbtnEdit" runat="server" AlternateText="EDIT" CommandName="Edit" Text="EDIT" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="gvbtnDelete" runat="server" AlternateText="Delete" CommandArgument='<%#Eval("ID") %>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this event?');" Text="DELETE" OnClick="GridView_Button_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <%--<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />--%>
                            </asp:GridView>
                        </b>
                    </div>
                </div>

            </fieldset>

            <div class="row">
                <div class="col-lg-4">
                    <fieldset>
                        <legend>Transportation Details &nbsp;<input type="checkbox" id="chkTransportationDetails" class="checkbox checkbox-inline" runat="server" /></legend>
                        <div id="dvTransportationDetails" style="display: none;">
                            <div class="row">
                                <div class="form-group form-inline col-lg-6 text-uppercase">
                                    <b>Transportation Type</b>
                                    <asp:DropDownList ID="ddlTransportationType" runat="server" CssClass="form-control form-inline"></asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-6">
                                    <b>Vehical number</b>
                                    <asp:TextBox ID="txtVehicalNumber" runat="server" CssClass="form-control form-inline" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-lg-6">
                                    <b>Date & Time of Supply</b>
                                    <asp:TextBox ID="txtDatenTimeofSupply" runat="server" CssClass="form-control form-inline" Text=""></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-6">
                                    <b>Place of Supply</b>
                                    <asp:TextBox ID="txtPLaceofSupply" runat="server" CssClass="form-control form-inline" Text=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="col-lg-4">
                    <fieldset>
                        <legend>Additional Charges &nbsp;<input type="checkbox" id="chkAdditionalCharges" class="checkbox checkbox-inline " runat="server" /></legend>
                        <div id="dvAdditionalCharges" style="display: none;">
                            <div class="row">
                                <div class="form-group form-inline col-lg-6 text-uppercase">
                                    <b>Frieght Charges</b>
                                    <asp:TextBox ID="txtFreightCharges" runat="server" CssClass="form-control form-inline" Text=""></asp:TextBox>
                                </div>
                                <div class="form-group col-lg-6">
                                    <b>Loading &amp; Packing Charges</b>
                                    <asp:TextBox ID="txtLOadingnPackingCharges" runat="server" CssClass="form-control form-inline" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-lg-6">
                                    <b>Insurance Charges</b>
                                    <asp:TextBox ID="txtInsuranceCharges" runat="server" CssClass="form-control form-inline" Text=""></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-6">
                                    <b>Other Charges</b>
                                    <asp:TextBox ID="txtOtherCharges" runat="server" CssClass="form-control form-inline" Text=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="col-lg-2">
                </div>
                <div class="col-lg-2">
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-2 control-label">Invoice Total</label>
                        <div class="col-lg-2"></div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:TextBox ID="txtInvoiceTotal" runat="server" class="form-control" placeholder="Invoice Total"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredrfvtxtInvoiceTotalFieldValidator1" runat="server" ErrorMessage="Invoice Total can not be empty or null" ControlToValidate="txtInvoiceTotal" InitialValue="" SetFocusOnError="true" ValidationGroup="CreateInvoice" Display="None"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputCollectedTotal" class="col-sm-2 control-label">Collected Total</label>
                        <div class="col-lg-2"></div>
                        <div class="col-sm-8">
                            <div class="form-group">
                              <%--  <asp:TextBox ID="txtTotalCollectedAmount" runat="server" class="form-control" placeholder="Collected Total"></asp:TextBox>--%>
                                <input type="text" id="txtTotalCollectedAmount" runat="server" class="form-control" placeholder="Collected Total" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Total collected amount can not be empty or null" ControlToValidate="txtTotalCollectedAmount" InitialValue="" SetFocusOnError="true" ValidationGroup="CreateInvoice" Display="None"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <asp:ValidationSummary ID="validationsummary3" runat="server" ShowMessageBox="true" DisplayMode="List" ValidationGroup="CreateInvoice" ShowSummary="false" />
            <div class="row">
                <div class="col-md-3">
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-info" Text="Cancel" OnClick="btnBack_Click" />
                </div>
                <div class="col-md-3"></div>
                <div class="col-md-3"></div>
                <div class="col-md-3 btn-group text-right">
                    <span class="pull-right">
                        <asp:Button ID="btnGenerateBill" runat="server" CssClass="btn btn-success " Text="Generate Bill" OnClick="btnGenerateBill_Click" ValidationGroup="CreateInvoice" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                    </span>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>


    <%-- <script src="Scripts/jquery-1.10.2.min.js"></script>--%>
    <script lang="javascript" type="text/javascript">
        $(document).ready(function () {

            $('#ContentPlaceHolder_txtQuantity').keypress(function (e) {
                var regex = new RegExp("^[0-9]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {

                    return true;
                }

                e.preventDefault();
                return false;
            });

            $('#ContentPlaceHolder_txtDiscount,#ContentPlaceHolder_txtFreightCharges,#ContentPlaceHolder_txtLOadingnPackingCharges,#ContentPlaceHolder_txtInsuranceCharges,#ContentPlaceHolder_txtOtherCharges').keypress(function (e) {
                var regex = new RegExp("^[0-9.]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {

                    return true;
                }

                e.preventDefault();
                return false;
            });

            $('#ContentPlaceHolder_txtFreightCharges,#ContentPlaceHolder_txtLOadingnPackingCharges,#ContentPlaceHolder_txtInsuranceCharges,#ContentPlaceHolder_txtOtherCharges').on('input propertychange paste', function () {
                var valItemTotal = $('#ContentPlaceHolder_txtInvoiceTotal').val();
                if (valItemTotal.trim().length == 0)
                { valItemTotal = 0; }
                //   alert('Item Total -' + valItemTotal)
                var FreightCharges = $('#ContentPlaceHolder_txtFreightCharges').val();
                if (FreightCharges.trim().length == 0)
                { FreightCharges = 0; }
                var LOadingnPackingCharges = $('#ContentPlaceHolder_txtLOadingnPackingCharges').val();
                if (LOadingnPackingCharges.trim().length == 0)
                { LOadingnPackingCharges = 0; }
                var InsuranceCharges = $('#ContentPlaceHolder_txtInsuranceCharges').val();
                if (InsuranceCharges.trim().length == 0)
                { InsuranceCharges = 0; }
                var OtherCharges = $('#ContentPlaceHolder_txtOtherCharges').val();
                if (OtherCharges.trim().length == 0)
                { OtherCharges = 0; }

                //  alert('FreightCharges - ' + FreightCharges);
                // alert('LOadingnPackingCharges - ' + LOadingnPackingCharges);
                //  alert('InsuranceCharges -' + InsuranceCharges);
                // alert('OtherCharges - ' + OtherCharges);
                var valInvoiceTotal = parseFloat(valItemTotal) + parseFloat(FreightCharges) + parseFloat(LOadingnPackingCharges) + parseFloat(InsuranceCharges) + parseFloat(OtherCharges);
                // alert('Invoice Total - '+ valInvoiceTotal)
                $('#ContentPlaceHolder_hdnTotalItemPrice').val(parseFloat(valInvoiceTotal));
                $('#ContentPlaceHolder_txtTotalCollectedAmount').val(parseFloat(valInvoiceTotal));


            });

            $('#ContentPlaceHolder_txtPLaceofSupply').keypress(function (e) {
                var regex = new RegExp("^[a-zA-Z()]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {

                    return true;
                }

                e.preventDefault();
                return false;
            });
            $('#ContentPlaceHolder_txtVehicalNumber').keypress(function (e) {
                var regex = new RegExp("^[a-zA-Z0-9.()\-]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {

                    return true;
                }

                e.preventDefault();
                return false;
            });

        });

        $(document).ready(function () {
            $('#ContentPlaceHolder_chkTransportationDetails').change(function () {

                if (this.checked) {

                    $("#dvTransportationDetails").show(1000);
                }
                else {

                    $("#dvTransportationDetails").hide(1000);
                }
            })
        });

        $(document).ready(function () {
            $('#ContentPlaceHolder_chkAdditionalCharges').change(function () {

                if (this.checked) {

                    $("#dvAdditionalCharges").fadeIn(2000);
                }
                else {

                    $("#dvAdditionalCharges").fadeOut(2000);
                }
            })
        });


        $(document).ready(function () {
            $(function () {
                $("#ContentPlaceHolder_ddlSearchBillingCustomer").customselect();
            });
        });
        $(document).ready(function () {
            $(function () {
                $("#ContentPlaceHolder_ddlSearchShippingCustomer").customselect();
            });
        });
        $(document).ready(function () {

            $('#ContentPlaceHolder_txtQuantity,#ContentPlaceHolder_txtDiscount').on('input propertychange paste', function () {


                var total = (parseFloat($('#ContentPlaceHolder_lblRate').html()).toFixed(2)) * (parseFloat($('#ContentPlaceHolder_txtQuantity').val()).toFixed(2));


                $("#ContentPlaceHolder_txtTotal").val(parseFloat(total).toFixed(2));

                $("#ContentPlaceHolder_txtTaxableValue").val(parseFloat(total).toFixed(2));

                $("#ContentPlaceHolder_txtSGSTValue").val((parseFloat($('#ContentPlaceHolder_txtTaxableValue').val()).toFixed(2) * parseFloat($('#ContentPlaceHolder_lblSGSTRate').html()).toFixed(2)) / 100);

                $("#ContentPlaceHolder_txtCGSTValue").val((parseFloat($('#ContentPlaceHolder_txtTaxableValue').val()).toFixed(2) * parseFloat($('#ContentPlaceHolder_lblCGSTRate').html()).toFixed(2)) / 100);


            });


        });

        function hidefewcontrol() {

            $('#ContentPlaceHolder_txtTotal').attr('readonly', 'readonly');
            $('#ContentPlaceHolder_txtTaxableValue').attr('readonly', 'readonly');
            $('#ContentPlaceHolder_txtSGSTValue').attr('readonly', 'readonly');
            $('#ContentPlaceHolder_txtCGSTValue').attr('readonly', 'readonly');
            $('#ContentPlaceHolder_txtTotalCollectedAmount').attr('readonly', 'readonly');

        }
        window.onload = hidefewcontrol;
    </script>
    <link href="Scripts/customSelect/jquery-customselect.css" rel="stylesheet" />
    <script src="Scripts/customSelect/jquery-customselect.js"></script>
    <input type="hidden" id="hdnGUID" runat="server" />
    <input type="hidden" id="hdnIsNewBillingCustomer" runat="server" value="Yes" />
    <input type="hidden" id="hdnIsNewShippingCustomer" runat="server" value="Yes" />
    <input type="hidden" id="hdnTotalItemPrice" runat="server" value="0" />
</asp:Content>



