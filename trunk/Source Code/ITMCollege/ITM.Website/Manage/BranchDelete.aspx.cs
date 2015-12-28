using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
using System.Data;

namespace ITM.Website.Manage
{
    public partial class BranchDelete : System.Web.UI.Page
    {
        //Create new instance of service BranchManage
        BranchManage branch = new BranchManage();

        //Display ID and Name of branch to be deleted at 1st Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = branch.FetchBranch(int.Parse(Request.QueryString["branchID"].ToString()));
                lblBranchID.Text = ds.Tables[0].Rows[0]["brancheID"].ToString();
                lblBranchName.Text = ds.Tables[0].Rows[0]["brancheName"].ToString();
            }
        }

        /// <summary>
        /// Handle ButtonDelete click event
        /// Delete selected branch
        /// </summary>
        /// <remarks>Display message and back to Branches home page if successful</remarks>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (branch.DeleteBranch(int.Parse(lblBranchID.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Branch Deleted');document.location.href='Branches.aspx';", true);
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

    }
}