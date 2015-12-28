using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Departments : System.Web.UI.Page
    {
        readonly DepartermentManage _department = new DepartermentManage();
        Authenticator auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Departements";
            if (!IsPostBack)
            {
                // Check if user is admin
                try
                {
                    if (!auth.IsAdmin(Session["role"].ToString()))
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

        /// <summary>
        /// Truncate text on listview
        /// </summary>
        /// <param name="stringtotrim"></param>
        /// <returns></returns>
        protected string Truncate(object stringtotrim)
        {
            if (!(stringtotrim is string) || String.IsNullOrEmpty(stringtotrim as String))
                return null;
            else
            {
                string totrim = stringtotrim as String;
                return (totrim.Length > 100) ? totrim.Substring(0, 100) + "..." : totrim;
            }
        }

        /// <summary>
        /// Method DepartmentsList
        /// Show Departmnts from dataset to GridView
        /// </summary>
        /// <remarks></remarks>
        protected void LoadDepartmentList()
        {
            departmentList.DataSource = _department.GetDepartments();
            departmentList.DataBind();
        }

        protected void departmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            departmentList.PageIndex = e.NewPageIndex;
            LoadDepartmentList();
        }
    }
}