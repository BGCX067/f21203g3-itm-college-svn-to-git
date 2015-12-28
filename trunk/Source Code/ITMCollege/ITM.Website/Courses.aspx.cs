using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
using System.Data;
using System.Data.SqlClient;


namespace ITM.Website
{
    public partial class Courses : System.Web.UI.Page
    {
        CourseManage _course = new CourseManage();
        Validator _vl = new Validator();
        DepartermentManage _dep = new DepartermentManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCoursesList();
                LoadDepartments();
            }
        }
        protected void LoadDepartments() 
        {
            listDepartment.DataSource = _dep.GetDepartments();
            listDepartment.DataValueField = "departmentID";
            listDepartment.DataTextField = "departmentName";
            listDepartment.DataBind();
        }

        protected void LoadCoursesList()
        {
            CoursesList.DataSource = _course.GetCourses();
            CoursesList.DataBind();
        }

        protected void CoursesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CoursesList.PageIndex = e.NewPageIndex;
            LoadCoursesList();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            CoursesList.DataSource = _course.SearchCourses(int.Parse(listDepartment.SelectedValue), txtName.Text);
            CoursesList.DataBind();
        }
    }
}