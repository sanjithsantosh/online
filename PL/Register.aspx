<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="PL.Register" %>

<%@ Register Assembly="PL" Namespace="PL.Amgra"
    TagPrefix="AmGRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="plhHeader" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 103px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="plhPageTitle">
    Register
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
                    <table id="tblemail" runat="server">
                        <tr>
                            <td class="auto-style5">Email ID 1
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtemailid" MaxLength="40"
                                    Width="130" IsMandatory="true" InputType="CustomRegEx" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
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
                                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
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
