using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class Facilities : System.Web.UI.Page
    {

        FacilitiesManage _fa = new FacilitiesManage();
        Validator _vl = new Validator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Facilities - ITM College";
            if (!IsPostBack)
            {
                LoadFacilitiesList();
                LoadFacilitieLink();
            }
        }
        protected string Truncate(object stringtotrim)
        {
            if (!(stringtotrim is string) || String.IsNullOrEmpty(stringtotrim as String))
                return null;
            else
            {
                string totrim = stringtotrim as String;
                return (totrim.Length > 240) ? totrim.Substring(0, 240) + "..." : totrim;
            }
        }
        protected void LoadFacilitieLink()
        {
            FacilitiesLink.DataSource = _fa.GetFacilities();
            FacilitiesLink.DataBind();
        }

        protected void LoadFacilitiesList()
        {
            FacilitiesList.DataSource = _fa.GetFacilities();
            FacilitiesList.DataBind();
        }

        protected void FacilitiesPager_PreRender(object sender, EventArgs e)
        {
            FacilitiesList.DataSource = _fa.GetFacilities();
            FacilitiesList.DataBind();
        }

        protected void DataPagerFacilities_PreRender(object sender, EventArgs e)
        {
            FacilitiesList.DataSource = _fa.GetFacilities();
            FacilitiesList.DataBind();
        }
    }
}