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

    public class Personal
    {
        #region [CONSTRUCTOR]

        /// <summary>
        /// Constructor
        /// </summary>
        public Personal()
        {
            FName = string.Empty;
            SName = string.Empty;
            LName = string.Empty;
            Gender = string.Empty;
            Nat = string.Empty;
            RAdd1 = string.Empty;
            RAdd2 = string.Empty;
            Rcty = string.Empty;
            RPcode = 0;
            CAdd1 = string.Empty;
            CAdd2 = string.Empty;
            Ccty = string.Empty;
            CPcode = 0;
            PNmbr = 0;
            HNmbr = 0;
            MNmbr = 0;
            EmailID1 = string.Empty;
            EmailID2 = string.Empty;
        }

        #endregion

        #region [PROPERTY]

        /// <summary>
        /// First Name
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// Second Name
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LName { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        public string Nat { get; set; }

        /// <summary>
        /// Resident Adress1
        /// </summary>
        public string RAdd1 { get; set; }

        /// <summary>
        /// Resident Adress2
        /// </summary>
        public string RAdd2 { get; set; }

        /// <summary>
        /// Resident City
        /// </summary>
        public string Rcty { get; set; }

        /// <summary>
        /// Resident CCode
        /// </summary>
        public int RPcode { get; set; }

        /// <summary>
        /// Current Adress1
        /// </summary>
        public string CAdd1 { get; set; }

        /// <summary>
        /// Current Adress2
        /// </summary>
        public string CAdd2 { get; set; }

        /// <summary>
        /// Current City
        /// </summary>
        public string Ccty { get; set; }

        /// <summary>
        /// Current CCode
        /// </summary>
        public int CPcode { get; set; }

        /// <summary>
        /// Primary Number
        /// </summary>
        public int PNmbr { get; set; }

        /// <summary>
        /// Home Number
        /// </summary>
        public int HNmbr { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        public int MNmbr { get; set; }

        /// <summary>
        /// Resident City
        /// </summary>
        public string EmailID1 { get; set; }

        /// <summary>
        /// Resident City
        /// </summary>
        public string EmailID2 { get; set; }

        #endregion

    }

}
