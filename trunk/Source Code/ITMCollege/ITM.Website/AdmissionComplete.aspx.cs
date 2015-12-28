using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class AdmissionComplete : System.Web.UI.Page
    {
        readonly AdmissionManage _am = new AdmissionManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            string regkey = null;
            if (Session["regkey"] != null)
            {

                regkey = Session["regkey"].ToString();
            }
            else
            {
                if (Request.QueryString["regkey"] != null)
                {
                    regkey = Request.QueryString["regkey"].ToString();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Default.aspx';", true);
                }
            }
            BuildUniqueId(regkey);
        }

        protected void BuildUniqueId(string regkey)
        {
            DataSet ds = _am.GenerateUniqueId(regkey);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Default.aspx';", true);
                return;
            }
            var id = int.Parse(ds.Tables[0].Rows[0]["admissionID"].ToString());
            var uniqueId = "ITMOA" + id.ToString("000000");
            UniqueID.Text = uniqueId;
        }
        /// <summary>
        /// Show error message
        /// </summary>
        /// <param name="msg">String message to show</param>
        /// <remarks></remarks>
        protected void ShowMessage(string msg)
        {
            // Register some inline script:
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}