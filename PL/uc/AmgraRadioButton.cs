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
using System.Collections.Generic;
using System.ComponentModel;

namespace PL.Amgra
{
    /// <summary>
    /// 
    /// </summary>
    public class AmgraRadioButton : RadioButton
    {
        public AmgraRadioButton()
        {
            _Values = new List<ListItem>();
        }

        #region Value
        private string _Value = null;
        [Bindable(true)]
        public string Value
        {
            get
            {
                object _ValueViewState = ViewState[this.ClientID + "_Value"];
                if (_ValueViewState != null)
                {
                    return Convert.ToString(_ValueViewState);
                }
                else
                {
                    return _Value;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_Value"] = _Value = value;
            }
        }
        #endregion

        #region Values
        private List<ListItem> _Values = null;
        [Bindable(true)]
        public List<ListItem> Values
        {
            get
            {
                object _ValuesViewState = ViewState[this.ClientID + "_Values"];
                if (_ValuesViewState != null)
                {
                    return (List<ListItem>)(_ValuesViewState);
                }
                else
                {
                    return _Values;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_Values"] = _Values = value;
            }
        }
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                writer.AddAttribute("Value", Value);
            }
            else
            {
                for (int i = 0; i < Values.Count; i++)
                {
                    writer.AddAttribute(Values[i].Text, Values[i].Value);
                }
            }

            base.Render(writer);
        }
    }
}
