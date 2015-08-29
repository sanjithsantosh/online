<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs"
    Inherits="PL.PersonalDetails" %>

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
    Personal Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="plhPageContent" runat="server">
    <div class="ContentPane">
        <span style="float: right"><span class="req">*</span> indicates mandatory fields.</span>
        <table width="100%" border="0" style="border: dotted 1px #61ACDF" cellspacing="2">
            <tr>
                <td>
                    <table id="tblNme" runat="server">
                        <tr>
                            <td class="auto-style5">First Name
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtFrstNme" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                            <td>Second Name
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtScndNme" MaxLength="40" Width="100"
                                    InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                            <td>Last Name
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtLstNme" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tbladr1" runat="server">
                        <tr>


                            <td class="auto-style5">Gender</td>
                            <td>
                                <AmGRA:AmgraDropDownList ID="cmbGndr" AttachedJavaScript="true" IsMandatory="true" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                </AmGRA:AmgraDropDownList>
                            </td>
                            <td>Nationality</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtNat" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                      
                    </table>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table3" runat="server">
                        <tr>
                            <td class="auto-style5">Resident Address 1
                              </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtAdr1" MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'500');"
                                    Width="250" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>


                        </tr>
                    </table>

                </td>
            </tr>



            <tr>
                <td>
                    <table id="tabladr2" runat="server">
                        <tr>
                            <td class="auto-style5">Resident Address 2
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtAdr2" MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'500');"
                                    Width="250" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>


            <tr>
                <td>
                    <table id="tblctyrsn" runat="server">
                        <tr>
                            <td class="auto-style5">City
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtrsnCty" MaxLength="40"
                                    Width="130" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td class="auto-style7">Postal Code
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtpscde" MaxLength="40"
                                    Width="50" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>

            </tr>

            <tr>
                <td>
                    <table id="Table1" runat="server">
                        <tr>


                            <td class="auto-style5">Current Address 1
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrntAdrs1" MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'500');"
                                    Width="250" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style5">Current Address 2
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrntAdrs2" MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'500');"
                                    Width="250" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>


                        </tr>
                    </table>

                </td>
            </tr>



            <tr>
                <td>
                    <table id="tblcrcty" runat="server">
                        <tr>
                            <td class="auto-style5">City
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrCty" MaxLength="40"
                                    Width="130" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td class="auto-style8">Postal Code
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrPsCde" MaxLength="40"
                                    Width="50" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>

            </tr>
            <tr>
                <td>
                    <table id="tblnmbr" runat="server">
                        <tr>
                            <td class="auto-style5">Primary Number
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtPmNmbr" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="Numeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                            <td>Home Number
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtHMENmbr" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="Numeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                            <td>Mobile Number
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtmobNmbr" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="Numeric" AttachedJavaScript="true">
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
                                <AmGRA:AmgraTextBox runat="server" ID="txtemailid1" MaxLength="40"
                                    Width="130" IsMandatory="true" InputType="CustomRegEx" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td>Email ID 2
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtemailid2" MaxLength="40"
                                    Width="130" InputType="CustomRegEx" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>

            </tr>


            <tr>
                <td align="right">


                    <table id="Table2" runat="server">
                        <tr>
                            <td>
                                <asp:Button ID="btnCreate" runat="server" Text="Save and Continue" OnClick="btnCreate_Click" />
                            </td>

                            <td>
                                <asp:Button ID="btnSveDrft" runat="server" Text="Save as Draft" OnClick="btnSveDrft_Click" />
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
