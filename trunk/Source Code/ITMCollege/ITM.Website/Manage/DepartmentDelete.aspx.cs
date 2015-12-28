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
    public partial class DepartmentDelete : System.Web.UI.Page
    {
        readonly DepartermentManage _department = new DepartermentManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Departements Delete";
            if (!IsPostBack)
            {
                // Check if user is admin
                try
                {
                    if (!_auth.IsAdmin(Session["role"].ToString()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                                    "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';",
                                                                    true);
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                                "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';",
                                                                true);
                }
                DataSet ds = _department.FetchDepartments(int.Parse(Request.QueryString["ID"].ToString()));
                lblDepartmentID.Text = ds.Tables[0].Rows[0]["departmentID"].ToString();
                lblDepartmentName.Text = ds.Tables[0].Rows[0]["departmentName"].ToString();    
            }
        }
        /// <summary>
        /// Handle ButtonSubmit click event
        /// Delete Departerments
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_department.DeleteDepartments(int.Parse(lblDepartmentID.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Department Deleted');document.location.href='Departments.aspx';", true);
            }
        }
        /// <summary>
        /// Handle ButtonCancel click event
        /// Cancel delete Departerments
        /// Redirect to DepartmentsManage
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departments.aspx");
        }

    }
}