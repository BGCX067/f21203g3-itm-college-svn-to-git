using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
using System.Data;
using System.Data.SqlClient;

namespace ITM.Website.Manage
{
    public partial class CoursesUpdate : System.Web.UI.Page
    {
        readonly CourseManage _course = new CourseManage();
        readonly Authenticator _auth = new Authenticator();
        readonly DepartermentManage _dep = new DepartermentManage();
        readonly FacultyManage _faculty = new FacultyManage();

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Update Course";
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

                LoadCourseDetail();
                LoadDepartmentList();
                LoadFaculty();
            }
        }
        protected void LoadDepartmentList()
        {
            departmentList.DataSource = _dep.GetDepartments();
            departmentList.DataValueField = "departmentID";
            departmentList.DataTextField = "departmentName";
            departmentList.DataBind();
        }
        protected void LoadFaculty()
        {
            txtFaculty.DataSource = _faculty.GetFaculty();
            txtFaculty.DataValueField = "facultyID";
            txtFaculty.DataTextField = "facultyName";
            txtFaculty.DataBind();
        }
        protected void LoadCourseDetail()
        {
            int courseID = int.Parse(Request.QueryString["ID"].ToString());
            DataSet ds = _course.FetchCourses(courseID);
            txtCourseID.Text = ds.Tables[0].Rows[0]["courseID"].ToString();
            txtCourseName.Text = ds.Tables[0].Rows[0]["courseName"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["courseDescription"].ToString();
            departmentList.Text = ds.Tables[0].Rows[0]["departmentID"].ToString();
            txtFaculty.Text = ds.Tables[0].Rows[0]["facultyID"].ToString();
            txtStartDate.Text = ds.Tables[0].Rows[0]["startDate"].ToString();
            txtEndDate.Text = ds.Tables[0].Rows[0]["endDate"].ToString();
            txtExamDate.Text = ds.Tables[0].Rows[0]["examDate"].ToString();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                int depID = int.Parse(departmentList.SelectedValue);
                int falID = int.Parse(txtFaculty.SelectedValue);
                if (_course.UpdateCourse(int.Parse(txtCourseID.Text) , txtCourseName.Text , txtDescription.Text , depID , falID , txtStartDate.Text, txtEndDate.Text, txtExamDate.Text))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Course Update');document.location.href='Courses.aspx';", true);
                }
                else
                {
                    ShowMessage("Course not update");
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