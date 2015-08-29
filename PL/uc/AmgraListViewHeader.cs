using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Text;
using System.Web;

namespace PL.Amgra
{
    public class AmgraListViewHeader : LinkButton
    {
        #region ColumnName
        /// <summary>
        /// Get or Set the column name of the header.
        /// </summary>
        public string ColumnName
        {
            get;
            set;
        }
        #endregion 

        #region Caption
        private string _Caption = null;
        /// <summary>
        /// Get or Set the static caption of the header.
        /// </summary>
        public string Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                _Caption = Text = value;
            }
        }
        #endregion 

        #region HelpText
        /// <summary>
        /// DON"T USE THIS
        /// </summary>
        public string HelpText
        {
            get;
            set;
        }
        #endregion 

        #region CssClass
        /// <summary>
        /// Get or Set the css class name of the header.
        /// </summary>
        public string CssClass
        {
            get;
            set;
        }
        #endregion 

        #region CssClassSortIcon
        /// <summary>
        /// Get or Set the css class name of the sort icon of the header.
        /// </summary>
        public string CssClassSortIcon
        {
            get;
            set;
        }
        #endregion 

        #region IsSortable
        /// <summary>
        /// Get or Set whether the header column is sortable or not.
        /// </summary>
        public bool IsSortable
        {
            get;
            set;
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
            writer.Write("<td class=\"TableHead\">");
            base.Render(writer);
            
            if (!string.IsNullOrEmpty(NotificationText))
            {
                writer.Write(AmgraCommon.GetNotificationMessage(NotificationType, NotificationText));
            }

            writer.Write("</td>");
        }
    }
}
