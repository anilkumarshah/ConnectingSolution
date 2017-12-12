<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmDashboard.aspx.cs" Inherits="frmDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <div class="row">
        <div class="col-lg-6">
<div class="form-group">
    <div id="dvTop10Customer">
       <%-- <div class="input-group date">
  <input type="text" class="form-control"/><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
</div>--%>
         <div class="panel panel-default magic-element isotope-item" style="position: absolute; left: 0px; top: 0px; transform: translate3d(0px, 0px, 0px);">
                                    <div class="panel-body-heading bg-primary">
                                        <h3 class="pb-title">Line Chart</h3>
                                    </div>
                                   
                                </div><!-- /panel -->
    </div>
</div>
        </div>
        <div class="col-lg-6">
            <div class="form-group">
    <div id="dvTop10SellingProduct">
        <img src="images/pleasewait.gif" class="img-responsive"/>
    </div>
               
</div>
        </div>
    </div>
    <script type="text/javascript">
        $('#sandbox-container .input-group.date').datepicker({
        });
    </script>
    <link href="Scripts/Datetime/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="Scripts/Datetime/bootstrap-datepicker.min.js"></script>
    <script src="Scripts/Datetime/bootstrap-datepicker.uk.min.js"></script>
</asp:Content>

