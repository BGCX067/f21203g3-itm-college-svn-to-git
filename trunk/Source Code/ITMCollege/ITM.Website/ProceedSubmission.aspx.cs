using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class ProceedSubmission : System.Web.UI.Page
    {
        DepartermentManage dm = new DepartermentManage();
        CourseManage course = new CourseManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUniqueID.Text = Request.QueryString["UniqueID"].ToString(CultureInfo.InvariantCulture);
            if (Session["UniqueID"] != null)
            {
                if (Session["UniqueID"].ToString() != Request.QueryString["UniqueID"].ToString(CultureInfo.InvariantCulture))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='AdmissionStatus.aspx';", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='AdmissionStatus.aspx';", true);
            }

            if (!IsPostBack)
            {
                LoadDepartmentList();
            }
        }

        protected void LoadDepartmentList()
        {
            departmentList.DataSource = dm.GetDepartments();
            departmentList.DataValueField = "departmentID";
            departmentList.DataTextField = "departmentName";
            departmentList.DataBind();
        }

        /// <summary>
        /// Handle department list change
        /// Get available from selected department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void departmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var departmentId = int.Parse(departmentList.SelectedValue);
            CourseList.DataSource = course.GetCourseByDepartmentId(departmentId);
            CourseList.DataBind();
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