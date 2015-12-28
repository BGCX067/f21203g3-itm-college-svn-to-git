using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Accounts : System.Web.UI.Page
    {
        readonly AccountManage _account = new AccountManage();
        Authenticator auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                LoadAccountList();
            }
        }

        /// <summary>
        /// Method LoadAccountList
        /// Show account from dataset to GridView
        /// </summary>
        /// <remarks></remarks>
        protected void LoadAccountList()
        {
            listAccounts.DataSource = _account.GetAccount();
            listAccounts.DataBind();
        }
    }
}