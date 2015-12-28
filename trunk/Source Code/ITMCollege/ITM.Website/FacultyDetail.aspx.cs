using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
namespace ITM.Website
{
    public partial class FacultyDetail : System.Web.UI.Page
    {
        readonly FacultyManage _fa = new FacultyManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFacultyDetail();
                LoadFacultyLink();
            }
        }
        protected void LoadFacultyDetail()
        {
            var ds = _fa.FetchFaculty(int.Parse(Request.QueryString["fid"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Title = ds.Tables[0].Rows[0]["facultyName"].ToString() + " - ITM College Faculty";
            }
            FacultyView.DataSource = ds;
            FacultyView.DataBind();
        }

        /// <summary>
        /// Load faculty list
        /// </summary>
        protected void LoadFacultyLink()
        {
            FacultyLink.DataSource = _fa.GetFaculty();
            FacultyLink.DataBind();
        }
    }
}