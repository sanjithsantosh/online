// Date Created             : April 1, 2011 
// Author                   : TCS, DCFE Offshore
// 
// Change History
//
// Date Modified            : April 1, 2011
// Changed By               : TCS, DCFE Offshore
// Change Description       : Created 

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using AmericanExpress.PaUi.BE;
using System.Collections.Generic;
using AmericanExpress.PaUi.BL;
using System.Text;
using System.Net.Mail;
using AmericanExpress.Util.Logging;
using AmericanExpress.Util.CommonUtilities;
using AmericanExpress.PaUi.BE.Common;
using System.IO;

namespace AmericanExpress.PaUi.WP
{
    /// <summary>
    /// Request details
    /// </summary>
    public partial class RequestedDetails : BasePage
    {
        /// <summary>
        /// Page Render
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            // KEYER Panel :- 
            // -> Status should NOT be Approved,Cancelled and Completed 
            // -> Should be a Keyer/Super User
            // APPROVER Panel : -
            // -> Status should NOT be Approved,Cancelled and Completed 
            // -> Should be an Approver, who has NOT created the request/Super User
            // CANCEL Panel : -
            // -> Status should NOT be Approved,Cancelled and Completed 
            // -> Should be a Requester, who created the request/Super User

            //Check Status
            pnlKeyerPanel.Visible = (ucRequestDetails.CurrRequest.Status != RequestStatus.SubmittedForApproval);
            pnlApproverPanel.Visible = (ucRequestDetails.CurrRequest.Status == RequestStatus.SubmittedForApproval);

            // Check On Role
            //pnlKeyerPanel.Visible = (pnlKeyerPanel.Visible && UserSession.IsKeyer);
            //pnlKeyerPanel.Visible = (pnlKeyerPanel.Visible &&
            //                                (HasAcessRights(Constants.CODE_MODULE_IO, Permission.Edit) ||
            //                                HasAcessRights(Constants.CODE_MODULE_RATE, Permission.Edit)));
            pnlKeyerPanel.Visible = (pnlKeyerPanel.Visible && cmbModules.Items.Count > 1);

            // If approver panel is visible and the logged in user is a approver and 
            // also if he is not the requester of the corresponding request then approver panel should be shown
            //pnlApproverPanel.Visible = (pnlApproverPanel.Visible && UserSession.IsApprover && RequesterId != ucRequestDetails.CurrRequest.Requester.ID);
            pnlApproverPanel.Visible = (pnlApproverPanel.Visible && HasAcessRights(Constants.CODE_MODULE_REQUEST, Permission.Approve) && !ucRequestDetails.CurrRequest.Requester.ID.Equals(RequesterId));

            // If logged in user is a superuser or a requester and also equals the requester of the particular request
            // cancel panel should be visible.
            //pnlCancel.Visible = (UserSession.IsSuperUser || (UserSession.IsRequesterOnly && ucRequestDetails.CurrRequest.Requester.ID.Equals(RequesterId)));
            pnlCancel.Visible = (UserSession.IsSuperUser || (HasAcessRights(Constants.CODE_MODULE_REQUEST, Permission.Edit) && ucRequestDetails.CurrRequest.Requester.ID.Equals(RequesterId)));

            //If status is cancel or complete, hide all panels
            pnlKeyerPanel.Visible = pnlKeyerPanel.Visible && (ucRequestDetails.CurrRequest.Status != RequestStatus.Approved && ucRequestDetails.CurrRequest.Status != RequestStatus.Cancelled && ucRequestDetails.CurrRequest.Status != RequestStatus.Completed);
            pnlApproverPanel.Visible = pnlApproverPanel.Visible && (ucRequestDetails.CurrRequest.Status != RequestStatus.Approved && ucRequestDetails.CurrRequest.Status != RequestStatus.Cancelled && ucRequestDetails.CurrRequest.Status != RequestStatus.Completed);
            pnlCancel.Visible = pnlCancel.Visible && (ucRequestDetails.CurrRequest.Status != RequestStatus.Approved && ucRequestDetails.CurrRequest.Status != RequestStatus.Cancelled && ucRequestDetails.CurrRequest.Status != RequestStatus.Completed);

            // Cancel button is present in Keyer panel as well as in Cancel panel.
            if (pnlCancel.Visible && pnlKeyerPanel.Visible)
            {
                pnlCancel.Visible = false;
            }
            else
            {
                btnCancel.Visible = false;
            }

            base.Render(writer);
        }

        /// <summary>
        /// This page is for getting request details.
        /// </summary> 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!AuthenticatePage()) { return; }
            }
            getModules();
        }

        /// <summary>
        /// AuthenticatePage
        /// </summary>
        protected override bool AuthenticatePage()
        {
            cmbModules.Items.Insert(0, string.Empty);

            //if (UserSession.IsKeyer)
            if (HasAcessRights(Constants.CODE_MODULE_IO, Permission.Edit))
            {
                cmbModules.Items.Add(new ListItem(Constants.MODULE_IO, Constants.CODE_MODULE_IO.ToString()));
            }
            if (HasAcessRights(Constants.CODE_MODULE_RATE, Permission.Edit))
            {
                cmbModules.Items.Add(new ListItem(Constants.MODULE_RATE, Constants.CODE_MODULE_RATE.ToString()));
            }

            return true;
        }

        /// <summary>
        /// Event for cancelling  a request.
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCancel.CommandArgument != "0")
                {
                    ShowMessage(Constants.ERR_CANCEL_REQUEST, MessageType.Error);
                    return;
                }
                if (!updateRequestStatus(RequestStatus.Cancelled))
                {
                    ShowMessage(Constants.ERR_CANCEL_REQUEST_DATA, MessageType.Error);
                    return;
                }

                // Sending Notification
                if (!sendNotification(NotifyType.Cancel))
                {
                    ShowMessage(Constants.ERR_SEND_MAIL, MessageType.Error);
                    return;
                }

                ShowMessage(Constants.SUC_CANCEL_REQUEST_DATA, MessageType.Success);
            }

            catch (Exception ex)
            {
                ShowErrorPage(ex);
            }
        }

        /// <summary>
        /// Event for submitting a request for approval.
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO Validation K245 page number 30 
                //A default IA/IO/Role row must also be created for the IA for the Secondary 
                if (!updateRequestStatus(RequestStatus.SubmittedForApproval))
                {
                    ShowMessage(Constants.ERR_SUBMIT_REQUEST_DATA, MessageType.Error);
                    return;
                }

                // Sending Notification
                if (!sendNotification(NotifyType.SubmitForApproval))
                {
                    ShowMessage(Constants.ERR_SEND_MAIL, MessageType.Error);
                    return;
                }

                ShowMessage(Constants.SUC_SUBMIT_REQUEST_DATA, MessageType.Success);
            }

            catch (Exception ex)
            {
                ShowErrorPage(ex);
            }
        }

        /// <summary>
        /// Event for rejecting a request.
        /// </summary>
        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (!updateRequestStatus(RequestStatus.Rejected))
                {
                    ShowMessage(Constants.ERR_REJECT_REQUEST_DATA, MessageType.Error);
                    return;
                }

                // Sending Notification
                if (!sendNotification(NotifyType.Reject))
                {
                    ShowMessage(Constants.ERR_SEND_MAIL, MessageType.Error);
                    return;
                }

                ShowMessage(Constants.SUC_REJECT_REQUEST_DATA, MessageType.Success);
            }

            catch (Exception ex)
            {
                ShowErrorPage(ex);
            }

        }

        /// <summary>
        /// Event for approving a request.
        /// </summary>
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucRequestDetails.CurrRequest.ValidationNotes != "NONE")
                {
                    ShowMessage(Constants.ERR_APPROVE_VALIDATION_DATA, MessageType.Error);
                    return;
                }

                if (!updateRequestStatus(RequestStatus.Approved))
                {
                    ShowMessage(Constants.ERR_APPROVE_REQUEST_DATA, MessageType.Error);
                    return;
                }

                // Sending Notification
                if (!sendNotification(NotifyType.Approve))
                {
                    ShowMessage(Constants.ERR_SEND_MAIL, MessageType.Error);
                    return;
                }

                ShowMessage(Constants.SUC_APPROVE_REQUEST_DATA, MessageType.Success);
            }
            catch (Exception ex)
            {
                ShowErrorPage(ex);
            }
        }

        /// <summary>
        /// Update Request Status
        /// </summary>
        /// <param name="reqStatus"></param>
        /// <returns></returns>
        private bool updateRequestStatus(RequestStatus reqStatus)
        {
            BL.RequestManagement _requestManagement = new BL.RequestManagement();
            bool _status = false;

            if (reqStatus == RequestStatus.Approved)
            {
                _status = _requestManagement.ApproveRequest(RequesterId, RequestId);
            }
            else
            {
                Request _request = new Request();
                _request.ID = RequestId;
                _request.Requester.ID = RequesterId;
                _request.Status = reqStatus;
                _request.Comments = string.Concat(ucRequestDetails.CurrRequest.Comments, ((!string.IsNullOrEmpty(txtComments.Text)) ? string.Concat("<br/>", txtComments.Text) : string.Empty));

                _status = _requestManagement.UpdateRequestStatus(RequesterId, _request);
            }

            if (!_status) { return false; }

            // Refresh status
            ucRequestDetails.RefreshRequestDetails();
            return true;
        }


        /// <summary>
        /// Send Notification
        /// </summary>
        /// <param name="notifyType"></param>
        /// <returns></returns>
        private bool sendNotification(NotifyType notifyType)
        {
            MailMessage _mail = new MailMessage();
            _mail.IsBodyHtml = true;
            string _emailContent = string.Empty;
            string _requestName = !string.IsNullOrEmpty(ucRequestDetails.CurrRequest.Name) ? ucRequestDetails.CurrRequest.Name : "--";
            string _requestDesc = !string.IsNullOrEmpty(ucRequestDetails.CurrRequest.Description) ? ucRequestDetails.CurrRequest.Description : "--";
            string _targetDate = ucRequestDetails.CurrRequest.TargetProductionDate != null ? Convert.ToDateTime(ucRequestDetails.CurrRequest.TargetProductionDate).ToString("MM/dd/yyyy") : "--";
            string _accessHistoryURL = "https://" + Request.Url.Authority + "/ProductAssembler/PAUI/RequestHistoryDetails.aspx?req=" + RequestId;  //Request.Url.ToString().Replace(Request.Url.LocalPath, "/RequestHistoryDetails.aspx");

            switch (notifyType)
            {
                case NotifyType.SubmitForApproval:
                    string _requester = !string.IsNullOrEmpty(ucRequestDetails.CurrRequest.Requester.FullName) ? ucRequestDetails.CurrRequest.Requester.FullName : "--";
                    _emailContent = File.ReadAllText(Server.MapPath("Template/SubmitEmail.html"));
                    _mail.Body = string.Format(_emailContent, RequestId, _requestName, _requestDesc, _requester, _targetDate, Request.Url.ToString());
                    _mail.Subject = string.Format(Constants.SUBMIT_SUBJECT, RequestId);
                    break;
                case NotifyType.Approve:
                    _emailContent = File.ReadAllText(Server.MapPath("Template/ApproveEmail.html"));
                    _mail.Body = string.Format(_emailContent, RequestId, _requestName, _requestDesc, _targetDate, _accessHistoryURL);
                    _mail.Subject = string.Format(Constants.APPROVE_SUBJECT, RequestId);
                    break;
                case NotifyType.Reject:
                    string _rejectComments = !string.IsNullOrEmpty(ucRequestDetails.CurrRequest.Comments) ? ucRequestDetails.CurrRequest.Comments : "--";
                    _emailContent = File.ReadAllText(Server.MapPath("Template/RejectEmail.html"));
                    _mail.Body = string.Format(_emailContent, RequestId, _requestName, _requestDesc, _rejectComments, _targetDate, _targetDate, Request.Url.ToString());
                    _mail.Subject = string.Format(Constants.REJECT_SUBJECT, RequestId);
                    break;
                case NotifyType.Cancel:
                    _emailContent = File.ReadAllText(Server.MapPath("Template/CancelEmail.html"));
                    _mail.Body = string.Format(_emailContent, RequestId, _requestName, _requestName, _requestDesc, _targetDate, _accessHistoryURL);
                    _mail.Subject = string.Format(Constants.CANCEL_SUBJECT, RequestId);
                    break;
            }

            BL.RequestManagement _requestManagement = new BL.RequestManagement();
            // Sending notification
            bool _mailstatus = _requestManagement.SendNotification(RequesterId, ucRequestDetails.CurrRequest.Requester.EmailID, _mail, notifyType);
            if (!_mailstatus)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Method  to get the modules of a corresponding request.
        /// </summary> 
        protected void getModules()
        {
            try
            {
                BE.Request _request = new BE.Request();
                _request.PageNumber = 1;
                _request.ItemsPerPage = 10;
                _request.SortFieldCode = 1;
                _request.SortOrder = Constants.SORT_DESCENDING;

                BL.RequestManagement _requestManagement = new BL.RequestManagement();
                Request _moduleRequest = _requestManagement.GetModuleRequest(RequesterId, RequestId);
                btnCancel.CommandArgument = (_moduleRequest.Modules == null) ? "0" : _moduleRequest.Modules.Count.ToString();
                if (_moduleRequest.Modules == null)
                {
                    return;
                }

                createTab(_moduleRequest.Modules);
            }
            catch (Exception ex)
            {
                ShowErrorPage(ex);
            }
        }

        /// <summary>
        /// Method  for creating the modules tab.
        /// </summary>
        private void createTab(List<Module> _moduleList)
        {
            try
            {

                HtmlGenericControl _HeaderDiv = new HtmlGenericControl("div");
                _HeaderDiv.ID = "HTab_Header";
                _HeaderDiv.Attributes["class"] = "HTab_Header";

                HtmlAnchor _HTabItemAnchor = null;

                for (int i = 0; i < _moduleList.Count; i++)
                {
                    _HTabItemAnchor = new HtmlAnchor();
                    _HTabItemAnchor.ID = "HTab_" + i;
                    _HTabItemAnchor.HRef = "javascript:void(0);";
                    _HTabItemAnchor.InnerHtml = string.Format("{0} Summary", _moduleList[i].Name);
                    if (i == 0) _HTabItemAnchor.Attributes.Add("class", "SEL");
                    _HeaderDiv.Controls.Add(_HTabItemAnchor);
                }

                pnlSummaryTab.Controls.Add(_HeaderDiv);
                HtmlGenericControl _HTabDataPane = null;

                for (int i = 0; i < _moduleList.Count; i++)
                {
                    _HTabDataPane = new HtmlGenericControl("div");
                    _HTabDataPane.Attributes.Add("class", "HTab_DataView");
                    _HTabDataPane.Attributes["tabfor"] = "HTab_" + i;
                    if (i == 0) _HTabDataPane.Attributes.Add("style", "display:block");
                    else _HTabDataPane.Attributes.Add("style", "display:none");

                    if (_moduleList[i].ID == Constants.CODE_MODULE_IO)
                    {
                        List<SubModule> _subModules = _moduleList[i].SubModules;
                        if (_subModules != null)
                        {
                            foreach (SubModule _subMod in _subModules)
                            {
                                switch (_subMod.ID)
                                {
                                    case Constants.CODE_SUBMODULE_IO:
                                        Control IssuanceOptionSummaryUserControl = (Control)Page.LoadControl("~/uc/IssuanceOptionSummary.ascx");
                                        UC.IssuanceOptionSummary _issuanceOptionSummary = new UC.IssuanceOptionSummary();
                                        _HTabDataPane.Controls.Add(IssuanceOptionSummaryUserControl);
                                        break;
                                    case Constants.CODE_SUBMODULE_IAIO:
                                        Control IAIORelationshipSummaryUserControl = (Control)Page.LoadControl("~/uc/IAIORelationshipSummary.ascx");
                                        UC.IAIORelationshipSummary _iAIORelationshipSummary = new UC.IAIORelationshipSummary();
                                        _HTabDataPane.Controls.Add(IAIORelationshipSummaryUserControl);
                                        break;
                                    case Constants.CODE_SUBMODULE_FEATURE:
                                        Control FeatureAssociationSummaryUserControl = (Control)Page.LoadControl("~/uc/FeatureAssociationSummary.ascx");
                                        UC.FeatureAssociationSummary _featureAssociationSummary = new UC.FeatureAssociationSummary();
                                        _HTabDataPane.Controls.Add(FeatureAssociationSummaryUserControl);
                                        break;
                                }
                            }
                        }
                    }

                    if (_moduleList[i].ID == Constants.CODE_MODULE_RATE)
                    {
                        Control RateAssociaitionSummaryUserControl = (Control)Page.LoadControl("~/uc/RateAssociationSummary.ascx");
                        _HTabDataPane.Controls.Add(RateAssociaitionSummaryUserControl);
                    }
                    pnlSummaryTab.Controls.Add(_HTabDataPane);
                }
            }
            catch (Exception ex)
            {
                ShowErrorPage(ex);
            }
        }

        /// <summary>
        /// Method  for Go button click.
        /// </summary>
        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (cmbModules.SelectedIndex > 0)
            {
                switch (Convert.ToInt32(cmbModules.SelectedItem.Value))
                {
                    case Constants.CODE_MODULE_IO:
                        Response.Redirect("IOModule.aspx?req=" + RequestId, false);
                        break;
                    case Constants.CODE_MODULE_RATE:
                        Response.Redirect("RateModule.aspx?req=" + RequestId, false);
                        break;
                }
            }
            else
            {
                ShowMessage(Constants.VAL_SELECT_MODULE, MessageType.Error);
            }
        }
    }
}
