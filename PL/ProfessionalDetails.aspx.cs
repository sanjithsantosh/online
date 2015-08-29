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
    /// This page is for ProfessionalDetails Details.
    /// </summary>
    public partial class ProfessionalDetails : BasePage
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

            }
        }

        private void getProfessionalDetails()
        {
            try
            {

                BE.Professional _professional = new BL.Professional().GetProfessional(Session["username"].ToString());
                while (_professional != null)
                {
                    txttoExp.Text = _professional.totexp.ToString();
                    txtprevemplyr.Text = _professional.PrevEmp.ToString();
                    txtprevDsgn.Text = _professional.PrevDesgn.ToString();
                    txtprevrsnfrlvng.Text = _professional.PrevRsnLvng.ToString();
                    txtprevrls.Text = _professional.PrevRles.ToString();
                    txtprvfrmdate.Text = _professional.PrvFrmDate.ToString();
                    txtprvtodate.Text = _professional.PrvToDate.ToString();
                    txtcrntempl.Text = _professional.CrntEmp.ToString();
                    txtcrntdsgn.Text = _professional.CrntDesgn.ToString();
                    txtrsnfrlvng.Text = _professional.CrntRsnLvng.ToString();
                    txtrls.Text = _professional.CrntRles.ToString();
                    txtfrmdte.Text = _professional.CrntFrmDate.ToString();
                    txtcrntslalary.Text = _professional.CrntSlry.ToString();
                    txtexpectdslry.Text = _professional.ExpctSlry.ToString();
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

                BE.Professional _professional = new BE.Professional();
                _professional.totexp = Common.GetTrimData(txttoExp.Text,0);
                _professional.PrevEmp = Common.GetTrimData(txtprevemplyr.Text);
                _professional.PrevDesgn = Common.GetTrimData(txtprevDsgn.Text);
                _professional.PrevRsnLvng = Common.GetTrimData(txtprevrsnfrlvng.Text);
                _professional.PrevRles = Common.GetTrimData(txtprevrls.Text);
                _professional.CrntEmp = Common.GetTrimData(txtcrntempl.Text);
                _professional.CrntDesgn = Common.GetTrimData(txtcrntdsgn.Text);
                _professional.CrntRsnLvng = Common.GetTrimData(txtrsnfrlvng.Text);
                _professional.CrntRles = Common.GetTrimData(txtrls.Text);
                _professional.CrntSlry = Common.GetTrimData(txtcrntslalary.Text,0);
                _professional.ExpctSlry = Common.GetTrimData(txtexpectdslry.Text,0);
                _professional.PrvFrmDate = Common.GetTrimData(txtprvfrmdate.Text,null);
                _professional.PrvToDate = Common.GetTrimData(txtprvtodate.Text, null);
                _professional.CrntFrmDate = Common.GetTrimData(txtfrmdte.Text, null);



                BL.Professional _professionalBL = new BL.Professional();
                bool _status = _professionalBL.CreateUpdateProfessional(User.ToString(), _professional);

                if (!_status)
                {
                    ShowMessage(Constants.ERR_ADD_REQUEST_DATA, MessageType.Error);
                    return;
                }
                else
                {

                    Response.Redirect("CertificationDetails.aspx?user=" + Session["username"].ToString(), false);
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
            try
            {
                //Validate
                if (!validate()) { return; }

                BE.Professional _professional = new BE.Professional();
                _professional.totexp = Common.GetTrimData(txttoExp.Text, 0);
                _professional.PrevEmp = Common.GetTrimData(txtprevemplyr.Text);
                _professional.PrevDesgn = Common.GetTrimData(txtprevDsgn.Text);
                _professional.PrevRsnLvng = Common.GetTrimData(txtprevrsnfrlvng.Text);
                _professional.PrevRles = Common.GetTrimData(txtprevrls.Text);
                _professional.CrntEmp = Common.GetTrimData(txtcrntempl.Text);
                _professional.CrntDesgn = Common.GetTrimData(txtcrntdsgn.Text);
                _professional.CrntRsnLvng = Common.GetTrimData(txtrsnfrlvng.Text);
                _professional.CrntRles = Common.GetTrimData(txtrls.Text);
                _professional.CrntSlry = Common.GetTrimData(txtcrntslalary.Text, 0);
                _professional.ExpctSlry = Common.GetTrimData(txtexpectdslry.Text, 0);
                _professional.PrvFrmDate = Common.GetTrimData(txtprvfrmdate.Text, null);
                _professional.PrvToDate = Common.GetTrimData(txtprvtodate.Text, null);
                _professional.CrntFrmDate = Common.GetTrimData(txtfrmdte.Text, null);



                BL.Professional _professionalBL = new BL.Professional();
                bool _status = _professionalBL.CreateUpdateProfessional(User.ToString(), _professional);

                if (!_status)
                {
                    ShowMessage(Constants.ERR_ADD_REQUEST_DATA, MessageType.Error);
                    return;
                }
              

            }
            catch (Exception ex)
            {
                ShowErrorPage(ex);
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
