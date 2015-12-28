using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class Default : System.Web.UI.Page
    {
        readonly DefaultManage _defaultManage = new DefaultManage();
        /// <summary>
        /// Initialize page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "ITM College";
            if (!IsPostBack)
            {
                LoadNewsList();
                LoadEventList();
                LoadCourse();
                if (Session["student"] != null)
                {
                    StudentLoginForm.Visible = false;
                }
            }
        }

        /// <summary>
        /// Get latest course
        /// </summary>
        protected void LoadCourse()
        {
            LatestCourse.DataSource = _defaultManage.GetLatestCourse();
            LatestCourse.DataBind();
        }

        /// <summary>
        /// Load event list
        /// </summary>
        protected void LoadEventList()
        {
            EventList.DataSource = _defaultManage.GetContents("events");
            EventList.DataBind();
        }

        /// <summary>
        /// Load latest news
        /// </summary>
        protected void LoadNewsList()
        {
            NewsList.DataSource = _defaultManage.GetContents("news");
            NewsList.DataBind();
        }

        /// <summary>
        /// Truncate text on listview
        /// </summary>
        /// <param name="stringtotrim"></param>
        /// <returns></returns>
        protected string Truncate(object stringtotrim, int maxLength)
        {
            if (!(stringtotrim is string) || String.IsNullOrEmpty(stringtotrim as String))
                return null;
            else
            {
                string totrim = stringtotrim as String;
                return (totrim.Length > maxLength) ? totrim.Substring(0, maxLength) + "..." : totrim;
            }
        }


        /// <summary>
        ///Handle Button Login click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var studentManage = new StudentManage();
                var auth = new Authenticator();
                var am = new AdmissionManage();
                var registrationId = 0;
                try
                {
                    registrationId = am.GetAdmisionIdFromString(txtEnrollNumber.Text);
                }
                catch (Exception)
                {

                    ShowMessage("Invalid Enrollnumber");
                }
                var password = auth.EncodePassword(txtPassword.Text);
                var ds = studentManage.StudentLogin(registrationId, password);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    ShowMessage("Login failed. Invalid Enrollnumber or Password");
                }
                else
                {
                    Session["student"] = txtEnrollNumber.Text;
                    StudentLoginForm.Visible = false;
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Welcome: "+txtEnrollNumber.Text+"');document.location.href='Student.aspx';", true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtEnrollNumber.Text))
            {
                ShowMessage("Enrollnumber cannot be blank. Please enter");
                txtEnrollNumber.Focus();
                return false;
            }
            if (!txtEnrollNumber.Text.Contains("STUDENT"))
            {
                ShowMessage("Invalid Enrollnumber. Please enter");
                txtEnrollNumber.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowMessage("Password cannot be blank. Please enter");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        protected void ShowMessage(string msg)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "');", true);
        }
    }
}