<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmCompanyMaster.aspx.cs" Inherits="frmCompanyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style>
        .Hide {
            display: none;
        }
    </style>
   <%-- <asp:UpdateProgress runat="server" ID="UpdateProgress1" DynamicLayout="false" AssociatedUpdatePanelID="UpdatePanel1">

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
              <%--  <asp:Button ID="btnNew" runat="server" Text="Add Company" 
                    CssClass="btn btn-success"  />--%>
                <input type="button" value="Add Company" id="btnModal" class="btn btn-success text-uppercase" />
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
                        <asp:BoundField DataField="Name" HeaderText="Company Name" ReadOnly="true" />
                        <asp:BoundField DataField="CompanyShortKey" HeaderText="Company Short Name" ReadOnly="true" />
                        <asp:BoundField DataField="ContactPersonName" HeaderText="Contact Person" ReadOnly="true" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" ReadOnly="true" />
                        <asp:BoundField DataField="BusinessWebsite" HeaderText="Website" ReadOnly="true" />

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
                                    CommandArgument="<%# Container.DataItemIndex %>" Style="cursor: pointer; color: Red; font-size: 12px;" OnClientClick="javascript:AddCompany();" />
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



            <!-- Modal -->
            <div id="modelAddCompany" class="modal fade" role="dialog" aria-hidden="false">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 id="myModalLabel">Add Company</h3>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label for="companyname" class="label">Company Name</label>
                                <input type="text" id="txtCompanyName" runat="server" class="form-control" />
                            </div>
                              <div class="form-group">
                                <label for="companyname" class="label">Company Short Name</label>
                                <input type="text" id="txtCompanyShortName" runat="server" class="form-control" />
                            </div>
                              <div class="form-group">
                                <label for="companyname" class="label">Contact Person Name</label>
                                <input type="text" id="txtContactPersonName" runat="server" class="form-control" />
                            </div>
                              <div class="form-group">
                                <label for="companyname" class="label">Contact Person Mobile No</label>
                                <input type="text" id="txtCompanyMobileNo" runat="server" class="form-control" />
                            </div>
                             <div class="form-group">
                                <label for="companyname" class="label">Contact Person Email ID</label>
                                <input type="text" id="txtContactPersonEmailID" runat="server" class="form-control" />
                            </div>
                              <div class="form-group">
                                <label for="companyname" class="label">Company Website </label>
                                <input type="text" id="txtCompanyWebsite" runat="server" class="form-control" />
                            </div>
                            <div class="form-group text-left">
                                <label for="Active" class="label">Active</label>
                                <input type="checkbox" id="chkIsActive" runat="server" class="checkbox"  />
                            </div>
                        </div>
                        <div class="modal-footer">
                           
                            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true" id="btnCompanySave" >Save changes</button>
                            <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

   <script type="text/javascript">


    $(function () {
        //$("#modelAddCompany").dialog({
        //    modal: true,
        //    autoOpen: false,
        //    title: "jQuery Dialog",
        //    width: 300,
        //    height: 150
        //});
        
        //$('#modelAddCompany').on('hidden.bs.modal', function (e) {
        //    $(this)
        //      .find("input,textarea,select")
        //         .val('')
        //         .end()
        //      .find("input[type=checkbox]")
        //         .prop("checked", "true")
        //         .end();
        //})
        
        //$('#modelAddCompany').on('shown.bs.modal', function () {
        //    $('#ContentPlaceHolder_txtCompanyName').focus();
        //})

        $("#btnModal").click(function () {
                 
            $(':input', '#modelAddCompany').val("");
            $('#ContentPlaceHolder_chkIsActive').prop('checked', 'true');
            $('#ContentPlaceHolder_txtCompanyName').focus();
            $('#modelAddCompany').modal({ backdrop: 'static', keyboard: false }, 'show');
           
        });

        $('#btnCompanySave').click(function () {

           if ($('#ContentPlaceHolder_txtCompanyName').val() == '')
            {
                alert('Enter Company Name');
                $('#ContentPlaceHolder_txtCompanyName').focus();
                return false;
           }
           var CompanyName = $("#ContentPlaceHolder_txtCompanyName").val();
           var CompanyShortName = $("#ContentPlaceHolder_txtCompanyShortName").val();
           var CompanyContactPerson = $("#ContentPlaceHolder_txtContactPersonName").val();
           var CompanyMobileNo = $("#ContentPlaceHolder_txtCompanyMobileNo").val();
           var CompanyWebsiteURL = $("#ContentPlaceHolder_txtCompanyWebsite").val();
           var ContactPersonEmailID = $("#ContentPlaceHolder_txtContactPersonEmailID").val();
           var status;
           if ($('#ContentPlaceHolder_chkIsActive').prop('checked') == true) {
               status = true;
           }
           else {
               status = false;
           }
          
         //  alert('"CompanyName":"' + CompanyName + '", "CompanyShortName":"' + CompanyShortName + '", "CompanyContactPersonName":"' + CompanyContactPerson + '","CompanyContactPersonMobileNo":"' + CompanyMobileNo + '","CompanyWebsiteURL":"' + CompanyWebsiteURL + '", "Status":"' + status + '"');
           $.ajax({

               type: "POST",
               url: "frmCompanyMaster.aspx/AddCompany",
               contentType: "application/json; charset=utf-8",
               data: '{"CompanyName":"' + CompanyName + '", "CompanyShortName":"' + CompanyShortName + '", "CompanyContactPersonName":"' + CompanyContactPerson + '","CompanyContactPersonMobileNo":"' + CompanyMobileNo + '","ContactPersonEmailID":"' + ContactPersonEmailID + '","CompanyWebsiteURL":"' + CompanyWebsiteURL + '", "Status":"' + status + '"}',
             //  data: '{"CompanyName":"CompanyName","CompanyShortName":"CompanyShortName","CompanyContactPersonName":"CompanyContactPerson","CompanyContactPersonMobileNo":"CompanyMobileNo","CompanyWebsiteURL":"CompanyWebsiteURL","Status":"' + status + '"}',
               dataType: "json",
               error: function (result) {
                   alert(result.d);
                //   alert('Exception');
               },
               success: function (result) {
                   var message = result.d;
                 //  alert('Response - ' + message);
                   if (message.match('^failed'))
                   {
                     //  alert('Inside Failed');
                       $('#ContentPlaceHolder_txtCompanyName').focus();
                       $('#modelAddCompany').modal({ backdrop: 'static', keyboard: false }, 'show');
                      

                       return false;
                   }
                   else
                   {
                       alert(result.d);
                       $(':input', '#modelAddCompany').val("");
                     //  alert('Success');
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

    function Companycheckboxenabled()
    {
        $('#ContentPlaceHolder_chkIsActive').attr('checked', 'true');
    }
    window.onload = Companycheckboxenabled;
    
</script>
</asp:Content>

