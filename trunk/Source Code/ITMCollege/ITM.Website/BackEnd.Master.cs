using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITM.Website
{
    public partial class BackEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetActiveMenu();
                SetMenuItemActive();
            }
        }

        /// <summary>
        /// Initialize the menu which currently active
        /// </summary>
        /// <remarks></remarks>
        protected void SetActiveMenu()
        {
            if ((string)Session["role"] == "admin")
            {
                AdminMenu.Visible = true;
                StaffMenu.Visible = false;
                staffDashboardBread.Visible = false;
            }
            else
            {
                AdminMenu.Visible = false;
                StaffMenu.Visible = true;
                adminDashboardBread.Visible = false;
            }
        }

        /// <summary>
        /// Initialize the menu which currently active
        /// </summary>
        /// <remarks></remarks>
        protected void SetMenuItemActive()
        {
            string path = Path.GetFileName(Request.PhysicalPath);
            switch (path)
            {
                // Active menu for admin
                case "Accounts.aspx":
                case "AccountsDelete.aspx":
                case "AccountsInsert.aspx":
                case "AccountsUpdate.aspx":
                    adminAccounts.CssClass = "active";
                    break;
                case "Departments.aspx":
                case "DepartmentDelete.aspx":
                case "DepartementsInsert.aspx":
                case "DepartmentUpdate.aspx":
                    adminDepartments.CssClass = "active";
                    break;
                case "Facilities.aspx":
                case "FacilitiesDelete.aspx":
                case "FacilitiesInsert.aspx":
                case "FacilitiesUpdate.aspx":
                    adminFacilities.CssClass = "active";
                    break;
                case "Faculty.aspx":
                case "FacultyDelete.aspx":
                case "FacultyInsert.aspx":
                case "FacultyUpdate.aspx":
                    adminFaculty .CssClass = "active";
                    break;
                case "Admission.aspx":
                case "AdmissionDelete.aspx":
                case "AdmissionUpdate.aspx":
                    adminAdmission.CssClass = "active";
                    break;
                case "Branches.aspx":
                case "BranchInsert.aspx":
                case "BranchUpdate.aspx":
                case "BranchDelete.aspx":
                    adminBranches.CssClass = "active";
                    break;
                // Active menu for Staff
                case "Staff.aspx":
                    staffDashboard.CssClass = "active";
                    break;
                case "Courses.aspx":
                case "CoursesDelete.aspx":
                case "CoursesInsert.aspx":
                case "CoursesUpdate.aspx":
                    staffCourse.CssClass = "active";
                    break;
                case "Contents.aspx":
                case "ContentsDelete.aspx":
                case "ContentsInsert.aspx":
                case "ContentsUpdate.aspx":
                    staffContents.CssClass = "active";
                    break;
                case "Assignments.aspx":
                case "AssignmentsDelete.aspx":
                case "AssignmentsInsert.aspx":
                case "AssignmentsUpdate.aspx":
                    staffAssignments.CssClass = "active";
                    break;
                case "FeedBacks.aspx":
                    staffFeedBack.CssClass = "active";
                    break;
                default:
                    adminDashboard.CssClass = "active";
                    break;
            }

        }
    }
}