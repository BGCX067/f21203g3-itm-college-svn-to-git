using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class AdmissionStatus : System.Web.UI.Page
    {
        AdmissionManage am = new AdmissionManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Check Admission Status - ITM College";
            if (!IsPostBack)
            {
                if (Session["student"] != null)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Default.aspx';", true);
                }
            }
        }

        /// <summary>
        /// Handle Button Proceed click event
        /// Redirect to Proceed Online Submission form with UniqueID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonProceed_Click(object sender, EventArgs e)
        {
            Server.Transfer("ProceedSubmission.aspx?UniqueID="+txtAdmissionId.Text);
        }

        /// <summary>
        /// Handle Button Submit click Event
        /// Check Admission Status
        /// Show Proceed Online Submission on status true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionId.Text))
            {
                ShowMessage("Please enter your Unique ID to check");
                txtAdmissionId.Focus();
                return;
            }
            if (txtAdmissionId.Text.Length < 11)
            {
                ShowMessage("Invalid Unique ID. Please check");
                txtAdmissionId.Focus();
                return;
            }
            string uniqueId = txtAdmissionId.Text;
            int admissionId = am.GetAdmisionIdFromString(uniqueId);

            if (!IsCompleted(admissionId))
            {
                CheckAdmissionStatus(admissionId);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('This Unique ID have been completed Registration');document.location.href='Default.aspx';", true);
            }
        }

        protected Boolean IsCompleted(int admissionId)
        {
            var ds = am.GetStudent(admissionId);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check Admission Status
        /// </summary>
        /// <param name="admissionId"></param>
        protected void CheckAdmissionStatus(int admissionId)
        {
            // Check UniqueID
            var ds = am.AdmissionStatus(admissionId);
            if (ds.Tables[0].Rows.Count == 0)
            {
                ShowMessage("Your Unique ID does not exist. Please check");
                txtAdmissionId.Text = null;
                txtAdmissionId.Focus();
                return;
            }
            
            // Disable panel button
            PanelButton.Visible = false;
            PanelStatus.Visible = true;
            txtAdmissionId.ReadOnly = true;

            // Get status from provided UniqueID
            var status = ds.Tables[0].Rows[0]["status"].ToString();
            if (status == "True")
            {
                Session["UniqueID"] = txtAdmissionId.Text;
                LabelStatus.Text = "ACCEPTED";
                PanelSubmission.Visible = true;
            }
            else
            {
                LabelStatus.Text = "WAITING";
            }
        }

        /// <summary>
        /// Handle Button Cancel click event
        /// Return back to homepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
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