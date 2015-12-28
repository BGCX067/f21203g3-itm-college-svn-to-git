using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class AccountsDelete : System.Web.UI.Page
    {
        AccountManage account = new AccountManage();
        Authenticator auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is admin
            try
            {
                if (!auth.IsAdmin(Session["role"].ToString()))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
            }

            // Check validate QueryString ID
            try
            {
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
                int.Parse(Request.QueryString["ID"]);
// ReSharper restore ReturnValueOfPureMethodIsNotUsed
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Account ID');document.location.href='Accounts.aspx';", true);
                return;
            }

            if (!IsPostBack)
            {
                DataSet ds = account.FetchAccount(int.Parse(Request.QueryString["ID"].ToString()));
                lblAccountId.Text = ds.Tables[0].Rows[0]["accountID"].ToString();
                lblUsername.Text = ds.Tables[0].Rows[0]["username"].ToString();
                lblRole.Text = ds.Tables[0].Rows[0]["role"].ToString();

                // Check self delete account
                if (ds.Tables[0].Rows[0]["username"].ToString() == Session["username"].ToString())
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You cannot delete your account');document.location.href='Accounts.aspx';", true);
                }
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (account.DeleteAccount(int.Parse(lblAccountId.Text)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Account Deleted');document.location.href='Accounts.aspx';", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accounts.aspx");
        }
    }
}