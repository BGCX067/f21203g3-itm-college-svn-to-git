using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handle ButtonLogin click event
        /// </summary>
        /// <remarks>
        /// - Validate on form
        /// - Check existing username and password
        /// - Assign value to Session
        /// </remarks>
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            var auth = new Authenticator();
            if (ValidateForm())
            {
                DataSet loginDs = auth.Login(txtUsername.Text, new Authenticator().EncodePassword(txtPassword.Text));
                if (loginDs.Tables[0].Rows.Count == 0)
                {
                    ShowMessage("Login false. Please check your username and password");
                }
                else
                {
                    Session["username"] = loginDs.Tables[0].Rows[0]["username"].ToString();
                    Session["role"] = loginDs.Tables[0].Rows[0]["role"].ToString();
                    if ((string) loginDs.Tables[0].Rows[0]["role"] == "admin")
                    {
                        Response.Redirect("Administrator.aspx");
                    }
                    else if ((string) loginDs.Tables[0].Rows[0]["role"] == "staff")
                    {
                        Response.Redirect("Staff.aspx");
                    }
                }
            }
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {

        }

        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                ShowMessage("Username cannot be blank.");
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowMessage("Password cannot be blank.");
                txtPassword.Focus();
                return false;
            }
            return true;
        }
        /*
         * ShowMessage
         * Display message
         * 
         * @author  Hung Nguyen
         * @access  protected
         * @param   string  message
         * @return  void
         */
        protected void ShowMessage(string msg)
        {
            if (!IsPostBack)
            {
                Response.Write("<script>alert('" + msg + "');</script>");
            }
        }
    }
}