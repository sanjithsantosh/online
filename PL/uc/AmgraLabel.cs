using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Text;
using System.Web;
using System;

namespace PL.Amgra
{
    public class AmgraLabel : Label
    {
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

        #region ToolTipID
        /// <summary>
        /// Gets or sets the ToolTipID
        /// </summary>
        public string ToolTipID
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
    }
}
