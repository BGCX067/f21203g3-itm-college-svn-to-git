using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        readonly AccountManage _account = new AccountManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string s = Session["username"].ToString();
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                    return;
                }
                LabelUsername.Text = Session["username"].ToString();
            }
        }

        /// <summary>
        /// Handle ButtonSubmit click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // validate data
            if (ValidateForm())
            {
                if (_account.ChangePassword(LabelUsername.Text, _auth.EncodePassword(txtPassword.Text)))
                {
                    Session["username"] = null;
                    Session["role"] = null;
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Your new password has been updated');document.location.href='Login.aspx';", true);
                }
                else
                {
                    ShowMessage("Unable to update your new password. Please try again later");
                }
            }
        }

        /// <summary>
        /// validate form data
        /// Handle ButtonSubmit click event
        /// </summary>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtCurrPassword.Text))
            {
                ShowMessage("Please enter your current password.");
                txtCurrPassword.Focus();
                return false;
            }
            DataSet loginDs = _auth.Login(LabelUsername.Text, new Authenticator().EncodePassword(txtCurrPassword.Text));
            if (loginDs.Tables[0].Rows.Count == 0)
            {
                ShowMessage("Your current password is invalid. Please check");
                txtCurrPassword.Focus();
                return false;
            }
            if (txtPassword.Text.Length < 6)
            {
                ShowMessage("Your new password must be at least 5 characters long");
                txtPassword.Focus();
                return false;
            }
            else if (txtPassword.Text.Length > 32)
            {
                ShowMessage("Your new password must be less than 32 characters long");
                txtPassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtPassword2.Text)
            {
                ShowMessage("New Password does not match");
                txtPassword.Text = null;
                txtPassword2.Text = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Handle ButtonSubmit click event
        /// Return to Account page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (_auth.IsAdmin(Session["role"].ToString()))
            {
                Response.Redirect("Accounts.aspx");
            }
            else
            {
                Response.Redirect("Staff.aspx");
            }
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