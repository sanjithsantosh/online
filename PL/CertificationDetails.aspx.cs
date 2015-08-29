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
    public partial class CertificationDetails : BasePage
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

        private void getCertification()
        {
            try
            {

                BE.Certification _cert = new BL.Certification().GetCertification(Session["username"].ToString());
                while (_cert != null)
                {
                    txtcert1.Text = _cert.Cert1.ToString();
                    txtorg1.Text = _cert.Org1.ToString();
                    txtexprydte1.Text = _cert.ExpryDte1.ToString();

                    txtcert2.Text = _cert.Cert2.ToString();
                    txtorg2.Text = _cert.Org2.ToString();
                    txtexpry3.Text = _cert.ExpryDte2.ToString();

                    txtcrt3.Text = _cert.Cert3.ToString();
                    txtorg3.Text = _cert.Org3.ToString();
                    txtexpry3.Text = _cert.ExpryDte3.ToString();


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

                BE.Certification _certification = new BE.Certification();

                _certification.Cert1 = Common.GetTrimData(txtcert1.Text);
                _certification.Org1 = Common.GetTrimData(txtorg1.Text);
                _certification.ExpryDte1 = Common.GetTrimData(txtexprydte1.Text,null);


                _certification.Cert2 = Common.GetTrimData(txtcert2.Text);
                _certification.Org2 = Common.GetTrimData(txtorg2.Text);
                _certification.ExpryDte2 = Common.GetTrimData(txtexp2.Text, null);

                _certification.Cert3 = Common.GetTrimData(txtcrt3.Text);
                _certification.Org3 = Common.GetTrimData(txtorg3.Text);
                _certification.ExpryDte3 = Common.GetTrimData(txtexpry3.Text, null);


                BL.Certification _certificationBL = new BL.Certification();
                bool _status = _certificationBL.CreateUpdateCertification(User.ToString(), _certification);

                if (!_status)
                {
                    ShowMessage(Constants.ERR_ADD_REQUEST_DATA, MessageType.Error);
                    return;
                }
                else
                {

                    Response.Redirect("PersonalDetails.aspx?user=" + Session["username"].ToString(), false);
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

                BE.Certification _certification = new BE.Certification();

                _certification.Cert1 = Common.GetTrimData(txtcert1.Text);
                _certification.Org1 = Common.GetTrimData(txtorg1.Text);
                _certification.ExpryDte1 = Common.GetTrimData(txtexprydte1.Text, null);


                _certification.Cert2 = Common.GetTrimData(txtcert2.Text);
                _certification.Org2 = Common.GetTrimData(txtorg2.Text);
                _certification.ExpryDte2 = Common.GetTrimData(txtexp2.Text, null);

                _certification.Cert3 = Common.GetTrimData(txtcrt3.Text);
                _certification.Org3 = Common.GetTrimData(txtorg3.Text);
                _certification.ExpryDte3 = Common.GetTrimData(txtexpry3.Text, null);


                BL.Certification _certificationBL = new BL.Certification();
                bool _status = _certificationBL.CreateUpdateCertification(User.ToString(), _certification);

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
