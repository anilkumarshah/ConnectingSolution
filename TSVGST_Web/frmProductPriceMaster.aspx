<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmProductPriceMaster.aspx.cs" Inherits="frmProductPriceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
      <style>
        .Hide {
            display: none;
        }
    </style>
    <%--  <asp:UpdateProgress runat="server" ID="UpdateProgress1" DynamicLayout="false" AssociatedUpdatePanelID="UpdatePanel1">
         
        <ProgressTemplate>
        <center>
            <img id="Img1" runat="Server" src="~/images/wait.gif" style="height: 50px;"  alt="Loading Please Wait" />
            </center>
        </ProgressTemplate>
    </asp:UpdateProgress>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>

    <br />
    <asp:MultiView ID="mvProductPriceDetail" runat="server" >
        <asp:View ID="vwProductPriceList" runat="server" >
             <div class="col-lg-12 text-right">
        <%-- <asp:Button ID="btnNew" runat="server" Text="Add Product" 
                    CssClass="btn btn-success" onclick="btnNew_Click" />--%>
        <%--<input type="button" value="Add Product" id="btnModal" class="btn btn-success text-uppercase" />--%>
                 <asp:Button runat="server" id="btnAddProductPrice" Text="Add Product" CssClass="btn btn-success text-uppercase" OnClick="btnAddProductPrice_Click" />
    </div>
    <div class="form-group"></div>

    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvMasterGrid" AutoGenerateColumns="false" DataKeyNames="Id"
            AllowSorting="false" EmptyDataText="No Record Found." GridLines="Both" CssClass="table table-condensed table-hover table-bordered table-striped" PageSize="25"
            AllowPaging="true"
            OnPageIndexChanging="gvMasterGrid_PageIndexChanging">
            <Columns>

                <asp:BoundField DataField="FK_ProductMasterID" HeaderText="ID" ReadOnly="true" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                <asp:TemplateField HeaderText="Sr.No">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ReadOnly="true" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="true" />
                <asp:BoundField DataField="HSNCode" HeaderText="HSN Code" ReadOnly="true" />
                <asp:BoundField DataField="UOM" HeaderText="UOM" ReadOnly="true" />
                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="true" />
                <asp:BoundField DataField="SGSTPercentageRate" HeaderText="SGST Percentage Rate" ReadOnly="true" />
                <asp:BoundField DataField="CGSTPercentageRate" HeaderText="CGST Percentage Rate" ReadOnly="true" />


                <asp:BoundField DataField="IsActive" HeaderText="Active" ReadOnly="true" />
                <%-- 
                            <asp:BoundField DataField="Status" HeaderText="Active" ReadOnly="true" />--%>

                <%-- <asp:BoundField DataField="OurPrice" HeaderText="Price" ReadOnly="true" />
                                    <asp:BoundField DataField="Size" HeaderText="Size" ReadOnly="true" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" ReadOnly="true"/>
                                    <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="true" />--%>
                <%--     <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtnRemove" runat="server" ImageUrl="images/x_mark_red.png"
                                            AlternateText="Remove Product" Height="20" Width="20" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_EnableDisable" runat="server" CommandName="EnableDisable"
                            Text="Enable/Disable" BackColor="Transparent" CommandArgument="<%# Container.DataItemIndex %>"
                            BorderStyle="None" Style="cursor: pointer; color: Red; font-size: 12px;" OnClientClick="return confirm('Do you want to Enable / Disable this Product Price?')" OnClick="GridView_Button_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
              <%--  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_Edit" runat="server" CommandName="EditRow" Text="Edit"
                            CommandArgument="<%# Container.DataItemIndex %>" Style="cursor: pointer; color: Red; font-size: 12px;" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_Delete" runat="server" CommandName="Del" Text="Remove" BackColor="Transparent"
                            CommandArgument="<%# Container.DataItemIndex %>" BorderStyle="None" Style="cursor: pointer; color: Red; font-size: 12px;"
                            OnClientClick="return confirm('Do you want to delete?')" OnClick="GridView_Delete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        </asp:View>
        <asp:View ID="vwAddProductPrice" runat="server" >
             <asp:ValidationSummary ID="validationsummary2" runat="server" ShowMessageBox="true" DisplayMode="List" ValidationGroup="AddProductPrice" ShowSummary="false" />
<%--             <div id="modelAddCompanyProduct" class="modal fade" role="dialog" aria-hidden="false"> --%>
        <div>
        <div class="modal-dialog">
             <div class="alert alert-danger" id="dvError" runat="server" visible="false"></div>
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="myModalLabel">Add Product Price</h3>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="companyname" class="label">Company Name</label>
                        <asp:DropDownList ID="ddlCompanyName" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyName_SelectedIndexChanged" ></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="rfvddlCompanyName" runat="server" ControlToValidate="ddlCompanyName" ErrorMessage="Select Company" SetFocusOnError="true" InitialValue="0" ValidationGroup="AddProductPrice" Display="None"></asp:RequiredFieldValidator>
                       <%-- <input type="text" id="txtCompanyName" runat="server" class="form-control" />--%>
                    </div>
                    <div class="form-group">
                        <label for="companyname" class="label">Product Name</label>
                          <asp:DropDownList ID="ddlcompanyProduct" runat="server" class="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlcompanyProduct" runat="server" ControlToValidate="ddlcompanyProduct" ErrorMessage="Select Product" SetFocusOnError="true" InitialValue="0" ValidationGroup="AddProductPrice" Display="None"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label for="companyname" class="label">Product Price</label>
                        <input type="text" id="txtProductPrice" runat="server" class="form-control" />
                         <asp:RequiredFieldValidator ID="rfvtxtProductPrice" runat="server" ControlToValidate="txtProductPrice" ErrorMessage="Enter Price" SetFocusOnError="true" InitialValue="" ValidationGroup="AddProductPrice" Display="None"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="companyname" class="label">SGST Rate (in %)</label>
                        <input type="text" id="txtSGSTRate" runat="server" class="form-control" />
                        <asp:RequiredFieldValidator ID="rfvtxtSGSTRate" runat="server" ControlToValidate="txtSGSTRate" ErrorMessage="Enter SGST Rate" SetFocusOnError="true" InitialValue="" ValidationGroup="AddProductPrice" Display="None"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="companyname" class="label">CGST Rate (in %)</label>
                        <input type="text" id="txtCGSTRate" runat="server" class="form-control" />
                        <asp:RequiredFieldValidator ID="rfvtxtCGSTRate" runat="server" ControlToValidate="txtCGSTRate" ErrorMessage="Enter CGST Rate" SetFocusOnError="true" InitialValue="" ValidationGroup="AddProductPrice" Display="None"></asp:RequiredFieldValidator>
                    </div>
                    <%--  <div class="form-group">
                                <label for="companyname" class="label">Contact Person Email ID</label>
                                <input type="text" id="txtContactPersonEmailID" runat="server" class="form-control" />
                            </div>
                              <div class="form-group">
                                <label for="companyname" class="label">Company Website </label>
                                <input type="text" id="txtCompanyWebsite" runat="server" class="form-control" />
                            </div>--%>
                    <div class="form-group text-left">
                        <label for="Active" class="label">Active</label>
                        <input type="checkbox" id="chkIsActive" runat="server" class="checkbox" />
                    </div>
                </div>
                <div class="modal-footer">

                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="AddProductPrice" OnClick="btnSave_Click"/>
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                    <%--<button class="btn btn-primary" data-dismiss="modal" aria-hidden="true" id="btnCompanyProductSave">Save changes</button>
                    <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>--%>
                </div>
            </div>
        </div>
    </div>

        </asp:View>
    </asp:MultiView>
   

  
   
    <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
    <script type="text/javascript">
        $(function () {
            
            $('#modelAddCompanyProduct').on('shown.bs.modal', function () {
                $('#ddlCompanyName').focus();
            })

            $("#btnModal").click(function () {
                alert($('#ContentPlaceHolder_ddlCompanyName').val());
                if ($('#ContentPlaceHolder_ddlCompanyName').val() == 0)
                    {
                $(':input[type=text]', '#modelAddCompanyProduct').val("");
                $('#ContentPlaceHolder_ddlCompanyName').val("0");
                $('#ContentPlaceHolder_chkIsActive').prop('checked', 'true');
            }
                $('#ContentPlaceHolder_ddlCompanyName').focus();
                $('#modelAddCompanyProduct').modal({ backdrop: 'static', keyboard: false }, 'show');

            });
            $('#ContentPlaceHolder_txtProductPrice,#ContentPlaceHolder_txtSGSTRate,#ContentPlaceHolder_txtCGSTRate').keypress(function (e) {
              //  alert();
                
                var regex = new RegExp("^[0-9.]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {

                    return true;
                }

                e.preventDefault();
                return false;
            });
            $('#btnCompanyProductSave').click(function () {``

                alert('Inside Save');
                               
                var CompanyID = $('#ContentPlaceHolder_ddlCompanyName').val();
                var ProductName = $('#ContentPlaceHolder_txtProductName').val();
                var HSNCode = $('#ContentPlaceHolder_txtHSNCode').val();
                var UOM = $('#ContentPlaceHolder_txtUOM').val();
                if (CompanyID <= 0)
                {
                    alert('Select Company');
                    $('#ContentPlaceHolder_ddlCompanyName').focus();
                    return false;
                }
                else if (ProductName.trim() =="") {
                    alert('Enter Product Name');
                    $('#ContentPlaceHolder_txtProductName').focus();
                    return false;
                }
                else if (HSNCode.trim() == "") {
                    alert('Enter HSN Code');
                    $('#ContentPlaceHolder_txtHSNCode').focus();
                    return false;
                }
                else if (UOM.trim() == "") {
                    alert('Enter UOM');
                    $('#ContentPlaceHolder_txtUOM').focus();
                    return false;
                }
                var status;
                if ($('#ContentPlaceHolder_chkIsActive').prop('checked') == true) {
                    status = true;
                }
                else {
                    status = false;
                }

                $.ajax({

                    type: "POST",
                    url: "frmProductMaster.aspx/AddProduct",
                    contentType: "application/json; charset=utf-8",
                    // data: '{}',
                    data: '{"CompanyID":"' + CompanyID + '","ProductName":"' + ProductName + '","HSNCode":"' + HSNCode + '","UOM":"' + UOM + '","Status":"' + status + '"}',
                    dataType: "json",
                    error: function (da) {
                        alert(da.d);
                        alert('Exception');
                    },
                    success: function (da) {
                        var message = da.d;
                        alert('Response - ' + message);
                        if (message.match('^failed')) {
                            alert('Inside Failed');
                            $('#ContentPlaceHolder_ddlCompanyName').focus();
                            $('#btnCompanyProductSave').modal({ backdrop: 'static', keyboard: false }, 'show');
                             return false;
                        }
                        else {
                            alert(da.d);
                            $(':input[type=text]', '#modelAddCompanyProduct').val("");
                           
                            $('#ContentPlaceHolder_ddlCompanyName').val("0");
                            alert('Success');
                            window.location.href = window.location.href;
                        }
                    }
                });

            });

        });

        //function Success(result) {
        //    $("#ParcelShippingDate").html(result.d);
        //}
        //function Failed(result) {
        //    alert(result.status + " " + result.statusText);
        //}

        function Companycheckboxenabled() {
            $('#ContentPlaceHolder_chkIsActive').attr('checked', 'true');
        }
        window.onload = Companycheckboxenabled;
    </script>
   <%-- <link href="Content/bootstrap.min.css" rel="stylesheet" />--%>
</asp:Content>

