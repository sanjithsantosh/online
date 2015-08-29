// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       :  :   

using System;
using System.Configuration;
using BE.Common;
using BE;
using System.Web.UI.WebControls;

namespace PL
{
    /// <summary>
    /// Master Page
    /// </summary>
    public partial class Default : System.Web.UI.MasterPage
    {
        public string GlobalLinkPrefix = string.Empty;
        public string StyleFolder = "theme_01";

        /// <summary>
        /// Page Initialize 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            // Setting the virtual directory path
            #if !DEBUG
                GlobalLinkPrefix = Request.ApplicationPath ;
            #endif

            if (!Page.IsPostBack)
            {
                Page.Title = Constants.PAGE_TITLE;
                User _user = null;
                if (Session[Constants.USER_SESSION] != null)
                {
                    _user = (User)Session[Constants.USER_SESSION];
                }


                Session[Constants.STYLE_THEME] = StyleFolder;
                Session[Constants.STYLE_THEME_ROOT] = GlobalLinkPrefix + "/css/" + StyleFolder + "/";
                Session[Constants.STYLE_THEME_IMG_ROOT] = GlobalLinkPrefix + "/img/" + StyleFolder + "/";
            }
        }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            divMessage.Visible = false;
            divMessage.InnerHtml = string.Empty;
        }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.Cache.Remove(Constants.CACHE_LDAP_USERS);
            Session[Constants.USER_SESSION] = null;
            Session.Abandon();
            Response.Redirect(Constants.DEFAULT_PAGE, false);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.LOGIN_PAGE, false);
        }



        }

 }
    

