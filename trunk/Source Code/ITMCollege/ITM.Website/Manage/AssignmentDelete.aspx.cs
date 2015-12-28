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
    public partial class AssignmentDelete : System.Web.UI.Page
    {
        //Create new instance of service AssignmentManage
        AssignmentManage assignment = new AssignmentManage();

        //Display ID and Name of assignment to be deleted at 1st Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = assignment.FetchAssignment(int.Parse(Request.QueryString["assignmentID"].ToString()));
                lblAssignmentID.Text = ds.Tables[0].Rows[0]["assignmentID"].ToString();
                lblAssignmentName.Text = ds.Tables[0].Rows[0]["assignmentName"].ToString();
            }
        }

        /// <summary>
        /// Handle ButtonDelete click event
        /// Delete selected assignment
        /// </summary>
        /// <remarks>Display message and back to Assignments home page if successful</remarks>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (assignment.DeleteAssignment(int.Parse(lblAssignmentID.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Assignment Deleted');document.location.href='Assignments.aspx';", true);
            }
        }

        /// <summary>
        /// Handle ButtonCancel click event
        /// Back to Assignments main page
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assignments.aspx");
        }

    }
}