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
using BE.Common;
namespace BE
{
    /// <summary>
    /// This class is for Personal Details
    /// </summary>

    public class Login
    {
        #region [CONSTRUCTOR]

        /// <summary>
        /// Constructor
        /// </summary>
        public Login()
        {
            Uname = string.Empty;
            Pswd = string.Empty;
            Email = string.Empty;
        }

        #endregion

        #region [PROPERTY]

        /// <summary>
        /// First Name
        /// </summary>
        public string Uname { get; set; }

        /// <summary>
        /// Second Name
        /// </summary>
        public string Pswd { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        #endregion

    }

}
