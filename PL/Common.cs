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
using System.Collections.Generic;
using BE;

namespace PL
{
    /// <summary>
    /// For common taks
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Get Enum List
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumDictionary(Type enumType)
        {
            if (enumType == null) return null;

            Array _valueArray = System.Enum.GetValues(enumType);

            Dictionary<int, string> _enumDictionary = new Dictionary<int, string>();
            //_enumDictionary.Add(0, string.Empty);

            for (int i = 0; i < _valueArray.Length; i++)
            {
                string _value = _valueArray.GetValue(i).ToString();
                if (_value.ToUpper().Equals("NONE"))
                {
                    _value = string.Empty;
                }
                object c = Enum.Parse(enumType, _valueArray.GetValue(i).ToString(), true);
                _enumDictionary.Add(Convert.ToInt32(c), _value);
            }

            return _enumDictionary;
        }

        #region Custom Events

        public delegate void ShowMessageEventHandler(object sender, MessageEventArgs e);
        /// <summary>
        /// The event will raise if the user try to show a message in the page. The message will have the
        /// pre-defined style and position
        /// </summary>
        public static event ShowMessageEventHandler ShowMessage;

        /// <summary>
        /// Show Message Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnShowMessage(object sender, MessageEventArgs e)
        {
            if (ShowMessage != null) ShowMessage(sender, e);
        }

        #endregion

        #region Common Methods

        /// <summary>
        /// Days difference
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static int DaysDifference(DateTime date1, DateTime date2)
        {
            date1 = Convert.ToDateTime(date1.ToShortDateString());
            date2 = Convert.ToDateTime(date2.ToShortDateString());

            return (date1.Subtract(date2).Days);
        }

        /// <summary>
        /// Days difference
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static int DaysDifference(DateTime date1, DateTime? date2)
        {
            date1 = Convert.ToDateTime(date1.ToShortDateString());
            DateTime _newDate2 = Convert.ToDateTime(Convert.ToDateTime(date2).ToShortDateString());

            return DaysDifference(date1, _newDate2);
        }

        /// <summary>
        /// Days difference
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static int DaysDifference(DateTime? date1, DateTime date2)
        {
            DateTime _newDate1 = Convert.ToDateTime(Convert.ToDateTime(date1).ToShortDateString());
            date2 = Convert.ToDateTime(date2.ToShortDateString());

            return DaysDifference(_newDate1, date2);
        }

        /// <summary>
        /// Days difference
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static int DaysDifference(DateTime date1, string date2)
        {
            date1 = Convert.ToDateTime(date1.ToShortDateString());
            DateTime _newDate2 = Convert.ToDateTime(Convert.ToDateTime(date2).ToShortDateString());

            return DaysDifference(date1, _newDate2);
        }

        /// <summary>
        /// Days difference
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static int DaysDifference(DateTime? date1, DateTime? date2)
        {
            DateTime _newDate1 = Convert.ToDateTime(Convert.ToDateTime(date1).ToShortDateString());
            DateTime _newDate2 = Convert.ToDateTime(Convert.ToDateTime(date2).ToShortDateString());

            return DaysDifference(_newDate1, _newDate2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date1">The base date</param>
        /// <param name="date2">The date need to substract from the date1</param>
        /// <param name="baseHour">The base hour need to set for date1. The hours 0 through 23</param>
        /// <returns>Number of </returns>
        public static int DaysDifference(DateTime? date1, DateTime? date2, int baseHour)
        {            
            DateTime _newTemp = Convert.ToDateTime(Convert.ToDateTime(date1).ToShortDateString());
            DateTime _newDate1 = new DateTime(_newTemp.Year, _newTemp.Month, _newTemp.Day, baseHour, 0, 0, 0);

            DateTime _newDate2 = Convert.ToDateTime(Convert.ToDateTime(date2).ToShortDateString());
            return (_newDate1.Subtract(_newDate2).Days);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date1">The base date</param>
        /// <param name="date2">The date need to substract from the date1</param>
        /// <param name="baseHour">The base hour need to set for date1. The hours 0 through 23</param>
        /// <returns>Number of </returns>
        public static int DaysDifference(DateTime? date1, DateTime date2, int baseHour)
        {            
            DateTime _newTemp = Convert.ToDateTime(Convert.ToDateTime(date1).ToShortDateString());
            DateTime _newDate1 = new DateTime(_newTemp.Year, _newTemp.Month, _newTemp.Day, baseHour, 0, 0, 0);

            DateTime _newDate2 = Convert.ToDateTime(date2.ToShortDateString());
            return (_newDate1.Subtract(_newDate2).Days);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date1">The base date</param>
        /// <param name="date2">The date need to substract from the date1</param>
        /// <param name="baseHour">The base hour need to set for date1. The hours 0 through 23</param>
        /// <returns>Number of </returns>
        public static int DaysDifference(DateTime date1, DateTime? date2, int baseHour)
        {            
            DateTime _newTemp = Convert.ToDateTime(date1.ToShortDateString());
            DateTime _newDate1 = new DateTime(_newTemp.Year, _newTemp.Month, _newTemp.Day, baseHour, 0, 0, 0);

            DateTime _newDate2 = Convert.ToDateTime(Convert.ToDateTime(date2).ToShortDateString());
            return (_newDate1.Subtract(_newDate2).Days);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date1">The base date</param>
        /// <param name="date2">The date need to substract from the date1</param>
        /// <param name="baseHour">The base hour need to set for date1. The hours 0 through 23</param>
        /// <returns>Number of </returns>
        public static int DaysDifference(DateTime date1, DateTime date2, int baseHour)
        {            
            DateTime _newTemp = Convert.ToDateTime(date1.ToShortDateString());
            DateTime _newDate1 = new DateTime(_newTemp.Year, _newTemp.Month, _newTemp.Day, baseHour, 0, 0, 0);

            DateTime _newDate2 = Convert.ToDateTime(date2.ToShortDateString());
            return (_newDate1.Subtract(_newDate2).Days);
        }
        
        /// <summary>
        /// Trimmed Data
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static string GetTrimData(string val)
        {
            if (string.IsNullOrEmpty(val)) return string.Empty;
            return val.ToString().Trim();
        }


        /// <summary>
        /// Trimmed Data
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static int GetTrimData(string val, int defVal)
        {
            if (string.IsNullOrEmpty(val)) return defVal;
            return Convert.ToInt32(val.ToString().Trim());
        }

        /// <summary>
        /// Trimmed Data
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static DateTime GetTrimData(string val, DateTime defVal)
        {
            if (string.IsNullOrEmpty(val)) return defVal;
            return Convert.ToDateTime(val.ToString().Trim());
        }

        /// <summary>
        /// Trimmed Data
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static DateTime? GetTrimData(string val, DateTime? defVal)
        {
            if (string.IsNullOrEmpty(val)) return defVal;
            return Convert.ToDateTime(val.ToString().Trim());
        }

        #endregion


        /// <summary>
        /// Custom EventArg class supporting sorting params
        /// </summary>
        public class MessageEventArgs : EventArgs
        {
            public string Message { get; set; }
            public MessageType MessageType { get; set; }

            public MessageEventArgs() { }
            public MessageEventArgs(string message, MessageType messageType)
            {
                Message = message;
                MessageType = messageType;
            }
        }



    }
}