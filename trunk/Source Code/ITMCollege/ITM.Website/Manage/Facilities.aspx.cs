using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;


namespace ITM.Website.Manage
{
    public partial class Facilities : System.Web.UI.Page
    {
        readonly FacilitiesManage _facu = new FacilitiesManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Facilities";
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
                LoadFacilitiesList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void LoadFacilitiesList()
        {
            listFacilities.DataSource = _facu.GetFacilities();
            listFacilities.DataBind();
        }

        protected void listFacilities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listFacilities.PageIndex = e.NewPageIndex;
            LoadFacilitiesList();
        }
    }
}