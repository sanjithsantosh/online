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
    /// <summary>
    /// 
    /// </summary>
    public class AmgraTextBox : TextBox
    {
        #region InputType
        /// <summary>
        /// Get or sets input type of the text box
        /// </summary>
        public TextBoxInputType InputType
        {
            get;
            set;
        }
        #endregion

        #region AllowBlank
        /// <summary>
        /// Get or sets whether the control allows blank vaule or not.
        /// </summary>
        public bool AllowBlank
        {
            get;
            set;
        }
        #endregion

        #region AttachedJavaScript
        /// <summary>
        /// Get or sets whether the control need to automatically bind the javascript next to where the control appearing in the page. 
        /// </summary>
        public bool AttachedJavaScript
        {
            get;
            set;
        }
        #endregion

        #region DtFormat
        /// <summary>
        /// Get or sets format of the date
        /// </summary>
        [DefaultSettingValue("mm/dd/yy")]
        public string DtFormat
        {
            get;
            set;
        }
        #endregion

        #region DtMin
        /// <summary>
        /// Get or sets minimum date can be enter
        /// e.g: -20, +1M +10D, 04/13/2011 etc
        /// </summary>
        public string DtMin
        {
            get;
            set;
        }
        #endregion

        #region DtMax
        /// <summary>
        /// Get or sets maximum date can be enter
        /// e.g: -20, +1M +10D, 04/13/2011 etc
        /// </summary>
        public string DtMax
        {
            get;
            set;
        }
        #endregion

        #region CustomRegEx
        /// <summary>
        /// Get or sets custom reg expression
        /// </summary>
        public string CustomRegEx
        {
            get;
            set;
        }
        #endregion

        #region DtDefault
        /// <summary>
        /// Get or sets default date
        /// e.g: -20, +7 etc
        /// </summary>
        [DefaultSettingValue("0")]
        public int DtDefault
        {
            get;
            set;
        }
        #endregion

        #region DtPickerOnly
        /// <summary>
        /// Get or sets whether the date input support only through
        /// </summary>
        public bool DtPickerOnly
        {
            get;
            set;
        }
        #endregion

        #region DtShowOnLoad
        /// <summary>
        /// Get or sets whether the calendar need to show on load of the page
        /// </summary>
        public bool DtShowOnLoad
        {
            get;
            set;
        }
        #endregion

        #region DtShowTodayButton
        /// <summary>
        /// Get or sets whether button bar need to show or not
        /// </summary>
        public bool DtShowTodayButton
        {
            get;
            set;
        }
        #endregion

        #region DtShowMonthMenu
        /// <summary>
        /// Get or sets whether month menu need to show or not
        /// </summary>
        public bool DtShowMonthMenu
        {
            get;
            set;
        }
        #endregion

        #region DtShowYearMenu
        /// <summary>
        /// Get or sets whether year menu need to show or not
        /// </summary>
        public bool DtShowYearMenu
        {
            get;
            set;
        }
        #endregion

        #region DtShowDatesInOtherMonths
        /// <summary>
        /// Get or sets whether the dates in other months need to show or not
        /// </summary>
        public bool DtShowDatesInOtherMonths
        {
            get;
            set;
        }
        #endregion

        #region DtNoOfMonthsInView
        private int _DtNoOfMonthsInView = 1;
        /// <summary>
        /// Get or sets how many months need to show in the calendar
        /// </summary>
        public int DtNoOfMonthsInView
        {
            get
            {
                return _DtNoOfMonthsInView;
            }
            set
            {
                _DtNoOfMonthsInView = value;
            }
        }
        #endregion
        
        #region DtAnimationType
        /// <summary>
        /// Get or sets the type of the animation while showing the date picker
        /// </summary>
        public DatePickerAnimation DtAnimationType
        {
            get;
            set;
        }
        #endregion

        #region DtRangeControlID
        /// <summary>
        /// Get or sets control id of the date to control
        /// </summary>
        public string DtRangeControlID
        {
            get;
            set;
        }
        #endregion

        #region WaterMarkText
        /// <summary>
        /// Get or sets water mark text of the text box. This text will be cleared on focus and shown again when leave as blank.
        /// </summary>
        public bool WaterMarkText
        {
            get;
            set;
        }
        #endregion

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

        #region WaterMarkCssClass
        /// <summary>
        /// Get or sets css class need to given for water mark text
        /// </summary>
        public bool WaterMarkCssClass
        {
            get;
            set;
        }
        #endregion

        #region NumMin
        /// <summary>
        /// Get or sets minimum numeric value support by Numeric Type text box
        /// </summary>
        public int NumMin
        {
            get;
            set;
        }
        #endregion

        #region NumMax
        /// <summary>
        /// Get or sets maximum numeric value support by Numeric Type text box
        /// </summary>
        public int NumMax
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (InputType == TextBoxInputType.DatePicker)
            {
                DtPickerOnly = true;
                DtShowTodayButton = true;
                DtShowYearMenu = true;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(this.ID)) writer.AddAttribute("Id", this.ClientID);
            if (InputType == TextBoxInputType.DatePicker)
            {
                if (string.IsNullOrEmpty(this.Text) && DtDefault != 0)
                {
                    this.Text = DateTime.Now.AddDays(DtDefault).ToString(DtFormat.Replace("yy", "yyyy").Replace("mm", "MM"));
                }                
            }
            
            if (DtPickerOnly)
            {
                writer.AddAttribute("readonly", "readonly");
                writer.AddAttribute("autocomplete", "off");
            }

            //if (InputType != TextBoxInputType.DatePicker && !this.Enabled)
            //{
            //    writer.Write(this.Text);
            //    return;
            //}

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

            if(AttachedJavaScript) writer.Write(GetAttachedJavaScript());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetAttachedJavaScript()
        {
            StringBuilder _JavaScript = new StringBuilder();
            _JavaScript.Append("<script language=\"javascript\" type=\"text/javascript\">$(document).ready(function() {");

            switch(InputType)
            {
                case TextBoxInputType.DatePicker:
                    _JavaScript.Append(getDatePickerJS());
                    break;
                case TextBoxInputType.Numeric:
                    _JavaScript.Append(getNumericJS());
                    break;
                case TextBoxInputType.AlphaNumeric:
                    _JavaScript.Append(getAlphaNumericJS());                    
                    break;
            }
            _JavaScript.Append("});</script>");
            return _JavaScript.ToString();
        }
        
        // KeyCode: http://www.aspdotnetfaq.com/Faq/What-is-the-list-of-KeyCodes-for-JavaScript-KeyDown-KeyPress-and-KeyUp-events.aspx
        private string getAlphaNumericJS()
        { 
            StringBuilder _JavaScript = new StringBuilder();
            _JavaScript.Append("$('#" + this.ClientID + "').bind('focusout',function(){FilterAlphaNumeric(this);});");
            _JavaScript.Append("$('#" + this.ClientID + "').keydown(function(e){var key = e.charCode || e.keyCode || 0; return (key == 8 || key == 9 || key == 32 || key == 46 || (key >= 35 && key <= 40) || (key >= 48 && key <= 90) || key == 52 || key == 53 || key == 55 || (key >= 96 && key <= 105) || key == 107 || key == 109 || key == 187|| key == 189 || key == 190 || key == 191 );});");
            
            return _JavaScript.ToString();
        }

        private string getNumericJS()
        { 
            StringBuilder _JavaScript = new StringBuilder();
            _JavaScript.Append("$('#" + this.ClientID + "').bind('focusout',function(){FilterNumeric(this);});");
            _JavaScript.Append("$('#" + this.ClientID + "').keydown(function(e){var key = e.charCode || e.keyCode || 0; return (key == 8 || key == 9 || key == 46 || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105));});");
            
            return _JavaScript.ToString();
        }

        private string getDatePickerJS()
        {
            StringBuilder _JavaScript = new StringBuilder();
            _JavaScript.Append(((!string.IsNullOrEmpty(DtRangeControlID)) ? "var dates = " : "" ) + "$(\"#" + this.ClientID +  ((!string.IsNullOrEmpty(DtRangeControlID)) ? ", #" + this.ClientID.Replace(this.ID, DtRangeControlID) : "")  + "\").datepicker({");
            _JavaScript.Append("currentText:'Today'");
            _JavaScript.Append(",numberOfMonths:" + DtNoOfMonthsInView + "");
            _JavaScript.Append((string.IsNullOrEmpty(DtRangeControlID)) ? "" : ",onSelect: function( selectedDate ) {var option = this.id == \"" + this.ClientID + "\" ? \"minDate\" : \"maxDate\",instance = $( this ).data( \"datepicker\" ),date = $.datepicker.parseDate(instance.settings.dateFormat || $.datepicker._defaults.dateFormat,selectedDate, instance.settings );dates.not( this ).datepicker( \"option\", option, date );}");
            _JavaScript.Append(",showAnim:\"" + getDatePickerAnimationValue(DtAnimationType) + "\"");
            _JavaScript.Append((string.IsNullOrEmpty(DtFormat)) ? "" : string.Format(",dateFormat:'{0}'", DtFormat));
            _JavaScript.Append((string.IsNullOrEmpty(DtMin)) ? "" : string.Format(",minDate:'{0}'", DtMin));
            _JavaScript.Append((string.IsNullOrEmpty(DtMax)) ? "" : string.Format(",maxDate:'{0}'", DtMax));
            _JavaScript.Append((DtDefault != 0) ? "" : string.Format(",defaultDate:'{0}'", DtDefault));
            _JavaScript.Append((DtShowTodayButton) ? string.Format(",showButtonPanel:'true'") : "");
            _JavaScript.Append((DtShowMonthMenu) ? string.Format(",changeMonth:'true'") : "");
            _JavaScript.Append((DtShowYearMenu) ? string.Format(",changeYear:'true'") : "");
            _JavaScript.Append((DtShowDatesInOtherMonths) ? string.Format(",showOtherMonths:'true', selectOtherMonths:'true'") : "");            
            _JavaScript.Append("});");
            if (DtShowOnLoad) _JavaScript.Append("$(\"#" + this.ClientID + "\").datepicker(\"show\")");
            
            return _JavaScript.ToString();
        }

        private string getDatePickerAnimationValue(DatePickerAnimation datePickerAnimation)
        {
            if (datePickerAnimation == DatePickerAnimation.Appear) return "";

            return Enum.GetName(typeof(DatePickerAnimation), datePickerAnimation).ToLower();
        }
    }
}
