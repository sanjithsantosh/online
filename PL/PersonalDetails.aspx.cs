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
    /// This page is for Personal Details.
    /// </summary>
    public partial class PersonalDetails : BasePage
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
                Session["username"] = Request.QueryString["user"];

                getPersonalDetails();
                
           
            }
        }

        private void getPersonalDetails()
        {
            try
            {

                BE.Personal _personal = new BL.Personal().GetPersonal(Session["username"].ToString());
                while (_personal != null)
                {
                    txtFrstNme.Text = _personal.FName.ToString();
                    txtScndNme.Text = _personal.SName.ToString();
                    txtLstNme.Text = _personal.LName.ToString();
                    cmbGndr.SelectedValue = _personal.Gender.ToString();
                    txtNat.Text = _personal.Nat.ToString();
                    txtAdr1.Text = _personal.RAdd1.ToString();
                    txtAdr2.Text = _personal.RAdd2.ToString();
                    txtrsnCty.Text = _personal.Rcty.ToString();
                    txtpscde.Text = _personal.RPcode.ToString();
                    txtcrntAdrs1.Text = _personal.CAdd1.ToString();
                    txtcrntAdrs2.Text = _personal.CAdd2.ToString();
                    txtcrCty.Text = _personal.Ccty.ToString();
                    txtcrPsCde.Text = _personal.CPcode.ToString();
                    txtHMENmbr.Text = _personal.HNmbr.ToString();
                    txtPmNmbr.Text = _personal.PNmbr.ToString();
                    txtmobNmbr.Text = _personal.MNmbr.ToString();
                    txtemailid1.Text = _personal.EmailID1.ToString();
                    txtemailid2.Text = _personal.EmailID2.ToString(); 
               
                }

               
            }
            catch (Exception ex)
            {
               
            }
        }

        /// <summary>
        /// Event for creating a request.
        /// </summary>
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate
                if (!validate()) { return; }

                string requester = Session["username"].ToString();

                BE.Personal _personal = new BE.Personal();
                _personal.FName = Common.GetTrimData(txtFrstNme.Text);
                _personal.SName = Common.GetTrimData(txtScndNme.Text);
                _personal.LName = Common.GetTrimData(txtLstNme.Text);
                _personal.Gender  = Common.GetTrimData(cmbGndr.SelectedValue);
                _personal.Nat = Common.GetTrimData(txtNat.Text);
                _personal.RAdd1 = Common.GetTrimData(txtAdr1.Text);
                _personal.RAdd2 = Common.GetTrimData(txtAdr2.Text);
                _personal.Rcty = Common.GetTrimData(txtrsnCty.Text);
                _personal.RPcode = Common.GetTrimData(txtpscde.Text,0);
                _personal.CAdd1 = Common.GetTrimData(txtcrntAdrs1.Text);
                _personal.CAdd2 = Common.GetTrimData(txtcrntAdrs2.Text);
                _personal.Ccty = Common.GetTrimData(txtcrCty.Text);
                _personal.CPcode = Common.GetTrimData(txtcrPsCde.Text, 0);
                _personal.HNmbr = Common.GetTrimData(txtHMENmbr.Text, 0);
                _personal.PNmbr = Common.GetTrimData(txtPmNmbr.Text, 0);
                _personal.MNmbr = Common.GetTrimData(txtmobNmbr.Text, 0);
                _personal.EmailID1 = Common.GetTrimData(txtemailid1.Text);
                _personal.EmailID2 = Common.GetTrimData(txtemailid2.Text);


                BL.Personal _personalBL = new BL.Personal();
                bool _status = _personalBL.CreateUpdatePersonal(requester, _personal);

                if (!_status)
                {
                    ShowMessage(Constants.ERR_ADD_REQUEST_DATA, MessageType.Error);
                    return;
                }
                else
                {

                    Response.Redirect("EducationalDetails.aspx?user=" + Session["username"].ToString(), false);
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
        protected void btnSveDrft_Click(object sender, EventArgs e)
        {
            //Validate
            if (!validate()) { return; }

            string requester = Session["username"].ToString();

            BE.Personal _personal = new BE.Personal();
            _personal.FName = Common.GetTrimData(txtFrstNme.Text);
            _personal.SName = Common.GetTrimData(txtScndNme.Text);
            _personal.LName = Common.GetTrimData(txtLstNme.Text);
            _personal.Gender = Common.GetTrimData(cmbGndr.SelectedValue);
            _personal.Nat = Common.GetTrimData(txtNat.Text);
            _personal.RAdd1 = Common.GetTrimData(txtAdr1.Text);
            _personal.RAdd2 = Common.GetTrimData(txtAdr2.Text);
            _personal.Rcty = Common.GetTrimData(txtrsnCty.Text);
            _personal.RPcode = Common.GetTrimData(txtpscde.Text, 0);
            _personal.CAdd1 = Common.GetTrimData(txtcrntAdrs1.Text);
            _personal.CAdd2 = Common.GetTrimData(txtcrntAdrs2.Text);
            _personal.Ccty = Common.GetTrimData(txtcrCty.Text);
            _personal.CPcode = Common.GetTrimData(txtcrPsCde.Text, 0);
            _personal.HNmbr = Common.GetTrimData(txtHMENmbr.Text, 0);
            _personal.PNmbr = Common.GetTrimData(txtPmNmbr.Text, 0);
            _personal.MNmbr = Common.GetTrimData(txtmobNmbr.Text, 0);
            _personal.EmailID1 = Common.GetTrimData(txtemailid1.Text);
            _personal.EmailID2 = Common.GetTrimData(txtemailid2.Text);


            BL.Personal _personalBL = new BL.Personal();
            bool _status = _personalBL.CreateUpdatePersonal(requester, _personal);

            if (!_status)
            {
                ShowMessage(Constants.ERR_ADD_REQUEST_DATA, MessageType.Error);
                return;
            }
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
