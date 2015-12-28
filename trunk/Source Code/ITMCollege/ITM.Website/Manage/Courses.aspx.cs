using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Courses : System.Web.UI.Page
    {
        
        readonly CourseManage _course = new CourseManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Courses";
            // Check if user is admin
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
                LoadCoursesList();
            }
        }
        /// Show Departmnts from dataset to GridView
        protected void LoadCoursesList()
        {
            listCourses.DataSource = _course.GetCourses();
            listCourses.DataBind();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void listCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listCourses.PageIndex = e.NewPageIndex;
            LoadCoursesList();
        }
    }
}