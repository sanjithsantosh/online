<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CertificationDetails.aspx.cs"
    Inherits="PL.EducationalDetails" %>

<%@ Register Assembly="PL" Namespace="PL.Amgra"
    TagPrefix="AmGRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="plhHeader" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 103px;
        }

        .auto-style8 {
            width: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="plhPageTitle">
    Certification Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="plhPageContent" runat="server">
    <div class="ContentPane">
        <span style="float: right"><span class="req">*</span> indicates mandatory fields.</span>
        <table width="100%" border="0" style="border: dotted 1px #61ACDF" cellspacing="2">
            <tr>
                <td>
                    <table id="tblNme" runat="server">
                        <tr>
                            <td class="auto-style5">Certification Name</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcert1" MaxLength="40" Width="180"
                                     InputType="AlphaNumeric" AttachedJavaScript="true">
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


                          
                            <td class="auto-style5">Organization</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtorg1" MaxLength="40" Width="180"
                                    InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>

                            <td class="auto-style5">Expiry Date
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtexprydte1" MaxLength="40" Width="100"
                                    InputType="DatePicker" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                       
                    </table>

                </td>
            </tr>

            <tr>
                <td>
                    <table id="Table1" runat="server">
                        <tr>
                            <td class="auto-style5">Certification Name</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcert2" MaxLength="40" Width="180"
                                     InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table3" runat="server">
                        <tr>


                          
                            <td class="auto-style5">Organization</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtorg2" MaxLength="40" Width="180"
                                   InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>

                            <td class="auto-style5">Expiry Date
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtexp2" MaxLength="40" Width="100"
                                    InputType="DatePicker" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                       
                    </table>

                </td>
            </tr>

            <tr>
                <td>
                    <table id="Table4" runat="server">
                        <tr>
                            <td class="auto-style5">Certification Name</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrt3" MaxLength="40" Width="180"
                                    InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table5" runat="server">
                        <tr>


                          
                            <td class="auto-style5">Organization</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtorg3" MaxLength="40" Width="180"
                                    InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>

                            <td class="auto-style5">Expiry Date
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtexpry3" MaxLength="40" Width="100"
                                    InputType="DatePicker" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
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
                                <asp:Button ID="btnCancel" runat="server" Text="Save as Draft" OnClick="btnCancel_Click" />
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
