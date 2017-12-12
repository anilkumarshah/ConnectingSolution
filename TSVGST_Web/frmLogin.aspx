<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="frmLogin"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
   
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="container container-table">
             <asp:ValidationSummary ID="validationsummary2" runat="server" ShowMessageBox="true" DisplayMode="List" ValidationGroup="Login" ShowSummary="false" />
            <div class="row vertical-center-row">
                <div class="col-lg-4"></div>



                <div class="col-lg-4 span8 offset2">

                    <div class="alert alert-danger" id="dvError" runat="server" visible="false"></div>
                    <div class="panel panel-default">
                        <div class="panel-heading">Login </div>
                        <div class="panel-body ">
                            <div class="row ">
                                <div class="form-inline">
                                    <div class="col-lg-3">
                                        <label for="username" class="label text-uppercase">User Name</label>
                                    </div>
                                    <div class="col-lg-9">
                                        <%-- <span class="input-group-addon"><i class="glyphicon">User Name</i></span>--%><input type="text" runat="server" id="txtUserName" class="form-control" />
                                         <asp:RequiredFieldValidator ID="rfvtxtShippingAddressLine1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter User Name" SetFocusOnError="true" InitialValue="" ValidationGroup="Login" Display="None"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div></div>
                            <div class="row">
                                <div class="form-inline">
                                    <div class="col-lg-3">
                                        <label for="username" class="label text-uppercase">Password</label>
                                    </div>
                                    <div class="col-lg-9">
                                        <%--<span class="input-group-addon"><i class="glyphicon">Password</i></span>--%><input type="password" runat="server" id="txtPassword" class="form-control" />
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password" SetFocusOnError="true" InitialValue="" ValidationGroup="Login" Display="None"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="height:10px;"></div>
                            <div class="row">
                                <div class="col-lg-3"></div>
                                <div class="col-lg-9">
                                   <%-- <input type="submit" runat="server" id="btnLogin" class="btn btn-success btn-sm" value="Login" ValidationGroup="Login"/>
                                    <input type="submit" runat="server" id="btnReset" class="btn btn-info btn-sm" value="Reset"/>--%>
                                     <asp:Button  runat="server" id="btnLogin" class="btn btn-success btn-sm" Text="Login" ValidationGroup="Login" OnClientClick="click" OnClick="btnLogin_Click"/>
                                     <asp:Button runat="server" id="btnReset" class="btn btn-info btn-sm" Text="Reset"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="col-lg-4"></div>
            </div>
        </div>
    </form>

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
   <%-- <script src="Scripts/Encryption/enc-utf16-min.js"></script>
    <script src="Scripts/Encryption/sha256.js"></script>--%>
    <script src="Scripts/Encryption/sha1.js"></script>
    <%-- <link href="Content/bootstrap.css" rel="stylesheet" />--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script type="text/javascript">
        try{
            $(document).ready(function () {
                $('#btnLogin').click(function ()
                {
                    try {
                        var strPassword = $('#txtPassword').val();
                     //   alert('Plain Passsword - ' + strPassword);
                        //var word = CryptoJS.enc.Utf16LE.parse(strPassword);
                        //alert('Enc Value for Password -' + word);
                        //var hash = CryptoJS.SHA256(word);
                      
                        var id2 = b64_sha1(strPassword);
                      //  $("#TextBox1").val(id2);

                        $("#txtPassword").val(id2);
                        return true;
                    }
                    catch (err) {
                        alert('error - ' + err.message);
                        //$('.dvError').html(err.message);
                        //$('.dvError').prop('visible', 'true');
                        return fa;
                    }

                });

                function getPasssordhash()
                {
                        var strPassword = $('#txtPassword').val();
                      //  alert('Plain Passsword - ' + strPassword);
                        var word = CryptoJS.enc.Utf16LE.parse(strPassword);
                      //  alert('Enc Value for Password -' + word);
                        var hash = CryptoJS.SHA256(word);
                     //   alert('Hash Value -' + hash);
                }
            });
        }
        catch (err) {
            alert('error - ' + err.message);
       //     document.getElementById("demo").innerHTML = err.message;
            $('.dvError').html(err.message);
            $('.dvError').show();
        }
    </script>
</body>

</html>
