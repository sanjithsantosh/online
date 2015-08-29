// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       :  : 
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BE;
using System.Collections.Generic;
using BE.Common;
using System.Threading;

namespace PL
{
    /// <summary>
    /// Base Page
    /// </summary>
    public abstract class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// Delegate for handling Access denied error. It can call explicitily when an action which doesn't have access to the current user
        /// </summary>
        protected delegate void AccessDenied(User user, string url);
        protected AccessDenied OnAccessDenied;

        /// <summary>
        /// Session data for Logged in User
        /// </summary>
        public User UserSession
        {
            get
            {
                try
                {
                    BE.User _user = (User)Session[Constants.USER_SESSION];
                    if (_user != null) return _user;

                    // The change is not pushed to PAUI
                    throw new Exception(Constants.ERR_SESSION_TIME_OUT);
                }
                catch
                {
                    throw new Exception(Constants.ERR_SESSION_TIME_OUT);
                }
            }
        }


        /// <summary>
        /// Display message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        protected virtual void ShowMessage(string message, MessageType messageType)
        {
          

            Common.OnShowMessage(this, _msgEventArgs);
        }

        /// <summary>
        /// Display message
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        protected virtual void ShowMessage(Exception ex, string message, MessageType messageType)
        {
            // Added on 08/17
           
            ShowMessage(message, messageType);
        }

        /// <summary>
        /// ShowErrorPage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        protected virtual void ShowErrorPage(Exception ex)
        {
            if (!string.IsNullOrEmpty(ex.Message))
            {
                
            }
            throw new Exception(string.Empty);
        }


        /// <summary>
        /// On Load 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            //if (UserSession == null)
            //{
            //    Response.Redirect(String.Format(ConfigurationManager.AppSettings["SSOTimeOutUrl"].ToString(), Request.Url.Authority), false);
            //    return;
            //}

            base.OnLoad(e);
        }


        /// <summary>
        /// On error Event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            // Do not log the error if the error object is null / error message is empty / error message is from Amgra control
            if (HttpContext.Current.Error != null && !string.IsNullOrEmpty(HttpContext.Current.Error.Message) && !HttpContext.Current.Error.Message.Equals(Constants.ERR_AMGRA_DATA_LOAD))
            {
                //If it is view station exception then, redirect to logout page
                if ((HttpContext.Current.Error.InnerException != null && HttpContext.Current.Error.InnerException.GetType() == typeof(ViewStateException)) || HttpContext.Current.Error.Message.Equals(Constants.ERR_SESSION_TIME_OUT))
                {
                    HttpContext.Current.ClearError();
                    Response.Redirect(String.Format(ConfigurationManager.AppSettings["SSOTimeOutUrl"].ToString(), Request.Url.Authority), false);
                    return;
                }
                else
                {
                    
                }
            }
            HttpContext.Current.ClearError();
            Response.Redirect(string.Format(Constants.TIMEOUT_URL, "apperror"), false);
        }


    

    

        /// <summary>
        /// The enumeration values will be load into the combo box havind the given Id.
        /// </summary>
        /// <param name="dropDownList">Object of the drop down list need to populate</param>
        /// <param name="enumType">type of the enumeration need to load into combo box</param>
        protected virtual void LoadComboFromEnum(DropDownList dropDownList, Type enumType)
        {
            dropDownList.DataSource = Common.GetEnumDictionary(enumType);
            dropDownList.DataValueField = "Key";
            dropDownList.DataTextField = "Value";
            dropDownList.DataBind();
        }

        

        /// <summary>
        /// ShowErrorPage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        protected virtual void ShowErrorPage()
        {
            throw new Exception(string.Empty);
        }




        public Common.MessageEventArgs _msgEventArgs { get; set; }
    }
}
