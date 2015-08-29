<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProfessionalDetails.aspx.cs"
    Inherits="PL.ProfessionalDetails" %>

<%@ Register Assembly="PL" Namespace="PL.Amgra"
    TagPrefix="AmGRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="plhHeader" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 103px;
        }

        .auto-style10 {
            width: 126px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="plhPageTitle">
    Professional Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="plhPageContent" runat="server">
    <div class="ContentPane">
        <span style="float: right"><span class="req">*</span> indicates mandatory fields.</span>
        <table width="100%" border="0" style="border: dotted 1px #61ACDF" cellspacing="2">
            <tr>
                <td>
                    <table id="tblNme" runat="server">
                        <tr>
                            <td class="auto-style10">Total Experience
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txttoExp" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="Numeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tabladr2" runat="server">
                        <tr>
                            <td class="auto-style10">Previous Employer
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtprevemplyr" MaxLength="100"
                                    Width="180" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tbladr1" runat="server">
                        <tr>


                            <td class="auto-style10">Designation</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtprevDsgn" MaxLength="100" Width="180"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td>Reason for leaving</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtprevrsnfrlvng" MaxLength="40" Width="180px"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>

                    </table>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table1" runat="server">
                        <tr>


                            <td class="auto-style5">Roles/Responsibilities
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtprevrls" MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'500');"
                                    Width="250" IsMandatory="true" Height="60" TextMode="MultiLine" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>



















                    </table>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table3" runat="server">
                        <tr>


                            <td class="auto-style10">From Date</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtprvfrmdate" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="DatePicker" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td>To Date</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtprvtodate" MaxLength="40" Width="100px"
                                    IsMandatory="true" InputType="DatePicker" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>

                    </table>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table4" runat="server">
                        <tr>
                            <td class="auto-style10">Current Employer
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrntempl" MaxLength="100"
                                    Width="180" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table5" runat="server">
                        <tr>


                            <td class="auto-style10">Designation</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrntdsgn" MaxLength="100" Width="180"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td>Reason for leaving</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtrsnfrlvng" MaxLength="40" Width="180px"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>

                    </table>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table6" runat="server">
                        <tr>


                            <td class="auto-style5">Roles/Responsibilities
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtrls" MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'500');"
                                    Width="250" IsMandatory="true" Height="60" TextMode="MultiLine" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>



















                    </table>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table7" runat="server">
                        <tr>


                            <td class="auto-style10">From Date</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtfrmdte" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="DatePicker" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>

                    </table>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table2" runat="server">
                        <tr>


                            <td class="auto-style10">Current Salary/Annum (USD)</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtcrntslalary" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="Numeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td>Expected Salary/Annum (USD)</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtexpectdslry" MaxLength="40" Width="100px"
                                    IsMandatory="true" InputType="Numeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>

                    </table>

                </td>
            </tr>
                        <tr>
                <td align="right">


                    <table id="Table8" runat="server">
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
