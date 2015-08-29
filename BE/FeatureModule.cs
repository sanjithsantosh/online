// Date Created             : February 18, 2011 
// Author                   : TCS, DCFE Offshore
// 
// Change History
//
// Date Modified            : February 18, 2011
// Changed By               : TCS, DCFE Offshore
// Change Description       : Created 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmericanExpress.PaUi.BE.Common;

namespace AmericanExpress.PaUi.BE
{
    /// <summary>
    /// This class is for featured association
    /// </summary>
    public class FeaturedAssociation : Base
    {

        /// <summary>
        /// Role Id
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Role Type
        /// </summary>
        public string RoleType 
        {
            get
            {
                // If Role Id = 001 - Primary , 002 - Secondary
                return (RoleId.Equals(Constants.CODE_PRIMARY_ROLE) ? "Primary" : (RoleId.Equals(Constants.CODE_SECONDARY_ROLE) ? "Secondary" : string.Empty));
            }
        }

        /// <summary>
        /// Effective Date
        /// </summary>
        public DateTime EffectiveDate{ get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime EndDate{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BE.Sequence CAS { get; set; }

        /// <summary>
        /// PLT
        /// </summary>
        public BE.Sequence PLT { get; set; }

        /// <summary>
        /// PLT
        /// </summary>
        public BE.Sequence SuppProduct { get; set; }

        /// <summary>
        /// Request Id
        /// </summary>
        public int RequestID{ get; set; }

        /// <summary>
        /// IA Code
        /// </summary>
        public string IACode{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IADecsription{ get; set; }

        /// <summary>
        /// IA Description
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// IA Description
        /// </summary>
        public string ProductCode{ get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        public string ProductDescription{ get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int PCNId { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public string PCNCode { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int ChangeTrackId { get; set; }
        
        /// <summary>
        /// Id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public RequestStatus  Status { get; set; }
    }
}
