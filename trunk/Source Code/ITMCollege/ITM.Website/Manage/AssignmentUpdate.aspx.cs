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
    public partial class AssignmentUpdate : System.Web.UI.Page
    {
        //Create new instances of services AssignmentManage and CourseManage
        readonly AssignmentManage _assignment = new AssignmentManage();
        readonly CourseManage _course = new CourseManage();

        //Load assignment detail from session assignmentID transferred from Assignments home page
        //Run only at 1st Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Change assignmentID from string to int
                try
                {
                    int.Parse(Request.QueryString["assignmentID"]);
                }
                //if error, show message and back to Assignments home page
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Assignment ID');document.location.href='Assignments.aspx';", true);
                    return;
                }
                //if no error, load assignment detail to AssignmentUpdate page
                LoadAssignmentDetail();
            }
        }

        //Load assignment detail to AssignmentUpdate page from assignmentID
        protected void LoadAssignmentDetail()
        {
            int assignmentId = int.Parse(Request.QueryString["assignmentID"].ToString());
            DataSet ds =_assignment.FetchAssignment(assignmentId);
            txtID.Text = ds.Tables[0].Rows[0]["assignmentID"].ToString();
            txtID.ReadOnly = true;
            txtID.Enabled = false;
            txtName.Text = ds.Tables[0].Rows[0]["assignmentName"].ToString();
            LoadCourseId();
            listCourseID.SelectedValue = ds.Tables[0].Rows[0]["courseID"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["assignmentDescription"].ToString();
        }

        /// <summary>
        /// Add new item "Select CourseID" and bind database to DropDownList
        /// </summary>
        /// <remarks></remarks>
        private void LoadCourseId()
        {
            listCourseID.Items.Add("Select CourseID");
            listCourseID.AppendDataBoundItems = true;
            listCourseID.DataSource = _course.GetCourses();
            listCourseID.DataTextField = "courseName";
            listCourseID.DataValueField = "courseID";
            listCourseID.DataBind();
            listCourseID.SelectedIndex = 0;
        }

        /// <summary>
        /// Handle ButtonSubmit click event
        /// Update assignment detail
        /// </summary>
        /// <remarks>txtID is readonly</remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all texts are filled
            if (ValidateForm())
            {
                //if yes, start updating assignment
                if (_assignment.UpdateAssignment(int.Parse(txtID.Text), txtName.Text, txtDescription.Text, int.Parse(listCourseID.SelectedValue)))
                {
                    //If successful, show message and back to Assignments home page
                    ShowMessage("Assignment updated");
                    Response.Redirect("Assignments.aspx");
                }
                //If fail, show message
                else
                {
                    ShowMessage("Assignment not updated");
                }
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
                ShowMessage("Assignment name cannot be blank. Please enter");
                txtName.Focus();
                return false;
            }
            if (listCourseID.SelectedItem.Text.Equals("Select CourseID"))
            {
                ShowMessage("Course ID cannot be blank. Please enter");
                listCourseID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                ShowMessage("Assignment description cannot be blank. Please enter");
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