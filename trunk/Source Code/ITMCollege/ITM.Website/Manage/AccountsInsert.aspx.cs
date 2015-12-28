using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class AccountsInsert : System.Web.UI.Page
    {
        readonly AccountManage _account = new AccountManage();
        readonly Authenticator _auth = new Authenticator();
        Validator _val = new Validator();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is admin
                try
                {
                    if (!_auth.IsAdmin(Session["role"].ToString()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                }
                roleRadio.SelectedValue = "staff";
            }
        }

        /// <summary>
        /// Handle ButtonSubmit click event
        /// Create new account
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all fields are valid
            if (ValidateForm())
            {
                if (_account.InsertAccount(txtUsername.Text, new Authenticator().EncodePassword(txtPassword.Text), roleRadio.SelectedValue))
                {
                    txtUsername.Text = null;
                    txtPassword.Text = null;
                    txtPassword2.Text = null;
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Account inserted');document.location.href='Accounts.aspx';", true);
                }
            }
        }

        /// <summary>
        /// Validate form
        /// </summary>
        /// <remarks></remarks>
        protected Boolean ValidateForm()
        {
            if (!_val.CheckMinLength(txtUsername.Text, 3) || !_val.CheckMaxLength(txtUsername.Text, 32))
            {
                ShowMessage("Username must be between 3 to 32 characters");
                txtUsername.Focus();
                return false;

            }
            if (_account.IsDuplicateAccount(txtUsername.Text))
            {
                ShowMessage("The username is already taken by another account.");
                txtUsername.Text = null;
                txtUsername.Focus();
                return false;
            }
            if (!_val.CheckMinLength(txtPassword.Text, 3) || !_val.CheckMaxLength(txtPassword.Text, 32))
            {
                ShowMessage("Password must be between 3 to 32 characters");
                txtUsername.Focus();
                return false;

            }
            if (!txtPassword2.Text.Equals(txtPassword.Text))
            {
                ShowMessage("New password does not match. Re-Enter");
                txtPassword.Text = null;
                txtPassword2.Text = null;
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accounts.aspx");
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