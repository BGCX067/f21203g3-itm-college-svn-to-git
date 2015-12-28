using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class Faculty : System.Web.UI.Page
    {
        readonly FacultyManage _fm = new FacultyManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = "ITM College Faculty";
                LoadFacultyList();
            }
        }

        /// <summary>
        /// Load Faculty to ListView
        /// </summary>
        protected void LoadFacultyList()
        {
            FacultyList.DataSource = _fm.GetFaculty();
            FacultyList.DataBind();
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
                return (totrim.Length > 100) ? totrim.Substring(0, 100) + "..." : totrim;
            }
        }

        protected void DataPager_PreRender(object sender, EventArgs e)
        {
            LoadFacultyList();
        }
    }
}