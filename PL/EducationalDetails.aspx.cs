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
    /// This page is for Educational Details.
    /// </summary>
    public partial class EducationalDetails : BasePage
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

        private void getEducationalDetails()
        {
            try
            {

                BE.Educational _educational = new BL.Educational().GetEducational(Session["username"].ToString());
                while (_educational != null)
                {
                    txtInstitution.Text = _educational.Institution.ToString();
                    txtmjdgrpgm.Text = _educational.MaDgree.ToString();
                    txt2ndmjdgrpgm.Text = _educational.ScndMjrDgree.ToString();
                    txtmnrdgrpgm.Text = _educational.MnrDgree.ToString();
                    txtCntry.Text = _educational.Country.ToString();
                    txtednlvl.Text = _educational.EdLvl.ToString();
                    txtstdate.Text = _educational.StartDate.ToString();
                    txtendate.Text = _educational.EndDate.ToString();
                    txtGPA.Text = _educational.GPA.ToString();
                    txthscndry.Text = _educational.Hschl.ToString();
                    

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

                BE.Educational _educational = new BE.Educational();
                _educational.Institution = Common.GetTrimData(txtInstitution.Text);
                _educational.Country = Common.GetTrimData(txtCntry.Text);
                _educational.MaDgree = Common.GetTrimData(txtmjdgrpgm.Text);
                _educational.ScndMjrDgree = Common.GetTrimData(txt2ndmjdgrpgm.Text);
                _educational.MnrDgree = Common.GetTrimData(txtmnrdgrpgm.Text);
                _educational.EdLvl = Common.GetTrimData(txtednlvl.Text);
                _educational.StartDate = Common.GetTrimData(txtstdate.Text, null);
                _educational.EndDate = Common.GetTrimData(txtendate.Text, null);
                _educational.Hschl = Common.GetTrimData(txthscndry.Text);
                _educational.GPA = Common.GetTrimData(txtGPA.Text, 0);

                BL.Educational _educationalBL = new BL.Educational();
                bool _status = _educationalBL.CreateUpdateEducational(User.ToString(), _educational);

                if (!_status)
                {
                    ShowMessage(Constants.ERR_ADD_REQUEST_DATA, MessageType.Error);
                    return;
                }
                else
                {

                    Response.Redirect("ProfessionalDetails.aspx?user=" + Session["username"].ToString(), false);
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

                string requester = Session["username"].ToString();

                BE.Educational _educational = new BE.Educational();
                _educational.Institution = Common.GetTrimData(txtInstitution.Text);
                _educational.Country = Common.GetTrimData(txtCntry.Text);
                _educational.MaDgree = Common.GetTrimData(txtmjdgrpgm.Text);
                _educational.ScndMjrDgree = Common.GetTrimData(txt2ndmjdgrpgm.Text);
                _educational.MnrDgree = Common.GetTrimData(txtmnrdgrpgm.Text);
                _educational.EdLvl = Common.GetTrimData(txtednlvl.Text);
                _educational.StartDate = Common.GetTrimData(txtstdate.Text, null);
                _educational.EndDate = Common.GetTrimData(txtendate.Text, null);
                _educational.Hschl = Common.GetTrimData(txthscndry.Text);
                _educational.GPA = Common.GetTrimData(txtGPA.Text, 0);

                BL.Educational _educationalBL = new BL.Educational();
                bool _status = _educationalBL.CreateUpdateEducational(User.ToString(), _educational);

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
