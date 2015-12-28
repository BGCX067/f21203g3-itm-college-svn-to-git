using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Templates
{
    public partial class FacilitiesDetail : System.Web.UI.Page
    {
        readonly FacilitiesManage _fa = new FacilitiesManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFacilitiesDetail();
                LoadFacilitiesLink();
            }
        }
        protected void LoadFacilitiesDetail()
        {
            FacilitiView.DataSource = _fa.FetchFacilities(int.Parse(Request.QueryString["facid"]));
            FacilitiView.DataBind();
        }

        /// <summary>
        /// Load Facilities list
        /// </summary>
        protected void LoadFacilitiesLink()
        {
            FacilitiesLink.DataSource = _fa.GetFacilities();
            FacilitiesLink.DataBind();
        }
    }
}