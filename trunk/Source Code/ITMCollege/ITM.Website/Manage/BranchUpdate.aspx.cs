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
    public partial class BranchUpdate : System.Web.UI.Page
    {
        //Create new instance of service BranchManage
        readonly BranchManage _branch = new BranchManage();
        readonly Authenticator _auth = new Authenticator();

        //Load branch detail from session branchID transferred from Branches home page
        //Run only at 1st Page_Load
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
                //Change branchID from string to int
                try
                {
                    int.Parse(Request.QueryString["branchID"]);
                }
                //if error, show message and back to Branches home page
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Branch ID');document.location.href='Branches.aspx';", true);
                    return;
                }
                //if no error, load branch detail to BranchUpdate page
                LoadBranchDetail();
            }
        }

        //Load branch detail to BranchUpdate page from brancheID
        protected void LoadBranchDetail()
        {
            int branchID = int.Parse(Request.QueryString["branchID"].ToString());
            DataSet ds =_branch.FetchBranch(branchID);
            txtID.Text = ds.Tables[0].Rows[0]["brancheID"].ToString();
            txtID.ReadOnly = true;
            txtID.Enabled = false;
            txtName.Text = ds.Tables[0].Rows[0]["brancheName"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["brancheAddress"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["branchePhone"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["brancheFax"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["brancheEmail"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        }

        /// <summary>
        /// Handle ButtonSubmit click event
        /// Update branch detail
        /// </summary>
        /// <remarks>txtID is readonly</remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all texts are filled
            if (ValidateForm())
            {
                //if yes, start updating branch
                if (_branch.UpdateBranch(int.Parse(txtID.Text), txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, txtFax.Text, txtDescription.Text))
                {
                    //If successful, show message and back to Branches home page
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Branch updated');document.location.href='Branches.aspx';", true);
                }
                //If fail, show message
                else
                {
                    ShowMessage("Branch not updated");
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
            // Register some inline script:
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}