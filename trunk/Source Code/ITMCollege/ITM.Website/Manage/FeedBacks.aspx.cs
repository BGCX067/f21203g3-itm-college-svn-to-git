using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class FeedBacks : System.Web.UI.Page
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        readonly Authenticator _auth = new Authenticator();
        readonly FeedBackManager _fm = new FeedBackManager();


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
                LoadFeedBack();
            }
        }

        /// <summary>
        /// Load Feedback list
        /// </summary>
        protected void LoadFeedBack()
        {
            FeedbackList.DataSource = _fm.GetFeedBack();
            FeedbackList.DataBind();
        }

        /// <summary>
        /// Handle Feedback List page index change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FeedbackList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FeedbackList.PageIndex = e.NewPageIndex;
            LoadFeedBack();
        }
    }
}