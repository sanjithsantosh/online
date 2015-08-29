// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       : 

namespace BE.Common
{
    /// <summary>
    /// Static Class for Constant values
    /// </summary>
    public static class Constants
    {
        public const string PAGE_TITLE = "Online CV";
        public const string USER_SESSION = "User";
        public const string DEFAULT_PAGE = "~/PersonalDetails.aspx";
        public const string LOGIN_PAGE = "~/Login.aspx";
        public const string REG_PAGE = "~/Register.aspx";




        public const string PERS_PAGE = "~/PersonalDetails.aspx";
        public const string ED_PAGE = "~/EducationalDetails.aspx";
        public const string PROF_PAGE = "~/ProfessionalDetails.aspx";
        public const string CERT_PAGE = "~/CertificationDetails.aspx";


        public const string USER_ACCESS_SESSION = "UserAccess";
        public const string ERR_AMGRA_DATA_LOAD = "Unabale to load data to the control.";
        public const string ERR_SESSION_TIME_OUT = "SESSION TIME OUT";
        //Time out
        public const string TIMEOUT_URL = "~/TimeOut.aspx?mode={0}";
        public const string ERR_ACCESS_DENIED = "Access denied : [UserId:{0},Name:{1},URL:{2}].";
        public const string ERR_MSG_ACCESS_DENIED = "You do not have the permission to access the page.";
        public const string ERR_ADD_REQUEST_DATA = "Unable to create the request due to a problem encountered while adding a new record into the database. ";



        public const string SUCC_REG= "User Registered Successfully. ";
        public const string ALRD_REG = "User Already Registered ";
        public const string SUCC_LOG = "User Logged in Successfully. ";
        public const string ERR_LOG = "Not a valid user.";


        public const string STYLE_THEME = "THEME";
        public const string STYLE_THEME_ROOT = "THEME_ROOT";
        public const string STYLE_THEME_IMG_ROOT = "THEME_IMG_ROOT";
    }
}
