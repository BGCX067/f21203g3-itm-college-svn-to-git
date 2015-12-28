using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class Departments : System.Web.UI.Page
    {
        DepartermentManage _dm = new DepartermentManage();
        Validator _vl = new Validator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Departments - ITM College";
            if (!IsPostBack)
            {
                LoadDepartmentList();
                LoadDepartmentLink();
            }
        }

        /// <summary>
        /// Truncate text on listview
        /// </summary>
        /// <param name="stringtotrim"></param>
        /// <returns></returns>
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

        protected void LoadDepartmentLink()
        {
            DepartmentLink.DataSource = _dm.GetDepartments();
            DepartmentLink.DataBind();
        }

        protected void LoadDepartmentList()
        {
            DepartmentList.DataSource = _dm.GetDepartments();
            DepartmentList.DataBind();
        }

        protected void DepartmentPager_PreRender(object sender, EventArgs e)
        {
            DepartmentList.DataSource = _dm.GetDepartments();
            DepartmentList.DataBind();
        }

        protected void DataPagerDepartment_PreRender(object sender, EventArgs e)
        {
            DepartmentList.DataSource = _dm.GetDepartments();
            DepartmentList.DataBind();
        }
    }
}