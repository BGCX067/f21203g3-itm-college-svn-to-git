using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class BranchInsert : System.Web.UI.Page
    {
        //Create new instance of service BranchManage
        readonly BranchManage _branch = new BranchManage();
        readonly Authenticator _auth = new Authenticator();
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
            }
        }

        /// <summary>
        /// Handle ButtonSubmit click event
        /// Create new Branch
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all fields are valid
            if (ValidateForm())
            {
                //If all valid, start inserting branch
                if (_branch.InsertBranch(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, txtFax.Text, txtDescription.Text))
                {
                    //If insert successfully, show message and reset all controls
                    //ShowMessage("Branch inserted");
                    txtName.Text = null;
                    txtAddress.Text = null;
                    txtEmail.Text = null;
                    txtPhone.Text = null;
                    txtFax.Text = null;
                    txtDescription.Text = null;
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Branch inserted');document.location.href='Branches.aspx';", true);
                }
                //Show message if failed insertion
                else
                {
                    ShowMessage("Branch not inserted");
                }
            }
        }

        /// <summary>
        /// Handle ButtonCancel click event
        /// Back to Branches main page
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Branches.aspx");
        }

        /// <summary>
        /// Validate form
        /// </summary>
        /// <remarks></remarks>
        /// <return>
        /// Boolean true if all texts are filled
        /// </return>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowMessage("Branch name cannot be blank. Please enter");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                ShowMessage("Branch address cannot be blank. Please enter");
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                ShowMessage("Branch phone cannot be blank. Please enter");
                txtPhone.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFax.Text))
            {
                ShowMessage("Branch fax cannot be blank. Please enter");
                txtFax.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                ShowMessage("Branch email cannot be blank. Please enter");
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                ShowMessage("Branch description cannot be blank. Please enter");
                txtDescription.Focus();
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
            // Register some inline script
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}