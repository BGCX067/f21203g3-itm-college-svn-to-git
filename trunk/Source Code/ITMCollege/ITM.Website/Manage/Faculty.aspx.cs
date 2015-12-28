using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;


namespace ITM.Website.Manage
{
    public partial class Faculty : System.Web.UI.Page
    {
        readonly FacultyManage _faculty = new FacultyManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Faculty";
            if (!IsPostBack)
            {
                // Check if user is admin
                try
                {
                    if (!_auth.IsAdmin(Session["role"].ToString()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                }
                LoadFacultyList();
            }
        }
        /// <summary>
        /// Method FacultyList
        /// Show Faculty from dataset to GridView
        /// </summary>
        /// <remarks></remarks>
        protected void LoadFacultyList()
        {
            listFaculty.DataSource = _faculty.GetFaculty();
            listFaculty.DataBind();
        }

        protected void listFaculty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listFaculty.PageIndex = e.NewPageIndex;
            LoadFacultyList();
        }
    }
}