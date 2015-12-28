using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Branches : System.Web.UI.Page
    {
        //Create new instance of service BranchManage
        readonly BranchManage _branch = new BranchManage();
        readonly Authenticator _auth = new Authenticator();
        //Load branch detail to GridView at 1st Page_Load
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
                LoadBranchList();
            }
        }

        /// <summary>
        /// Load Branch list
        /// </summary>
        protected void LoadBranchList()
        {
            listBranch.DataSource = _branch.GetBranch();
            listBranch.DataBind();
        }

        /// <summary>
        /// Handle Branches list page change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void listBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listBranch.PageIndex = e.NewPageIndex;
            LoadBranchList();
        }
    }
}