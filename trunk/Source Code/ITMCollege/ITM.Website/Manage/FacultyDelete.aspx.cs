using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
using System.Data;

namespace ITM.Website.Manage
{
    public partial class FacultyDelete : System.Web.UI.Page
    {
        readonly FacultyManage _faculty = new FacultyManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Faculty Delete";
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
                DataSet ds = _faculty.FetchFaculty(int.Parse(Request.QueryString["ID"].ToString()));
                lblFacultyID.Text = ds.Tables[0].Rows[0]["facultyID"].ToString();
                lblFacultyName.Text = ds.Tables[0].Rows[0]["facultyName"].ToString();
            }
        }
        /// <summary>
        /// Handle ButtonSubmit click event
        /// Delete Faculty
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_faculty.DeleteFaculty(int.Parse(lblFacultyID.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Faculty Deleted');document.location.href='Faculty.aspx';", true);
            }
        }
        /// <summary>
        /// Handle ButtonCancel click event
        /// Cancel delete Faculty
        /// Redirect to FacultyManage
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Faculty.aspx");
        }
    }
}