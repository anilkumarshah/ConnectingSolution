<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.js" charset="UTF-8"></script>
 <style type="text/css">
     .glyphicon-refresh-animate {
    -animation: spin .7s infinite linear;
    -webkit-animation: spin2 .7s infinite linear;
}

@-webkit-keyframes spin2 {
    from { -webkit-transform: rotate(0deg);}
    to { -webkit-transform: rotate(360deg);}
}

@keyframes spin {
    from { transform: scale(1) rotate(0deg);}
    to { transform: scale(1) rotate(360deg);}
}
 </style>
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

       

    </script>
    <script type="text/javascript">

        $('.form_date').datetimepicker({
            language: 'en',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });

    </script>
    <script type="text/javascript" lang="en-us">
        $('.btn').on('click', function () {
            var $this = $(this);
            $this.button('loading');
            setTimeout(function () {
                $this.button('reset');
            }, 8000);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" role="form">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="" data-target="#myNavbar">
                        <span class="icon-bar">a</span>
                        <span class="icon-bar">s</span>
                        <span class="icon-bar">d</span>
                    </button>
                    <a class="navbar-brand" href="#">DMT Express </a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="#">Home</a></li>
                        <li class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">UDIO DMT <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="QueryCustomer.html">Query Customer</a></li>
                                <li><a href="UDIODMTTxnHistory.html">DMT Transaction</a></li>

                            </ul>
                        </li>
                        <li class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">UDIO Wallet <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="CardQueryCustomer.html">Query Customer</a></li>
                                <li><a href="UDIOCardTxnHistory.html">Card Transaction</a></li>

                            </ul>
                        </li>
                      
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="#"><span class="glyphicon glyphicon-user"></span>Welcome  <span class="badge">Agent</span></a> </li>
                        <li><a href="#"><span class="glyphicon glyphicon-log-out"></span>Log out</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container form-group">
 


            <div class="panel panel-default">
                <div class="panel-heading text-uppercase">Query Customer</div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="usr">Customer Mobile No:</label>
                        <input type="text" class="form-control" id="usr" placeholder="Enter Mobile No" data-toggle="tooltip" title="Enter Mobile No" data-placement="top" maxlength="10" required="required" />
                    </div>
                    <div class="btn-group">
                        <input type="button" id="btnSubmitExist" name="btnSubmit" value="Customer Exist" class="btn btn-success" />
                        &nbsp;&nbsp;&nbsp;
                         <input type="button" id="btnSubmit" name="btnSubmit" value="Customer Does Not Exist" class="btn btn-danger" />
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading text-uppercase">Customer Beneficiary List</div>
                <div class="panel-body">
                    <div class="text-right">


                        <input type="button" class="btn btn-primary " value="Add Beneficiary" id="btnAddbene1" />
                    </div>
                    <div class="form-group text-center">
                        <div class="row">
                            <div class="col-xs-3">
                                <label for="usr">Mobile No:</label>

                                <label class="text-info">
                                    XXXXXXXXXX
                                </label>
                            </div>
                            <div class="col-xs-3">
                                <label for="usr">Name:</label>

                                <label class="text-info">
                                    Anil Shah
                                </label>
                            </div>
                            <div class="col-xs-3">
                                <label for="usr">Available Limit:</label>
                                <label class="text-info">
                                    14000
                                </label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <label for="usr">Account No:</label>

                                <label class="text-info">
                                    XXXXXXXXXX
                                </label>
                            </div>
                            <div class="col-xs-3">
                                <label for="usr">Bank Name:</label>

                                <label class="text-info">
                                    XXXXXXXXXXX
                                </label>
                            </div>
                            <div class="col-xs-3">
                                <label for="usr">IFSC Code:</label>
                                <label class="text-info">
                                    IFSC0000000
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="text-center">
                                    <th>Sr. No</th>
                                    <th>Name</th>
                                    <th>Bank</th>
                                    <th>Account No</th>
                                    <th>IFSC Code</th>
                                    <th>Status</th>
                                    <th>Amount</th>
                                    <th>NEFT</th>
                                    <th>IMPS</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Anil Shah</td>
                                    <td>ICICI</td>
                                    <td>09879765436</td>
                                    <td>ICIC0001230</td>
                                    <td>Active</td>
                                    <td>
                                        <input type="text" class="form-control" placeholder="Enter Amount" /></td>
                                    <td>
                                        <input type="button" class="btn btn-primary" value="NEFT" data-toggle="modal" data-target="#DMTTxnStatus" /></td>
                                    <td>
                                        <input type="button" class="btn btn-primary" value="IMPS" data-toggle="modal" data-target="#DMTTxnStatus" /></td>
                                    <td></td>
                                    <td><span data-toggle="modal" data-target="#DeleteBene"><a href="#" class="form-group" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-trash"></span></a></span></td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>Amit Sanaye</td>
                                    <td>Bank of India</td>
                                    <td>76543098786</td>
                                    <td>BKID0000001</td>
                                    <td>Active</td>
                                    <td>
                                        <input type="text" class="form-control form-group-sm" placeholder="Enter Amount" /></td>
                                    <td>
                                        <input type="button" class="btn btn-primary" value="NEFT" data-toggle="modal" data-target="#DMTTxnStatus" /></td>
                                    <td>
                                        <input type="button" class="btn btn-primary " value="IMPS" data-toggle="modal" data-target="#DMTTxnStatus" /></td>
                                    <td></td>
                                    <td><span data-toggle="modal" data-target="#DeleteBene"><a href="#" class="form-group" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-trash"></span></a></span></td>
                                </tr>
                                <tr class="danger">
                                    <td>3</td>
                                    <td>Raj Gupta</td>
                                    <td>Bank of India</td>
                                    <td>1239876757</td>
                                    <td>BKID0000001</td>
                                    <td>Pending</td>
                                    <td>
                                        <input type="text" class="form-control" placeholder="Enter Amount" disabled /></td>
                                    <td>
                                        <input type="button" class="btn btn-primary" value="NEFT" disabled /></td>
                                    <td>
                                        <input type="button" class="btn btn-primary" value="IMPS" disabled /></td>
                                    <td class="disabled"><span data-toggle="modal" data-target="#ActivateBene"><a href="#" class="form-group" data-toggle="tooltip" title="Activate" data-placement="top"><span class="glyphicon glyphicon-ok"></span></a></span></td>
                                    <td><span data-toggle="modal" data-target="#DeleteBene"><a href="#" class="form-group" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-trash"></span></a></span></td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="form-group">
                            <ul class="pagination pagination-lg">
                                <li class="active"><a href="#">1</a></li>
                                <li class="disabled"><a href="#">2</a></li>
                                <li class="disabled"><a href="#">3</a></li>
                                <li class="disabled"><a href="#">4</a></li>
                                <li class="disabled"><a href="#">5</a></li>
                            </ul>
                        </div>

                        <div class="modal fade" id="DeleteBene" role="dialog">
                            <div class="modal-dialog">

                               
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">DELETE BENEFICIARY</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="usr">OTP:</label>
                                            <input type="text" class="form-control" id="delotp" placeholder="OTP" data-toggle="tooltip" title="OTP" data-placement="top" maxlength="10" required="required" />
                                        </div>
                                        <div class="btn-group">
                                            <input type="button" id="btnSubmitDelOTP" name="btnSubmit" value="Delete" class="btn btn-success" />
                                            &nbsp;&nbsp;&nbsp;
                                        <input type="button" id="btnSubmitResendDelOTP" name="btnSubmit" value="Resend OTP" class="btn btn-danger" />
                                        </div>
                                    </div>

                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="modal fade" id="ActivateBene" role="dialog">
                            <div class="modal-dialog">

                              
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">ACTIVATE BENEFICIARY</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="usr">OTP:</label>
                                            <input type="text" class="form-control" id="Activateotp" placeholder="OTP" data-toggle="tooltip" title="OTP" data-placement="top" maxlength="10" required="required" data-bind="value: replyNumber" />
                                        </div>
                                        <div class="btn-group">
                                            <input type="button" id="btnSubmitActivateOTP" name="btnSubmit" value="Activate" class="btn btn-success" />

                                            <input type="button" id="btnSubmitResendActivateOTP" name="btnSubmit" value="Resend OTP" class="btn btn-danger" />
                                        </div>

                                    </div>

                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal fade" id="DMTTxnStatus" role="dialog">
                    <div class="modal-dialog">

                       
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title text-uppercase">UDIO DMT Transaction Status</h4>
                            </div>
                            <div class="modal-body info">
                                <p class="">Transaction Status = <span class="info">InProcess / Processed / On Hold </span>/ <span class="danger">Incomplete</span> / <span class="success">Success</span> / <span class="danger">Failed</span> </p>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><b>ADD CUSTOMER</b></div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="usr">Title</label>
                        <select class="form-control" id="sel1">
                            <option>MR</option>
                            <option>MRS</option>
                            <option>MS</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="usr">Customer Mobile No:</label>
                        <input type="text" class="form-control" id="Mobile" placeholder="Mobile No" data-toggle="tooltip" title="Enter Mobile No" data-placement="top" maxlength="10" required="required" />
                    </div>
                    <div class="form-group">
                        <label for="usr">First Name:</label>
                        <input type="text" class="form-control" id="fname" placeholder="First Name" data-toggle="tooltip" title="First Name" data-placement="top" maxlength="25" required="required" />
                    </div>
                    <div class="form-group">
                        <label for="usr">Middle Name:</label>
                        <input type="text" class="form-control" id="mname" placeholder="Middle Name" data-toggle="tooltip" title="Middle Name" data-placement="top" maxlength="25" required="required" />
                    </div>
                    <div class="form-group">
                        <label for="usr">Last Name:</label>
                        <input type="text" class="form-control" id="lname" placeholder="Last Name" data-toggle="tooltip" title="Last Name" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">Gender:</label>
                        <div class="input-group">
                            <label class="radio-inline">
                                <input type="radio" name="optradio" />Male
                            </label>
                            <label class="radio-inline">
                                <input type="radio" name="optradio" />Female
                            </label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="dtp_input2">Date Picking</label>
                        <div class="form-group">
                            <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                <input class="form-control" size="16" type="text" value="" readonly />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                            <input type="hidden" id="dtp_input2" value="" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="usr">Email:</label>
                        <input type="text" class="form-control" id="email" placeholder="Email" data-toggle="tooltip" title="Email" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">Mother Maiden Name:</label>
                        <input type="text" class="form-control" id="MotherMaidenName" placeholder="Mother Maiden Name" data-toggle="tooltip" title="Mother Maiden Name" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">Landline:</label>
                        <input type="text" class="form-control" id="Landline" placeholder="Landline" data-toggle="tooltip" title="Landline" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">Address Line 1:</label>
                        <input type="text" class="form-control" id="AddressLine1" placeholder="Address Line 1" data-toggle="tooltip" title="Address Line 1" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">Address Line 2:</label>
                        <input type="text" class="form-control" id="AddressLine2" placeholder="Address Line 2" data-toggle="tooltip" title="Address Line 2" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">City:</label>
                        <input type="text" class="form-control" id="City" placeholder="City" data-toggle="tooltip" title="City" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">State:</label>
                        <select class="form-control" id="state">
                            <option>Andhra Pradesh</option>
                            <option>Arunachal Pradesh</option>
                            <option>Assam</option>
                            <option>Bihar</option>
                            <option>Chhattisgarh</option>
                            <option>Goa</option>
                            <option>Gujarat</option>
                            <option>Haryana</option>
                            <option>Karnataka</option>
                            <option>Kerala</option>
                            <option>Madhya Pradesh</option>
                            <option>Maharashtra</option>
                            <option>Rajasthan</option>
                            <option>Tamil Nadu</option>
                        </select>
                    </div>

                    <div class="form-group">
                        <label for="usr">Country:</label>
                        <input type="text" class="form-control" id="Country" placeholder="Country" data-toggle="tooltip" title="Country" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="form-group">
                        <label for="usr">Pincode:</label>
                        <input type="text" class="form-control" id="Pincode" placeholder="Pincode" data-toggle="tooltip" title="Pincode" data-placement="top" maxlength="25" required="required" />
                    </div>

                    <div class="btn-group">
                        <input type="button" id="btnSubmitExist1" name="btnSubmit" value="Add Customer" class="btn btn-success" />
                        &nbsp;&nbsp;&nbsp;
                         <input type="button" id="btnSubmit1" name="btnSubmit" value="Reset" class="btn btn-info" />
                    </div>

                </div>

            </div>

            <div class="panel panel-default">
                <div class="panel-heading text-uppercase">Customer Beneficiary List</div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="text-right form-inline">
                            <input type="button" class="btn btn-primary " value="Add Beneficiary" id="btnAddbene" />
                        </div>
                        <div class="form-group text-center">
                            <div class="row">
                                <div class="col-xs-3">
                                    <label for="usr">Mobile No:</label>

                                    <label class="text-info">
                                        XXXXXXXXXX
                                    </label>
                                </div>
                                <div class="col-xs-3">
                                    <label for="usr">Name:</label>

                                    <label class="text-info">
                                        Anil Shah
                                    </label>
                                </div>
                                <div class="col-xs-3">
                                    <label for="usr">Available Limit:</label>
                                    <label class="text-info">
                                        25000
                                    </label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-3">
                                    <label for="usr">Account No:</label>

                                    <label class="text-info">
                                        XXXXXXXXXX
                                    </label>
                                </div>
                                <div class="col-xs-3">
                                    <label for="usr">Bank Name:</label>

                                    <label class="text-info">
                                        XXXXXXXXXXX
                                    </label>
                                </div>
                                <div class="col-xs-3">
                                    <label for="usr">IFSC Code:</label>
                                    <label class="text-info">
                                        IFSC0000000
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="alert alert-success">
                        Kindly add beneficiary.
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading"><b>ADD BENEFICIARY</b></div>
                <div class="panel-body">

                    <div class="form-group">
                        <label for="usr">Beneficiary Name:</label>
                        <input type="text" class="form-control" id="benename" placeholder="Enter Beneficiary Name" data-toggle="tooltip" title="Beneficiary Name" data-placement="top" maxlength="10" required="required" />
                    </div>
                    <div class="form-group">
                        <label for="usr">Beneficiary Account No</label>
                        <input type="text" class="form-control" id="beneaccount" placeholder="Enter Beneficiary Account No" data-toggle="tooltip" title="Beneficiary Account No" data-placement="top" maxlength="25" required="required" />
                    </div>
                    <div class="form-group">
                        <label for="usr">Beneficiary Account Bank IFSC Code</label>
                        <input type="text" class="form-control" id="benebankifsc" placeholder="Enter Beneficiary Account Bank IFSC Code" data-toggle="tooltip" title="Beneficiary Account Bank IFSC Code" data-placement="top" maxlength="25" required="required" />
                    </div>
                    <div class="form-group">
                        <label for="usr">Beneficiary Mobile No:</label>
                        <input type="text" class="form-control" id="beneMobileNo" placeholder="Enter Beneficiary Mobile No" data-toggle="tooltip" title="Beneficiary Mobile No" data-placement="top" maxlength="25" required="required" />
                    </div>
                    <div class="btn-group">
                        <input type="button" id="btnSubmitExist2" name="btnSubmit" value="Add Beneficiary" class="btn btn-success" data-toggle="modal" data-target="#RealActivateBene" />
                        <button type="button" class="btn btn-primary" id="load" data-loading-text="<i class='fa fa-spinner fa-spin '></i> Processing Order">Submit Order</button>
                        <input type="button" id="btnValidateBene" name="btnSubmitValidate" value="Validate Beneficiary" class="btn btn-primary" data-toggle="modal" data-target="#ValidateBeneficiary" />
                        &nbsp;&nbsp;&nbsp;
                         <input type="button" id="btnSubmit2" name="btnSubmit" value="Reset" class="btn btn-info" />
                    </div>
                </div>

                <div class="modal fade" id="RealActivateBene" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">ACTIVATE BENEFICIARY</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="usr">OTP:</label>
                                    <input type="text" class="form-control" id="RealActivateotp" placeholder="OTP" data-toggle="tooltip" title="OTP" data-placement="top" maxlength="10" required="required" data-bind="value: replyNumber" />
                                </div>
                                <div class="btn-group">
                                    <input type="button" id="btnSubmitRealActivateOTP" name="btnSubmit" value="Activate" class="btn btn-success" />

                                    <input type="button" id="btnSubmitRealResendActivateOTP" name="btnSubmit" value="Resend OTP" class="btn btn-danger" />
                                </div>

                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="modal fade" id="ValidateBeneficiary" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title text-uppercase">Beneficiary Account Validation</h4>
                            </div>
                            <div class="modal-body danger">
                                <div class="form-group info">Status - Success / Failed / Pending / On Hold </div>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            
            <div class="panel panel-default">
                <div class="panel-heading">UDIO DMT TRANSACTION HISTORY</div>
                <div class="panel-body">
                    <div class="form-inline text-center">
                        <label class="form-group">From Date</label>
                        &nbsp;<input type="text" class="form-control" placeholder="dd/mm/yyyy" data-toggle="tooltip" title="From Date" data-placement="top" />
                        &nbsp;
                        <label class="form-group">To Date</label>&nbsp;<input type="text" class="form-control" placeholder="dd/mm/yyyy" data-toggle="tooltip" title="To Date" data-placement="top" />
                        &nbsp;  &nbsp;
                   <input type="button" class="btn btn-primary text-uppercase" value="view" id="view" />
                    </div>

                    <br />
                    <div class="table-responsive small">
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="text-center">
                                    <th>Sr. No</th>

                                    <th>Name</th>
                                    <th>Mobile No</th>
                                    <th>Bank</th>
                                    <th>Account No</th>
                                    <th>IFSC Code</th>
                                    <th>Transaction Date</th>
                                    <th>Amount</th>

                                    <th>Partner Status</th>
                                    <th>UDIO Status</th>

                                    <th>Re-Query</th>
                                    <th>Refund</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Anil Shah</td>
                                    <td>9898987898</td>
                                    <td>ICICI</td>
                                    <td>09879765436</td>
                                    <td>ICIC0001230</td>

                                    <td>05-Mar-2017
                                    </td>
                                    <td>110
                                    </td>

                                    <td>Success
                                    </td>
                                    <td>Success</td>
                                    <td><span data-toggle="modal" data-target="#ActivateBene"><a href="#" class="btn disabled" data-toggle="tooltip" title="Activate" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>
                                    <td><a href="#" class="btn disabled" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-transfer"></span></a></td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>Amit Sanaye</td>
                                    <td>9898871000</td>
                                    <td>Bank of India</td>
                                    <td>76543098786</td>
                                    <td>BKID0000001</td>

                                    <td>15-Mar-2017
                                    </td>
                                    <td>4000
                                    </td>

                                    <td>Pending
                                    </td>
                                    <td>InProcess / Processed / On Hold</td>
                                    <td><span data-toggle="modal" data-target="#ReQuery"><a href="#" class="btn" data-toggle="tooltip" title="Txn Re-Query" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>
                                    <td><a href="#" class="btn disabled" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-transfer"></span></a></td>
                                </tr>
                                <tr class="danger">
                                    <td>3</td>
                                    <td>Raj Gupta</td>
                                    <td>9800009898</td>
                                    <td>Bank of India</td>
                                    <td>1239876757</td>
                                    <td>BKID0000001</td>

                                    <td>25-Mar-2017
                                    </td>
                                    <td>1100
                                    </td>
                                    <td>FAIL</td>
                                    <td>FAILED
                                    </td>
                                    <td><span data-toggle="modal" data-target="#ActivateBene"><a href="#" class="btn disabled" data-toggle="tooltip" title="Requery" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>
                                    <td><span data-toggle="modal" data-target="#RefundOTP"><a href="#" class="btn" data-toggle="tooltip" title="Initiate Refund" data-placement="top"><span class="glyphicon glyphicon-transfer"></span></a></span></td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>Raj Gupta</td>
                                    <td>9800009898</td>
                                    <td>Bank of India</td>
                                    <td>1239876757</td>
                                    <td>BKID0000001</td>

                                    <td>25-Mar-2017
                                    </td>
                                    <td>600
                                    </td>

                                    <td>Refunded
                                    </td>
                                    <td>Refund</td>
                                    <td><span data-toggle="modal" data-target="#ActivateBene"><a href="#" class="btn disabled" data-toggle="tooltip" title="Activate" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>
                                    <td><span data-toggle="modal" data-target="#RefundOTP"><a href="# " class="btn disabled" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-transfer"></span></a></span></td>
                                </tr>
                                <tr class="danger">
                                    <td>5</td>
                                    <td>Amit Sanaye</td>
                                    <td>9898871000</td>
                                    <td>Bank of India</td>
                                    <td>76543098786</td>
                                    <td>BKID0000001</td>

                                    <td>27-Mar-2017
                                    </td>
                                    <td>4000
                                    </td>

                                    <td>API Timeout
                                    </td>
                                    <td></td>
                                    <td><span data-toggle="modal" data-target="#ReQuery"><a href="#" class="btn" data-toggle="tooltip" title="Txn Re-Query" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>
                                    <td><a href="#" class="btn disabled" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-transfer"></span></a></td>
                                </tr>
                                <tr>
                                    <td>6</td>
                                    <td>Amit Sanaye</td>
                                    <td>9898871000</td>
                                    <td>Bank of India</td>
                                    <td>76543098786</td>
                                    <td>BKID0000001</td>

                                    <td>27-Mar-2017
                                    </td>
                                    <td>4000
                                    </td>

                                    <td>FAIL
                                    </td>
                                    <td>Incomplete</td>
                                    <td><span data-toggle="modal" data-target="#ReQuery"><a href="#" class="btn disabled" data-toggle="tooltip" title="Txn Re-Query" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>
                                    <td><a href="#" class="btn disabled" data-toggle="tooltip" title="Delete" data-placement="top"><span class="glyphicon glyphicon-transfer"></span></a></td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="form-group">
                            <ul class="pagination pagination-lg">
                                <li class="active"><a href="#">1</a></li>
                                <li class="disabled"><a href="#">2</a></li>
                                <li class="disabled"><a href="#">3</a></li>
                                <li class="disabled"><a href="#">4</a></li>
                                <li class="disabled"><a href="#">5</a></li>
                            </ul>
                        </div>

                        <div class="modal fade" id="RefundOTP" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title text-uppercase">Refund</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="usr">OTP:</label>
                                            <input type="text" class="form-control" id="RefundOTPdelotp" placeholder="OTP" data-toggle="tooltip" title="OTP" data-placement="top" maxlength="10" required="required" />
                                        </div>
                                        <div class="btn-group">
                                            <input type="button" id="btnSubmitRefundOTPDelOTP" name="btnSubmit" value="Validate" class="btn btn-success" />
                                            &nbsp;&nbsp;&nbsp;
                                        <input type="button" id="btnSubmitRefundOTPResendDelOTP" name="btnSubmit" value="Resend OTP" class="btn btn-danger" />
                                        </div>
                                    </div>

                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="modal fade" id="ReQuery" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title text-uppercase">Transaction Status</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>Transaction Status = InProcess / Processed / On Hold / Success / Failed</p>


                                    </div>

                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading text-uppercase">Query Customer</div>
                <div class="panel-body">
                    <div class="form-group text-center">


                        <label for="usr">Wallet:</label>
                        &nbsp;
                            <label class="radio-inline">
                                <input type="radio" name="optradio" />UDIO
                            </label>
                        <label class="radio-inline">
                            <input type="radio" name="optradio" />Book My Show
                        </label>

                    </div>
                    <div class="form-group">
                        <label for="usr">Customer Mobile No:</label>
                        <input type="text" class="form-control" id="cardusr" placeholder="Enter Mobile No" data-toggle="tooltip" title="Enter Mobile No" data-placement="top" maxlength="10" required="required" />
                    </div>
                    <div class="btn-group">
                        <input type="button" id="btnSubmitCardExist" name="btnSubmit" value="Customer Exist" class="btn btn-success" />
                        &nbsp;&nbsp;&nbsp;
                         <input type="button" id="btnSubmitCard" name="btnSubmit" value="Customer Does Not Exist" class="btn btn-danger" data-toggle="modal" data-target="#CustomerDoesnotExist" />
                    </div>
                </div>

                <div class="modal fade" id="CustomerDoesnotExist" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title text-uppercase">Query Customer Status</h4>
                            </div>
                            <div class="modal-body danger">
                                <div class="danger">Customer does not exist</div>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading text-uppercase">UDIO Card Top up</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-6 text-right">
                            <label for="usr">Wallet:</label>
                            &nbsp;
                            <label class="text-info">
                                UDIO / Book My Show
                            </label>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-xs-6 text-right">
                            <label for="usr">Mobile No:</label>
                            &nbsp;
                            <label class="text-info">
                                XXXXXXXXXX
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <label for="usr">Name:</label>
                            &nbsp;
                           <label class="text-info">
                               Anil Shah
                           </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6 text-right">
                            <label for="usr">Wallet Available Balance:</label>
                            &nbsp;
                            <label class="text-info">
                                6000
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <label for="usr">Monthly Available Balance for Top Up</label>
                            <label class="text-info">
                                14000
                            </label>
                        </div>

                    </div>
                    <div class="form-group list-inline">
                        <label for="usr">Amount:</label>
                        <input type="text" class="form-control" id="cardtopupusr" placeholder="Enter Mobile No" data-toggle="tooltip" title="Enter Mobile No" data-placement="top" maxlength="10" required="required" />
                    </div>
                    <div class="btn-group">
                        <input type="button" id="btnSubmitCardtopupExist" name="btnSubmit" value="Top Up" class="btn btn-success" data-toggle="modal" data-target="#CardTopUpTxn" />
                        <%-- &nbsp;&nbsp;&nbsp;
                         <input type="button" id="btnSubmitCardtopup" name="btnSubmit" value="Customer Does Not Exist" class="btn btn-danger" />--%>
                    </div>
                </div>

                <div class="modal fade" id="CardTopUpTxn" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title text-uppercase">Card Top Up Transaction Status</h4>
                            </div>
                            <div class="modal-body">
                                <p>Transaction Status = Success / Failed </p>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>



            </div>

            <div class="panel panel-default">
                <div class="panel-heading text-uppercase">UDIO Card top up TRANSACTION HISTORY</div>
                <div class="panel-body">
                    <div class="form-inline text-center">
                        <label class="form-group">From Date</label>
                        &nbsp;<input type="text" class="form-control" placeholder="dd/mm/yyyy" data-toggle="tooltip" title="From Date" data-placement="top" />
                        &nbsp;
                        <label class="form-group">To Date</label>&nbsp;<input type="text" class="form-control" placeholder="dd/mm/yyyy" data-toggle="tooltip" title="To Date" data-placement="top" />
                        &nbsp;  &nbsp;
                   <input type="button" class="btn btn-primary text-uppercase" value="view" id="viewcardtxn" />
                    </div>

                    <br />
                    <div class="table-responsive small">
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="text-center">
                                    <th>Sr. No</th>

                                    <th>Name</th>
                                    <th>Mobile No</th>

                                    <th>Transaction Date</th>
                                    <th>Amount</th>

                                    <th>Partner Status</th>
                                    <th>UDIO Status</th>

                                    <th>Re-Query</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Anil Shah</td>
                                    <td>9898987898</td>


                                    <td>05-Mar-2017
                                    </td>
                                    <td>110
                                    </td>

                                    <td>Success
                                    </td>
                                    <td>Success</td>
                                    <td><span data-toggle="modal" data-target="#ReQueryCardTopUp"><a href="#" class="btn disabled" data-toggle="tooltip" title="Activate" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>

                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>Amit Sanaye</td>
                                    <td>9898871000</td>


                                    <td>15-Mar-2017
                                    </td>
                                    <td>4000
                                    </td>

                                    <td>Pending
                                    </td>
                                    <td>InProcess / Processed / On Hold</td>
                                    <td><span data-toggle="modal" data-target="#ReQueryCardTopUp"><a href="#" class="btn" data-toggle="tooltip" title="Txn Re-Query" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>

                                </tr>
                                <tr class="danger">
                                    <td>3</td>
                                    <td>Raj Gupta</td>
                                    <td>9800009898</td>


                                    <td>25-Mar-2017
                                    </td>
                                    <td>1100
                                    </td>
                                    <td>FAIL</td>
                                    <td>FAILED
                                    </td>
                                    <td><span data-toggle="modal" data-target="#ReQueryCardTopUp"><a href="#" class="btn disabled" data-toggle="tooltip" title="Requery" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>

                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>Raj Gupta</td>
                                    <td>9800009898</td>


                                    <td>25-Mar-2017
                                    </td>
                                    <td>600
                                    </td>

                                    <td>Success
                                    </td>
                                    <td>Success</td>
                                    <td><span data-toggle="modal" data-target="#ReQueryCardTopUp"><a href="#" class="btn disabled" data-toggle="tooltip" title="Activate" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>

                                </tr>
                                <tr class="danger">
                                    <td>5</td>
                                    <td>Amit Sanaye</td>
                                    <td>9898871000</td>


                                    <td>26-Mar-2017
                                    </td>
                                    <td>4000
                                    </td>

                                    <td>API Timeout
                                    </td>
                                    <td></td>
                                    <td><span data-toggle="modal" data-target="#ReQueryCardTopUp"><a href="#" class="btn" data-toggle="tooltip" title="Txn Re-Query" data-placement="top"><span class="glyphicon glyphicon-refresh"></span></a></span></td>

                                </tr>
                            </tbody>
                        </table>
                        <div class="form-group">
                            <ul class="pagination pagination-lg">
                                <li class="active"><a href="#">1</a></li>
                                <li class="disabled"><a href="#">2</a></li>
                                <li class="disabled"><a href="#">3</a></li>
                                <li class="disabled"><a href="#">4</a></li>
                                <li class="disabled"><a href="#">5</a></li>
                            </ul>
                        </div>


                        <div class="modal fade" id="ReQueryCardTopUp" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title text-uppercase">Card Top Up Transaction Status</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>Transaction Status = Success / Failed </p>
                                    </div>

                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>

           
        </div>
         <div class="panel panel-footer">2017 <span class="glyphicon glyphicon-copyright-mark"></span> &nbsp;Copyright. Agent Pvt Ltd.</div>
    </form>
</body>
</html>
