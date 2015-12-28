using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class FeedbackDelete : System.Web.UI.Page
    {
        readonly Authenticator _auth = new Authenticator();
        readonly FeedBackManager _am = new FeedBackManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is staff
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
                
                LoadFeedbackDetail();
            }
        }

        protected void LoadFeedbackDetail()
        {
            int feedbackId = 0;
            try
            {
                feedbackId = int.Parse(Request.QueryString["fid"].ToString());
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Feedback ID');document.location.href='FeedBacks.aspx';", true);
            }
            var ds = _am.FetchFeedback(feedbackId);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                            "alert('Invalid Feedback ID');document.location.href='FeedBacks.aspx';",
                                                            true);
            }
            else
            {
                txtFeedbackID.Text = ds.Tables[0].Rows[0]["feedbackID"].ToString();
                txtCourse.Text = ds.Tables[0].Rows[0]["courseName"].ToString();
                txtFeedback.Text = ds.Tables[0].Rows[0]["feedbackContent"].ToString();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_am.DeleteFeedback(int.Parse(Request.QueryString["fid"].ToString())))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                            "alert('Feedback Deleted');document.location.href='FeedBacks.aspx';",
                                                            true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Delete Feedback failed');document.location.href='FeedBacks.aspx';", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeedBacks.aspx");
        }
    }
}