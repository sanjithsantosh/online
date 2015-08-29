// Date Created             : April 10, 2011 
// Author                   : TCS, DCFE Offshore
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       :  

using System;
namespace AmericanExpress.PaUi.BE
{
    /// <summary>
    /// Class for Product
    /// </summary>
    [Serializable] 
    public class Product
    {
        #region [CONSTRUCTOR]

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="code"></param>
        /// <param name="description"></param>
        /// <param name="iaId"></param> 
        /// <param name="iaCode"></param>
        /// <param name="iaDescription"></param>
        public Product(int id, string code, string description, int iaId, string iaCode, string iaDescription)
        {
            ID = id;
            Code = code;
            Description = description;
            IAID = iaId;
            IACode = iaCode ;
            IADescription = iaDescription ;
        }

        #endregion

        #region [PROPERTY]

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string  Code { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Full Description
        /// </summary>
        public string FullDescription 
        {
            get { return string.Concat(Description, (string.IsNullOrEmpty(Code) ? string.Empty : " - "), Code); }  
                    
        }

        /// <summary>
        /// ID
        /// </summary>
        public int IAID { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string IACode { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string IADescription { get; set; }

        /// <summary>
        /// Full Description
        /// </summary>
        public string FullIADescription
        {
            get { return string.Concat(IADescription, (string.IsNullOrEmpty(IACode) ? string.Empty : " - "), IACode); }

        }

       #endregion
    }
}
