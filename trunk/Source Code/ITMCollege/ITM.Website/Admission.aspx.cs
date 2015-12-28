using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class Admission : System.Web.UI.Page
    {
        /*
         * Instance variables
         */
        Validator _val = new Validator();
        AdmissionManage adm = new AdmissionManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Online Admission - ITM College";
            // Generate registration key
            regKey.Value = new Authenticator().EncodePassword(DateTime.Now.ToString());
            radGender.SelectedValue = "0";
            if (!IsPostBack)
            {
                if (Session["student"] != null)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Default.aspx';", true);
                }
            }
        }

        /// <summary>
        /// Handle ButtonSubmmit click event
        /// Submit Registration form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var name = txtName.Text;
                var fatherName = txtFatherName.Text;
                var mortherName = txtMothername.Text;
                var birthday = txtBirthday.Text;
                var gender = int.Parse(radGender.SelectedValue);
                var residentialAddress = txtResidentialAddress.Text;
                var permanentAddress = txtPermanentAddress.Text;
                var prevSportsDetails = txtSportDetail.Text;
                var prevUniversity = txtUniversity.Text;
                var prevEnrolNumber = txtEnrolNumber.Text;
                var prevCenter = txtCenter.Text;
                var prevStream = txtStream.Text;
                var prevField = txtField.Text;
                var prevMarks = txtMarkSecured.Text;
                var prevOutOf = txtOutOf.Text;
                var prevClass = txtClassObtained.Text;
                var regkey = regKey.Value;
                var af = txtAdmissionFor.Text;
                if (adm.InsertAdmission(name, fatherName, mortherName, birthday, residentialAddress, permanentAddress,
                                        gender, prevSportsDetails, prevUniversity, prevEnrolNumber, prevCenter,
                                        prevStream, prevField, prevMarks, prevOutOf, prevClass, regkey, af))
                {
                    Session["regkey"] = regkey;
                    Response.Redirect("AdmissionComplete.aspx?regkey="+regkey);
                }
            }
        }

        /// <summary>
        /// Hande ButtonCancel click event
        /// Cancel current registration process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        /// <summary>
        /// Validate form
        /// </summary>
        /// <returns>
        /// - True if all fields are filled
        /// - False on error
        /// </returns>
        protected Boolean ValidateForm()
        {
            if ( !_val.CheckMaxLength(txtName.Text, 250) || string.IsNullOrEmpty(txtName.Text))
            {
                ShowMessage("Please enter your name");
                txtName.Focus();
                return false;
            }
            if (!_val.CheckMaxLength(txtFatherName.Text, 250) || string.IsNullOrEmpty(txtFatherName.Text))
            {
                ShowMessage("Please enter your Father name");
                txtFatherName.Focus();
                return false;
            }
            if (!_val.CheckMaxLength(txtMothername.Text, 250) || string.IsNullOrEmpty(txtMothername.Text))
            {
                ShowMessage("Please enter your Mother name");
                txtMothername.Focus();
                return false;
            }
            if (!_val.CheckMaxLength(txtBirthday.Text, 250) || string.IsNullOrEmpty(txtBirthday.Text))
            {
                ShowMessage("Please enter your Date of Birth");
                txtMothername.Focus();
                return false;
            }
            if (!_val.CheckMaxLength(txtResidentialAddress.Text, 250) || string.IsNullOrEmpty(txtResidentialAddress.Text))
            {
                ShowMessage("Please enter your Residential Address");
                txtResidentialAddress.Focus();
                return false;
            }
            if (!_val.CheckMaxLength(txtPermanentAddress.Text, 250) || string.IsNullOrEmpty(txtPermanentAddress.Text))
            {
                ShowMessage("Please enter your Permanent Address");
                txtPermanentAddress.Focus();
                return false;
            }
            if (!_val.CheckMaxLength(txtSportDetail.Text, 250) || string.IsNullOrEmpty(txtSportDetail.Text))
            {
                ShowMessage("Please enter your Sport Detail");
                txtSportDetail.Focus();
                return false;
            }
            if (!_val.CheckMaxLength(txtAdmissionFor.Text, 250) || string.IsNullOrEmpty(txtAdmissionFor.Text))
            {
                ShowMessage("Please enter your Admission For");
                txtAdmissionFor.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Show error message
        /// </summary>
        /// <param name="msg">String message to show</param>
        /// <remarks></remarks>
        protected void ShowMessage(string msg)
        {
            // Register some inline script:
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}