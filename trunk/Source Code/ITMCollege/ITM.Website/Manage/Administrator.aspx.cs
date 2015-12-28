using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Administrator : System.Web.UI.Page
    {
        readonly AdmissionManage _am = new AdmissionManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                LoadAdmission();
            }
        }

        /// <summary>
        /// Load new online admission
        /// </summary>
        protected void LoadAdmission()
        {
            OnlineAdmission.DataSource = _am.GetOnlineAdmission();
            OnlineAdmission.DataBind();
        }

        /// <summary>
        /// Handle pagination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnlineAdmission_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OnlineAdmission.PageIndex = e.NewPageIndex;
            LoadAdmission();
        }
    }
}