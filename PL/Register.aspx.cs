// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       :  : 
using System;
using BE;
using BL;
using BE.Common;


namespace PL
{
    /// <summary>
    /// This page is for Register Details.
    /// </summary>
    public partial class Register : BasePage
    {
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
           
            }
        }

        /// <summary>
        /// Event for creating a request.
        /// </summary>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate
                if (!validate()) { return; }

                BE.Login _login = new BE.Login();
                _login.Uname = Common.GetTrimData(txtUsrNme.Text);
                _login.Pswd = Common.GetTrimData(txtpswd.Text);
                _login.Email = Common.GetTrimData(txtemailid.Text);


                BL.Login _loginBL = new BL.Login();

                bool _status1 = _loginBL.CheckUser(_login);

                if (!_status1)
                {

                    bool _status = _loginBL.CreateUser(_login);

                    if (!_status)
                    {


                       
                        
                        ShowMessage(Constants.ERR_ADD_REQUEST_DATA, MessageType.Error);

                        
                        return;
                    }
                    else
                    {
                        ShowMessage(Constants.SUCC_REG, MessageType.Success);
                        Response.Redirect(Constants.LOGIN_PAGE, false);
                    }
                }
                else
                {
                    Response.Redirect(Constants.LOGIN_PAGE, false);
                }



            }
            catch (Exception ex)
            {
                ShowErrorPage(ex);
            }
        }

        /// <summary>
        /// Cancel click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.DEFAULT_PAGE, false);
        }


        /// <summary>
        /// Validation
        /// </summary>
        /// <returns></returns>
        private bool validate()
        {
            

            return true;
        }
    }
}
