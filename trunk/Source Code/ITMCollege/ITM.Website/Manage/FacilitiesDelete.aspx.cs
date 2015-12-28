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
    public partial class FacilitiesDelete : System.Web.UI.Page
    {
        readonly FacilitiesManage faciliti = new FacilitiesManage();
        readonly Authenticator _auth = new Authenticator();

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Facilities Delete";
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
                DataSet ds = faciliti.FetchFacilities(int.Parse(Request.QueryString["ID"].ToString()));
                lblFacilityID.Text = ds.Tables[0].Rows[0]["facilitieID"].ToString();
                lblFacilityName.Text = ds.Tables[0].Rows[0]["facilitieName"].ToString();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (faciliti.DeleteFacilities(int.Parse(lblFacilityID.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Faciliti Deleted');document.location.href='Facilities.aspx';", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Facilities.aspx");
        }
    }
}