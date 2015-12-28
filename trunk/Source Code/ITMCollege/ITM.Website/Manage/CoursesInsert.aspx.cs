using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class CoursesInsert : System.Web.UI.Page
    {
        readonly CourseManage _course = new CourseManage();
        readonly DepartermentManage _dep = new DepartermentManage();
        readonly FacultyManage _faculty = new FacultyManage();
        readonly Authenticator _auth = new Authenticator();

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "New Course";
            if (!IsPostBack)
            {
                try
                {
                    if (!_auth.IsStaff(Session["role"].ToString()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                }
                LoadDepartmentList();
            }
        }

        protected void LoadDepartmentList() {
            departmentList.DataSource = _dep.GetDepartments();
            departmentList.DataValueField = "departmentID";
            departmentList.DataTextField = "departmentName";
            departmentList.DataBind();
        }

        protected void departmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            facultyList.Visible = true;
            int depId = Convert.ToInt32(departmentList.SelectedValue);
            LoadFaculty(depId);
        }

        protected void LoadFaculty(int depId)
        {
            facultyList.DataSource = _faculty.GetFacultyByDepartment(depId);
            facultyList.DataValueField = "facultyID";
            facultyList.DataTextField = "facultyName";
            facultyList.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                int depId = int.Parse(departmentList.SelectedValue);
                int falId = int.Parse(facultyList.SelectedValue);
                if (_course.InsertCourse(txtCourseName.Text, txtDescription.Text, depId, falId, txtStartDate.Text, txtEndDate.Text, txtExamDate.Text))
                {
                    txtCourseName.Text = null;
                    txtDescription.Text = null;
                    txtStartDate.Text = null;
                    txtEndDate.Text = null;
                    txtExamDate.Text = null;
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Courses inserted');document.location.href='Courses.aspx';", true);
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtCourseName.Text))
            {
                ShowMessage("CourseName cannot be blank. Re-enter");
                txtCourseName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                ShowMessage("CourseDescription cannot be blank. Re-enter");
                txtDescription.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                ShowMessage("Start Date cannot be blank. Re-enter");
                txtStartDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEndDate.Text))
            {
                ShowMessage("End Date cannot be blank. Re-enter");
                txtEndDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtExamDate.Text))
            {
                ShowMessage("Exam Date cannot be blank. Re-enter");
                txtExamDate.Focus();
                return false;
            }
            return true;
        }
        protected void ShowMessage(string msg)
        {
            // Register some inline script:
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}