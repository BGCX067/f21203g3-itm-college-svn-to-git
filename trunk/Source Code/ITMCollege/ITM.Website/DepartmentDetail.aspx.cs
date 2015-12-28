using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class DepartmentDetail : System.Web.UI.Page
    {
        readonly DepartermentManage _dm = new DepartermentManage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartmentDetail();
                LoadDepartmentLink();
            }
        }

        protected void LoadDepartmentDetail()
        {
            DepartmentView.DataSource = _dm.FetchDepartments(int.Parse(Request.QueryString["depid"]));
            DepartmentView.DataBind();
        }

        /// <summary>
        /// Load Department list
        /// </summary>
        protected void LoadDepartmentLink()
        {
            DepartmentLink.DataSource = _dm.GetDepartments();
            DepartmentLink.DataBind();
        }
    }
}