using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITM.Website
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var o = Session["student"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session["student"] = null;
                Response.Redirect("Default.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}