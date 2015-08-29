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

    public class Certification
    {
        #region [CONSTRUCTOR]

        /// <summary>
        /// Constructor
        /// </summary>
        public Certification()
        {
            Cert1 = string.Empty;
            Org1 = string.Empty;
            Cert2 = string.Empty;
            Org2 = string.Empty;
            Cert3 = string.Empty;
            Org3 = string.Empty;
        }

        #endregion

        #region [PROPERTY]

        /// <summary>
        /// Certification Name 1
        /// </summary>
        public string Cert1 { get; set; }

        /// <summary>
        /// Organisation Name 1
        /// </summary>
        public string Org1 { get; set; }

        /// <summary>
        /// Certification Name 2
        /// </summary>
        public string Cert2 { get; set; }

        /// <summary>
        /// Organisation Name 2
        /// </summary>
        public string Org2 { get; set; }

        /// <summary>
        /// Certification Name 3
        /// </summary>
        public string Cert3 { get; set; }

        /// <summary>
        /// Organisation Name 3
        /// </summary>
        public string Org3 { get; set; }

        /// <summary>
        /// Expiry Date 1
        /// </summary>
        public DateTime? ExpryDte1 { get; set; }

        /// <summary>
        /// Expiry Date 2
        /// </summary>
        public DateTime? ExpryDte2 { get; set; }

        /// <summary>
        /// Expiry Date 3
        /// </summary>
        public DateTime? ExpryDte3 { get; set; }

        #endregion

    }

}
