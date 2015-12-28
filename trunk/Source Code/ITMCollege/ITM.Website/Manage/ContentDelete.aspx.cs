using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
using System.Data;

namespace ITM.Website.Manage
{
    public partial class ContentDelete : System.Web.UI.Page
    {
        //Create new instance of service ContentManage
        readonly ContentManage content = new ContentManage();
        readonly Authenticator _auth = new Authenticator();

        //Display ID and Title of content to be deleted at 1st Page_Load
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

                DataSet ds = content.FetchContent(int.Parse(Request.QueryString["contentID"].ToString()));
                lblContentID.Text = ds.Tables[0].Rows[0]["contentID"].ToString();
                lblContentTitle.Text = ds.Tables[0].Rows[0]["contentTitle"].ToString();
            }
        }

        /// <summary>
        /// Handle ButtonDelete click event
        /// Delete selected content
        /// </summary>
        /// <remarks>Display message and back to Contents home page if successful</remarks>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (content.DeleteContent(int.Parse(lblContentID.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Content Deleted');document.location.href='Contents.aspx';", true);
            }
        }

        /// <summary>
        /// Handle ButtonCancel click event
        /// Back to Contents main page
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contents.aspx");
        }

    }
}