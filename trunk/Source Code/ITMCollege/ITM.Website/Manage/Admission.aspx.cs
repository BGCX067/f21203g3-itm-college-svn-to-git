using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Admission : System.Web.UI.Page
    {
        AdmissionManage am = new AdmissionManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdmission();
            }
        }

        protected void LoadAdmission()
        {
            OnlineAdmission.DataSource = am.GetOnlineAdmission();
            OnlineAdmission.DataBind();
        }

        protected void OnlineAdmission_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OnlineAdmission.PageIndex = e.NewPageIndex;
            LoadAdmission();
        }
    }
}