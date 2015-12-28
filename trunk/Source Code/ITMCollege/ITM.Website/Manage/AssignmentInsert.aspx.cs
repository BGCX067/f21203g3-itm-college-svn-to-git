using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class AssignmentInsert : System.Web.UI.Page
    {
        //Create new instances of services AssignmentManage and CourseManage
        readonly AssignmentManage _assignment = new AssignmentManage();
        readonly CourseManage _course = new CourseManage();

        //Load CourseID list to DropDownList at 1st Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCourseId();
            }
        }

        /// <summary>
        /// Add new item "Select CourseID" and bind database to DropDownList listCourseID
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
        /// Create new Assignment
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all fields are valid
            if (ValidateForm())
            {
                //If all valid, start inserting assignment
                if (_assignment.InsertAssignment(txtName.Text, txtDescription.Text, int.Parse(listCourseID.SelectedValue)))
                {
                    //If insert successfully, show message and reset all controls
                    ShowMessage("Assignment inserted");
                    txtName.Text = null;
                    txtDescription.Text = null;
                    listCourseID.SelectedIndex = 0;
                }
                //Show message if failed insertion
                else 
                {
                    ShowMessage("Assignment not inserted");
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