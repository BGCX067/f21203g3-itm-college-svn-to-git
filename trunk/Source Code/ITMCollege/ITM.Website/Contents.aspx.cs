using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class Contents : System.Web.UI.Page
    {
        readonly ContentManage _cm = new ContentManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["view"] != null)
                {
                    SwitchViewContent();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Default.aspx';", true);
                }
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

        /// <summary>
        /// Switch View Content
        /// </summary>
        protected void SwitchViewContent()
        {
            switch (Request.QueryString["view"])
            {
                case "news":
                    Title = "ITM College News";
                    LoadContentByCategory("news");
                    break;
                case "events":
                    Title = "ITM College Events";
                    LoadContentByCategory("events");
                    break;
                case "achievements":
                    Title = "ITM College Achievements";
                    LoadContentByCategory("achievements");
                    break;
                case "merit":
                    Title = "ITM College Merit";
                    LoadContentByCategory("merit");
                    break;
                default:
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Default.aspx';", true);
                    break;
            }
        }
        protected void LoadContentByCategory(string category)
        {
            ContentList.DataSource = _cm.GetContentByCategory(category);
            ContentList.DataBind();
        }
        protected void DataPagerContentNews_PreRender(object sender, EventArgs e)
        {
            LoadContentByCategory(Request.QueryString["view"]);

        }
    }
}