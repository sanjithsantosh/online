<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EducationalDetails.aspx.cs"
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
    Highest Educational Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="plhPageContent" runat="server">
    <div class="ContentPane">
        <span style="float: right"><span class="req">*</span> indicates mandatory fields.</span>
        <table width="100%" border="0" style="border: dotted 1px #61ACDF" cellspacing="2">
            <tr>
                <td>
                    <table id="tblNme" runat="server">
                        <tr>
                            <td class="auto-style5">Institution
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtInstitution" MaxLength="40" Width="180"
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


                          
                            <td class="auto-style5">Country</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtCntry" MaxLength="40" Width="180"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                       
                    </table>

                </td>
            </tr>



            <tr>
                <td>
                    <table id="tblDgree" runat="server">
                        <tr>
                            <td class="auto-style5">Major Degree Program
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtmjdgrpgm" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                            <td>2nd Major Degree Program
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txt2ndmjdgrpgm" MaxLength="40" Width="100"
                                    InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                            <td>Minor Degree Program
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtmnrdgrpgm" MaxLength="40" Width="100"
                                   InputType="AlphaNumeric" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tbledlvl" runat="server">
                        <tr>
                            <td class="auto-style5">Education Level
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtednlvl" MaxLength="40" Width="180"
                                    IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true">
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
                            <td class="auto-style5">Start Date
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtstdate" MaxLength="40" Width="100"
                                    IsMandatory="true" InputType="DatePicker" AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                            <td>End Date
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtendate" MaxLength="40" Width="100"
                                    InputType="DatePicker"  AttachedJavaScript="true">
                                </AmGRA:AmgraTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>



            <tr>
                <td>
                    <table id="tblcrcty" runat="server">
                        <tr>
                            <td class="auto-style5">Name of Higher Secondary School
                            </td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txthscndry" MaxLength="40"
                                    Width="130" IsMandatory="true" InputType="AlphaNumeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
                            </td>
                            <td class="auto-style8">GPA</td>
                            <td>
                                <AmGRA:AmgraTextBox runat="server" ID="txtGPA" MaxLength="40"
                                    Width="50" InputType="Numeric" AttachedJavaScript="true"></AmGRA:AmgraTextBox>
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
