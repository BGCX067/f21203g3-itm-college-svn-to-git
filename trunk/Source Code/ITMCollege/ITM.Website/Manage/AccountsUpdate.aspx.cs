using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class AccountsUpdate : System.Web.UI.Page
    {
        AccountManage _account = new AccountManage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int.Parse(Request.QueryString["ID"]);
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Account ID');document.location.href='Accounts.aspx';", true);
                    return;
                }
                LoadAccountDetail();
            }
        }

        /// <summary>
        /// Load Account detail into field
        /// </summary>
        /// <remarks></remarks>
        protected void LoadAccountDetail()
        {
            int accountId = int.Parse(Request.QueryString["ID"].ToString());

            DataSet ds = _account.FetchAccount(accountId);

            txtAccountID.Text = ds.Tables[0].Rows[0]["accountID"].ToString();
            txtUsername.Text = ds.Tables[0].Rows[0]["username"].ToString();

            string role = ds.Tables[0].Rows[0]["role"].ToString();
            if (role == "admin")
            {
                roleRadio.SelectedValue = "admin";
            }
            else if (role == "staff")
            {
                roleRadio.SelectedValue = "staff";
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            
            string role = roleRadio.SelectedValue;
            if (ValidateForm())
            {
                string password = new Authenticator().EncodePassword(txtNewPassword2.Text);
                if (_account.UpdateAccount(int.Parse(txtAccountID.Text), txtUsername.Text, password, roleRadio.SelectedValue))
                {
                    ShowMessage("Account updated");
                    Response.Redirect("Accounts.aspx");
                }
            }
            
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accounts.aspx");
        }

        /// <summary>
        /// Validate form
        /// </summary>
        /// <remarks></remarks>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                ShowMessage("Username cannot be blank. Re-enter");
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
            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                if (!txtNewPassword2.Text.Equals(txtNewPassword.Text))
                {
                    ShowMessage("New password does not match. Re-Enter");
                    txtNewPassword.Text = null;
                    txtNewPassword2.Text = null;
                    txtNewPassword.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Show error message
        /// </summary>
        /// <para name="msg">String message to show</para>
        /// <remarks></remarks>
        protected void ShowMessage(string msg)
        {
            // Register some inline script:
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}