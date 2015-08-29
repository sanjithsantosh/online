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
using System.ComponentModel;
using BE;
using System.Collections.Generic;
using System.Web.Caching;

namespace PL.Amgra
{
    /// <summary>
    /// 
    /// </summary>
    public class AmgraDropDownList : DropDownList
    {

        #region IsMandatory
        /// <summary>
        /// Get or sets whether the field is a required field or not 
        /// </summary>
        public bool IsMandatory
        {
            get;
            set;
        }
        #endregion

        #region ClearPageLevelCacheOnLoad
        /// <summary>
        /// Get or sets the whether the page level cache object need to clear on page request(IsPostback = false)
        /// </summary>
        public bool ClearPageLevelCacheOnLoad
        {
            get;
            set;
        }
        #endregion

        #region EnablePageLevelCache
        /// <summary>
        /// Get or sets whether the master data resultset need to cache at page level instead of control level. 
        /// This is for perfomance improvement at page level. Using this, same result set can be bind into different 
        /// drop down controls.
        /// </summary>
        public bool EnablePageLevelCache
        {
            get;
            set;
        }
        #endregion

        #region PageLevelCacheGroupCode
        /// <summary>
        /// Get or sets the group code for the page level cache. If it is null then the page will obly have ONE data source for all master data result set.
        /// If want more than one, then need to group controls using this group code. 
        /// </summary>
        public string PageLevelCacheGroupCode
        {
            get;
            set;
        }
        #endregion

        #region MasterDataListCacheName
        /// <summary>
        /// Get or sets the group code for the page level cache. If it is null then the page will obly have ONE data source for all master data result set.
        /// If want more than one, then need to group controls using this group code. 
        /// </summary>
        public string MasterDataListCacheName
        {
            get
            {
                if (!EnablePageLevelCache) return string.Empty;
                return ((string.IsNullOrEmpty(PageLevelCacheGroupCode)) ? string.Empty : PageLevelCacheGroupCode) + "_MasterDataList";
            }
        }
        #endregion

        #region MasterDataListCacheName
        /// <summary>
        /// Get or sets the group code for the page level cache. If it is null then the page will obly have ONE data source for all master data result set.
        /// If want more than one, then need to group controls using this group code. 
        /// </summary>
        public string IOListCacheName
        {
            get
            {
                if (!EnablePageLevelCache) return string.Empty;
                return ((string.IsNullOrEmpty(PageLevelCacheGroupCode)) ? string.Empty : PageLevelCacheGroupCode) + "_IOList";
            }
        }
        #endregion

        #region LoadOnlyWithFilter
        /// <summary>
        /// Get or sets whether the items load only if assign a valid filter or not
        /// </summary>
        public bool LoadOnlyWithFilter
        {
            get;
            set;
        }
        #endregion

        #region Filter
        /// <summary>
        /// Get or sets the filter need to apply while loading the items
        /// e.g: product=C5W
        /// </summary>
        public string Filter
        {
            get;
            set;
        }
        #endregion

        #region FilterOptions
        private Dictionary<string, string> _FilterOptions = new Dictionary<string, string>();
        /// <summary>
        /// Get or sets the filters need to apply while loading the items
        /// e.g: product=C5W
        /// </summary>
        public Dictionary<string, string> FilterOptions
        {
            get
            {
                _FilterOptions.Clear();

                // Filter can be apply for the following only
                // PRODUCT
                if (!string.IsNullOrEmpty(Filter))
                {
                    string[] _filtersArr = Filter.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < _filtersArr.Length; i++)
                    {
                        string[] _filterOption = _filtersArr[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_filterOption.Length > 1)
                        {
                            _FilterOptions.Add(_filterOption[0].ToUpper().Trim(), _filterOption[1].Trim());
                        }
                    }
                }
                return _FilterOptions;
            }
            set
            {
                _FilterOptions = value;
            }
        }
        #endregion

        #region ReloadOnPostBack
        /// <summary>
        /// Get or sets whether the items need to reload on post back
        /// </summary>
        public bool ReloadOnPostBack
        {
            get;
            set;
        }
        #endregion

        #region Source
        /// <summary>
        /// Get or sets the data list source
        /// </summary>
        public SourceType Source
        {
            get;
            set;
        }
        #endregion

        #region EnumName
        /// <summary>
        /// Get or sets the enumeration name if the Source is 'Enumeration' 
        /// </summary>
        public Enumerations EnumName
        {
            get;
            set;
        }
        #endregion     

        #region XmlItemKey
        /// <summary>
        /// Gets or sets the Node Key if the Source = Xml and set the XmlSourceFileCode property
        /// </summary>
        public string XmlGroupKey
        {
            get;
            set;
        }
        #endregion

        #region XmlSourceFileCode
        /// <summary>
        /// Gets or sets the XmlSourceFileCode
        /// </summary>
        public XmlFileCode XmlSourceFileCode
        {
            get;
            set;
        }
        #endregion

        #region DefaultValue
        private string _DefaultValue;
        /// <summary>
        /// get or set the default value
        /// </summary>
        public string DefaultValue
        {
            get
            {
                object _DefaultValueViewState = ViewState[this.ClientID + "_DefaultValue"];
                if (_DefaultValueViewState != null)
                {
                    return _DefaultValueViewState.ToString();
                }
                else
                {
                    return _DefaultValue;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_DefaultValue"] = _DefaultValue = value;
            }
        }
        #endregion
        
        #region NotificationText
        /// <summary>
        /// Get or sets custom noification message related to the control/data
        /// </summary>
        public string NotificationText
        {
            get;
            set;
        }
        #endregion

        #region NotificationType
        /// <summary>
        /// Get or sets custom noification message related to the control/data
        /// </summary>
        public NotifyType NotificationType
        {
            get;
            set;
        }
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            if (this.Enabled == false && !string.IsNullOrEmpty(this.DefaultValue))
            {
                writer.Write(DefaultValue);
                return;
            }

            base.Render(writer);

            if (IsMandatory)
            {
                writer.Write(" <span class=\"req\">*</span>");
                writer.AddAttribute("mandatory", "mandatory");
            }

            if (!string.IsNullOrEmpty(NotificationText))
            {
                writer.Write(AmgraCommon.GetNotificationMessage(NotificationType, NotificationText));
            }
        }



    }
}