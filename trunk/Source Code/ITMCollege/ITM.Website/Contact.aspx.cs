using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class Contact : System.Web.UI.Page
    {
        readonly BranchManage _bra = new BranchManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadContactList();
            }
        }
        /// <summary>
        /// Load Contact to ListView
        /// </summary>
        protected void LoadContactList()
        {
            ContactList.DataSource = _bra.GetBranch();
            ContactList.DataBind();
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

        protected void DataPager_PreRender(object sender, EventArgs e)
        {
            LoadContactList();
        }
    }
}