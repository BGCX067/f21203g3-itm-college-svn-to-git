using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class FrontEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["student"] != null)
                {
                    StudentPanel.Visible = true;
                    studentControlPanel.Text = Session["student"].ToString();
                }
                ActiveMenu();
            }
        }

        /// <summary>
        /// Initialize the menu which currently active
        /// </summary>
        protected void ActiveMenu()
        {
            string path = Path.GetFileName(Request.PhysicalPath);
            switch (path)
            {
                case "Departments.aspx":
                case "DepartmentDetail.aspx":
                    linkDepartment.CssClass = "active";
                    break;
                case "Facilities.aspx":
                case "FacilitiesDetail.aspx":
                    linkFacilities.CssClass = "active";
                    break;
                case "Faculty.aspx":
                case "FacultyDetail.aspx":
                    linkFaculty.CssClass = "active";
                    break;
                case "Courses.aspx":
                    linkCourses.CssClass = "active";
                    break;
                case "Contact.aspx":
                    linkContact.CssClass = "active";
                    break;
                default:
                    linkHome.CssClass = "active";
                    break;
            }
        }
    }
}