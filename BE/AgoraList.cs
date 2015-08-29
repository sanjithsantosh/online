// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       : 

using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace BE.Common
{
    /// <summary>
    /// Agora List 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class AgoraList<T> : List<T>
    {
        #region [PROPERTY]

        /// <summary>
        /// Total Items
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// The value will be true in case of the effective date of any record in the list is later than today.
        /// </summary>
        [DefaultValue(false)]
        public bool IsApprovalNotValid { get; set; }

        /// <summary>
        /// The value will be true in case of any failure of validation performed against records in the list.
        /// </summary>
        [DefaultValue(false)]
        public bool IsSubmitForApprovalNotValid { get; set; }

        /// <summary>
        /// The value will be true in case of any failure of validation performed against records in the list.
        /// </summary>
        [DefaultValue(false)]
        public bool IsSubmitforApprovalValid_TEMP { get; set; }

        #endregion
    }
}
