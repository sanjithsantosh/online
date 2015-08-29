<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RequestedDetails.aspx.cs"
    Inherits="AmericanExpress.PaUi.WP.RequestDetails" %>
<%@ Register Src="uc/RequestDetails.ascx" TagName="RequestDetails" TagPrefix="ucRequestDetails" %>
<%@ Register Src="~/uc/IssuanceOptionSummary.ascx" TagName="IssuanceOptionSummary" TagPrefix="ucIssuanceOptionSummary" %>
<%@ Register Src="~/uc/IAIORelationshipSummary.ascx" TagName="IAIORelationshipSummary" TagPrefix="ucIAIORelationshipSummary" %>
<%@ Register Src="~/uc/FeatureAssociationSummary.ascx" TagName="FeatureAssociationSummary" TagPrefix="ucFeatureAssociationSummary" %>
<%@ Register Src="~/uc/RateAssociationSummary.ascx" TagName="RateAssociationSummary" TagPrefix="ucRateAssociationSummary" %>
<%@ Register assembly="AmericanExpress.PaUi.WP" namespace="AmericanExpress.PaUi.WP.Amgra" tagprefix="AmGRA" %>
<asp:Content ID="Content2" ContentPlaceHolderID="plhPageTitle" runat="server">Request Details </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="plhPageContent" runat="server">
    <div class="ContentPane">
        <br clear="all" />
        <fieldset>
            <legend>Request Details</legend>
            <ucRequestDetails:RequestDetails ID="ucRequestDetails" runat="server" />
        </fieldset>        
        <asp:Panel runat="server" Visible="false" ID="pnlKeyerPanel">
        <br clear="all" />
            <table>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit for Approval" OnClientClick="javascript:return confirm('Do you wish to submit this request for approval?');" onclick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:return confirm('Do you wish to cancel this request?');" Text="Cancel Request" onclick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td><strong>Select module to work with : &nbsp;</strong></td>
                    <td><asp:DropDownList ID="cmbModules" runat="server"></asp:DropDownList></td>
                    <td><asp:Button ID="btnGo" runat="server" Text="Go" onclick="btnGo_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
       <asp:Panel runat="server" Visible="false" ID="pnlCancel">
       <br clear="all" />
            <table>
                <tr>
                    <td> <asp:Button ID="btnCncl" runat="server" OnClientClick="javascript:return confirm('Do you wish to cancel this request?');" Text="Cancel Request" onclick="btnCancel_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" Visible="false" ID="pnlApproverPanel">
        <table>
            <tr>
                <td><strong>Review Request</strong></td> 
            </tr>
            <tr>   
                <td><i>Click on Approve or Reject to complete your review.</i></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnApprove" runat="server" Text="Approve" OnClientClick="javascript:return confirm('Do you wish to approve this request?');" onclick="btnApprove_Click" />&nbsp;
                <asp:Button ID="btnReject"  runat="server" Text="Reject" OnClientClick="javascript:return ShowComments();" /></td>     
            </tr>
        </table>
        </asp:Panel>
        <br clear="all" />
        <asp:Panel runat="server" ID="pnlSummaryTab" CssClass="HTab"></asp:Panel>
        <div id="divComments" class="c_dlgOptions" title="Comments" style="display:none">
		    <table>
			    <tr>
				    <td>
				        <br clear="all" />
				        <em style="font-size:x-small">please enter your comments here</em>
				        <br clear="all" />
				        <asp:TextBox ID="txtComments" runat="server" Width="100px" Height="100px" MaxLength="1024"></asp:TextBox>
				        <textarea cols="50" rows="5"></textarea>
				        <br clear="all" />
				    </td>
			    </tr>
		    </table>
		    <br clear="all" />
		    <asp:Button ID="btnSbt" runat="server" Text="Submit" OnClick="btnReject_Click" />	
		    <input type="submit" value="Cancel" onclick="javascript:($('#divComments').dialog('close'));return false;" />
	    </div>   
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="plhScriptArea" runat="server">
    <script language="javascript" type="text/javascript">
        $("#SideMenuAccordion").accordion({ active: 0 });
        $(document).ready(function() {
            CreateHTab("<%=pnlSummaryTab.ClientID %>");
        });
    </script>
    <script language="javascript" type="text/javascript" src="js/ps/RequestModule.js"></script>
</asp:Content>
