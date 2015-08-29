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
using System.Linq;
using BE;

namespace BE
{
    /// <summary>
    /// User Class
    /// </summary>
    [Serializable]
    public sealed class User {
        #region [CONSTRUCTOR]

        /// <summary>
        /// Default Constructor
        /// </summary>
        public User()
        {
            ID = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
        }

        #endregion

        #region [PROPERTY]

        /// <summary>
        /// Get or Set the GUID of the user
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Get or Set the first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get or Set the Middle name of the user
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Get or Set the last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// get the full name (first name + last name) of the user
        /// </summary>
        public string FullName
        {
            get { return string.Concat(LastName, (string.IsNullOrEmpty(LastName) ? string.Empty : ", "), FirstName); }
        }

        /// <summary>
        /// Get or Set the email id of the user
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// Created Time
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Updated Time
        /// </summary>
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}
