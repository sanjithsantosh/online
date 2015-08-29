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

    public class Educational
    {
        #region [CONSTRUCTOR]

        /// <summary>
        /// Constructor
        /// </summary>
        public Educational()
        {
            Institution = string.Empty;
            Country = string.Empty;
            MaDgree = string.Empty;
            ScndMjrDgree = string.Empty;
            MnrDgree = string.Empty;
            EdLvl = string.Empty;
            Hschl = string.Empty;
            GPA = 0;
        }

        #endregion

        #region [PROPERTY]

        /// <summary>
        /// First Name
        /// </summary>
        public string Institution { get; set; }

        /// <summary>
        /// Second Name
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string MaDgree { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string ScndMjrDgree { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        public string MnrDgree { get; set; }

        /// <summary>
        /// Resident Adress1
        /// </summary>
        public string EdLvl { get; set; }

        /// <summary>
        /// Resident Adress2
        /// </summary>
        public string Hschl { get; set; }

        /// <summary>
        /// Resident CCode
        /// </summary>
        public int GPA { get; set; }

     
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime? EndDate { get; set; }

        #endregion

    }

}
