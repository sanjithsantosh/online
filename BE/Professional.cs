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

    public class Professional
    {
        #region [CONSTRUCTOR]

        /// <summary>
        /// Constructor
        /// </summary>
        public Professional()
        {
            totexp = 0;
            PrevEmp = string.Empty;
            PrevDesgn = string.Empty;
            PrevRsnLvng = string.Empty;
            PrevRles = string.Empty;
            CrntEmp = string.Empty;
            CrntDesgn = string.Empty;
            CrntRsnLvng = string.Empty;
            CrntRles = string.Empty;
            CrntSlry = 0;
            ExpctSlry = 0; 
        }

        #endregion

        #region [PROPERTY]

        /// <summary>
        /// Total Experience
        /// </summary>
        public int totexp { get; set; }

        /// <summary>
        /// Previous Employer
        /// </summary>
        public string PrevEmp { get; set; }

        /// <summary>
        /// Previous Designation
        /// </summary>
        public string PrevDesgn { get; set; }

        /// <summary>
        /// Previous Reason for leaving
        /// </summary>
        public string PrevRsnLvng { get; set; }

        /// <summary>
        /// Previous Roles/Responsibilities
        /// </summary>
        public string PrevRles { get; set; }




        /// <summary>
        /// Current Employer
        /// </summary>
        public string CrntEmp { get; set; }

        /// <summary>
        /// Current Designation
        /// </summary>
        public string CrntDesgn { get; set; }

        /// <summary>
        /// Current Reason for leaving
        /// </summary>
        public string CrntRsnLvng { get; set; }

        /// <summary>
        /// Current Roles/Responsibilities
        /// </summary>
        public string CrntRles { get; set; }

        /// <summary>
        /// Current Salary
        /// </summary>
        public int CrntSlry { get; set; }


        /// <summary>
        /// Expected Salary 
        /// </summary>
        public int ExpctSlry { get; set; }




        /// <summary>
        /// Previous From Date
        /// </summary>
        public DateTime? PrvFrmDate { get; set; }

        /// <summary>
        /// Previous To Date
        /// </summary>
        public DateTime? PrvToDate { get; set; }

        /// <summary>
        /// Current To Date
        /// </summary>
        public DateTime? CrntFrmDate { get; set; }




        #endregion

    }

}
