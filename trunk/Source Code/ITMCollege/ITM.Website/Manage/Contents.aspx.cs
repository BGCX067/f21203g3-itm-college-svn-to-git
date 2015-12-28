using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Contents : System.Web.UI.Page
    {
        //Create new instance of service ContentManage
        readonly ContentManage _content = new ContentManage();
        readonly Authenticator _auth = new Authenticator();

        //Load content detail to GridView at 1st Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!_auth.IsStaff(Session["role"].ToString()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                }
                LoadContentList();
            }
        }

        //Load content detail to GridView
        protected void LoadContentList()
        {
            listContent.DataSource = _content.GetContent();
            listContent.DataBind();
        }

        protected void listContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listContent.PageIndex = e.NewPageIndex;
            LoadContentList();
        }
    }
}