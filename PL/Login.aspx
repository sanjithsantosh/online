<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="PL.Login" %>

<%@ Register Assembly="PL" Namespace="PL.Amgra"
    TagPrefix="AmGRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="plhHeader" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 103px;
        }

        .auto-style7 {
            width: 94px;
        }

        .auto-style8 {
            width: 96px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="plhPageTitle">
    Login
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="plhPageContent" runat="server">
    <div class="ContentPane">
        <span style="float: right"><span class="req">*</span> indicates mandatory fields.</span>
        <table width="100%" border="0" style="border: dotted 1px #61ACDF" cellspacing="2">
            <tr>
                <td>
                    <table id="tblNme" runat="server">
                        <tr>
                            <td class="auto-style5">User Name</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtUsrNme" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="auto-style5">Password</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtpswd" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="AlphaNumeric" TextMode="Password" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>


            <tr>
                <td>


                    <table id="Table2" runat="server">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                            </td>

                           
                        </tr>
                    </table>






                </td>
            </tr>
        </table>
    </div>















    





























</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="plhScriptArea" runat="server">
    <script language="javascript" type="text/javascript" src="js/ps/RequestModule.js"></script>
    <script language="javascript" type="text/javascript">
        $("#SideMenuAccordion").accordion({ autoHeight: false, active: 0 });
    </script>
</asp:Content>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
    <div>
     <asp:Login ID="Login1" runat="server" OnLoggingIn="Login1_LoggingIn"></asp:Login>
    </div>
    </form>
</body>
</html>--%>
