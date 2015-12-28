using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;


namespace ITM.Website
{
    public partial class ContentsDetail : System.Web.UI.Page
    {
        readonly ContentManage _cm = new ContentManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "News";
            LoadContentDetail();
        }

        /// <summary>
        /// Load Content detail 
        /// </summary>
        protected void LoadContentDetail()
        {
            var ds = _cm.FetchContent(int.Parse(Request.QueryString["cid"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Title = ds.Tables[0].Rows[0]["contentTitle"].ToString() + " - ITM College";
            }
            ContentView.DataSource = ds;
            ContentView.DataBind();
        }
    }
}