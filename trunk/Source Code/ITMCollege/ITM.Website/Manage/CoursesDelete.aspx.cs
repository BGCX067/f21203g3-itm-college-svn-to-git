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
    public partial class CoursesDelete : System.Web.UI.Page
    {
        readonly CourseManage _course = new CourseManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Course Delete";
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

                DataSet ds = _course.FetchCourses(int.Parse(Request.QueryString["ID"].ToString()));
                lblCourseID.Text = ds.Tables[0].Rows[0]["courseID"].ToString();
                lblCourseName.Text = ds.Tables[0].Rows[0]["courseName"].ToString();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_course.DeleteCourse(int.Parse(lblCourseID.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Course Deleted');document.location.href='Courses.aspx';", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
    }
}