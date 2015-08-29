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
using System.Text;

namespace PL.Amgra
{
    public static class AmgraCommon
    {
        public static string GetNotificationMessage(NotifyType type, string message)
        {
            StringBuilder _NotificationText = null;

            if (!string.IsNullOrEmpty(message))
            {
                _NotificationText = new StringBuilder();
                _NotificationText.Append("<a class=\"tooltip IconStyle\" href=\"#\">");
                if (type == NotifyType.Info)
                {
                    _NotificationText.Append("i");
                    _NotificationText.Append("<span class=\"custom info\"><img class=\"Large\" src=\"" + HttpContext.Current.Session[BE.Common.Constants.STYLE_THEME_ROOT] + "images/Info.png\" alt=\"Information\" height=\"48\" width=\"48\" /><em>Information</em>" + message + "</span>");
                }
                else if (type == NotifyType.Warning)
                {
                    _NotificationText.Append("<img src=\"" + HttpContext.Current.Session[BE.Common.Constants.STYLE_THEME_IMG_ROOT] + "Warning_s.jpg\" />");
                    _NotificationText.Append("<span class=\"custom warning\"><img class=\"Large\" src=\"" + HttpContext.Current.Session[BE.Common.Constants.STYLE_THEME_ROOT] + "images/Warning.png\" alt=\"Warning\" height=\"48\" width=\"48\" /><em>Warning</em>" + message + "</span>");
                }
                else if (type == NotifyType.Help)
                {
                    _NotificationText.Append("<img src=\"" + HttpContext.Current.Session[BE.Common.Constants.STYLE_THEME_IMG_ROOT] + "Help_s.jpg\" />");
                    _NotificationText.Append("<span class=\"custom help\"><img class=\"Large\" src=\"" + HttpContext.Current.Session[BE.Common.Constants.STYLE_THEME_ROOT] + "images/Help.png\" alt=\"Help\" height=\"48\" width=\"48\" /><em>Help</em>" + message + "</span>");
                }
                else if (type == NotifyType.Classic)
                {
                    _NotificationText.Append("i");
                    _NotificationText.Append("<span class=\"custom info\">" + message + "</span>");
                }
                _NotificationText.Append("</a>");
            }
            return (_NotificationText == null) ? string.Empty : _NotificationText.ToString();
        }
    }

    #region enum:ListViewMode
    /// <summary>
    /// 
    /// </summary>
    public enum ListViewMode
    {
        Insert = 0,
        //Update = 1,
        ReadOnly = 2
    }
    #endregion

    public enum TextBoxInputType
    {
        Numeric = 0,
        AlphaNumeric = 1,
        CustomRegEx = 2,
        DatePicker = 3,
        AutoComplete = 4,
        Currency = 5,
    }

    public enum DatePickerAnimation
    {
        Appear = 0,
        Blind = 1,
        Bounce = 2,
        Clip = 3,
        Drop = 4,
        FadeIn = 5,
        Fold = 6,
        Show = 7,
        Slide = 8,
        SlideDown = 9
    }

    public enum NotifyType
    {
        Classic = 0,
        Info = 1,
        Warning = 2,
        Help = 3
    }

    public enum SourceType
    {
        Enumeration = 0,
        Sequence = 1,
        MasterEntity = 2,

        /// <summary>
        /// You should set the XmlFileCode property as well 
        /// </summary>
        Xml = 6,
        ConstantRole = 3,
        ConstantDefaultIO = 5,
        ConstantRate = 4
    }

    public enum Enumerations
    {
        RequestStatus = 1,
        RequestType = 2,
        SegmentStatus = 3
    }

    public enum XmlFileCode
    {
        /// <summary>
        /// You should add an XMl file (XmlDataSource_FLT.xml) in App_Data folder 
        /// </summary>
        Modules = 0,
        FLT = 1,
        FLTToolTip = 2
    }
}