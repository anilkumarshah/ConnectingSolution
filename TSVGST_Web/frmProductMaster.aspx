<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmProductMaster.aspx.cs" Inherits="frmProductMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
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
    <div class="col-lg-12 text-right">
        <%-- <asp:Button ID="btnNew" runat="server" Text="Add Product" 
                    CssClass="btn btn-success" onclick="btnNew_Click" />--%>
        <input type="button" value="Add Product" id="btnModal" class="btn btn-success text-uppercase" />
    </div>
    <div class="form-group"></div>

    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvMasterGrid" AutoGenerateColumns="false" DataKeyNames="Id"
            AllowSorting="false" EmptyDataText="No Record Found." GridLines="Both" CssClass="table table-condensed table-hover table-bordered table-striped" PageSize="25"
            AllowPaging="true"
            OnPageIndexChanging="gvMasterGrid_PageIndexChanging">
            <Columns>

                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                <asp:TemplateField HeaderText="Sr.No">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ReadOnly="true" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="true" />
                <asp:BoundField DataField="HSNCode" HeaderText="HSN Code" ReadOnly="true" />
                <asp:BoundField DataField="UOM" HeaderText="UOM" ReadOnly="true" />

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
                            BorderStyle="None" Style="cursor: pointer; color: Red; font-size: 12px;" OnClientClick="return confirm('Do you want to Enable / Disable this Company?')" OnClick="GridView_Button_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_Edit" runat="server" CommandName="EditRow" Text="Edit"
                            CommandArgument="<%# Container.DataItemIndex %>" Style="cursor: pointer; color: Red; font-size: 12px;" />
                    </ItemTemplate>
                </asp:TemplateField>
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

    <div id="modelAddCompanyProduct" class="modal fade" role="dialog" aria-hidden="false">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="myModalLabel">Add Company Product</h3>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="companyname" class="label">Company Name</label>
                        <asp:DropDownList ID="ddlCompanyName" runat="server" class="form-control"></asp:DropDownList>
                        
                       <%-- <input type="text" id="txtCompanyName" runat="server" class="form-control" />--%>
                    </div>
                    <div class="form-group">
                        <label for="companyname" class="label">Product Name</label>
                        <input type="text" id="txtProductName" runat="server" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="companyname" class="label">HSN Code</label>
                        <input type="text" id="txtHSNCode" runat="server" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="companyname" class="label">Unit of Measure (UOM)</label>
                        <input type="text" id="txtUOM" runat="server" class="form-control" />
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

                    <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true" id="btnCompanyProductSave">Save changes</button>
                    <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                </div>
            </div>
        </div>
    </div>

   
    <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
    <script type="text/javascript">
        $(function () {
            
            $('#modelAddCompanyProduct').on('shown.bs.modal', function () {
                $('#ddlCompanyName').focus();
            })

            $("#btnModal").click(function () {

                $(':input[type=text]', '#modelAddCompanyProduct').val("");
                $('#ContentPlaceHolder_ddlCompanyName').val("0");
                $('#ContentPlaceHolder_chkIsActive').prop('checked', 'true');
                $('#ContentPlaceHolder_ddlCompanyName').focus();
                $('#ContentPlaceHolder_txtUOM').val("BAG");
                $('#modelAddCompanyProduct').modal({ backdrop: 'static', keyboard: false }, 'show');

            });

            $('#btnCompanyProductSave').click(function () {``

              //  alert('Inside Save');
                               
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
                     //   alert('Exception');
                    },
                    success: function (da) {
                        var message = da.d;
                       alert(message);
                        if (message.match('^failed')) {
                          //  alert('Inside Failed');
                            $('#ContentPlaceHolder_ddlCompanyName').focus();
                          //  alert('hi');
                            $('#modelAddCompanyProduct').modal({ backdrop: 'static', keyboard: false }, 'show');
                             return false;
                        }
                        else {
                          //  alert(da.d);
                            $(':input[type=text]', '#modelAddCompanyProduct').val("");
                           
                            $('#ContentPlaceHolder_ddlCompanyName').val("0");
                         //   alert('Success');
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
           
            $('#ContentPlaceHolder_txtUOM').attr('readonly', 'readonly');
           
        }
        window.onload = Companycheckboxenabled;
    </script>
<%--    <link href="Content/bootstrap.min.css" rel="stylesheet" />--%>
</asp:Content>

