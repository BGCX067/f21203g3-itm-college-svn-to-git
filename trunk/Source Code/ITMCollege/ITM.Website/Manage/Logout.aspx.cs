using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITM.Website.Manage
{
    public partial class Logout : System.Web.UI.Page
    {
        static string prevPage = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                prevPage = Request.UrlReferrer.ToString();
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session["username"] = null;
                Session["role"] = null;
                Response.Redirect("Login.aspx");
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}