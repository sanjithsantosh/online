// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       :  : 

using System;
using BE.Common;
using BE;

namespace PL
{
    /// <summary>
    /// Default page
    /// </summary>
    public partial class _Default : BasePage
    {
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            Server.Transfer(Constants.DEFAULT_PAGE);
            //Response.Redirect(Constants.DEFAULT_PAGE);


        }
    }
}
