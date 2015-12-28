using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class AdmissionUpdate : System.Web.UI.Page
    {
        readonly AdmissionManage _am = new AdmissionManage();
        private int admissionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            admissionId = int.Parse(Request.QueryString["AID"].ToString());
            if (!IsPostBack)
            {
                LoadAdmissionDetail();
            }
        }

        protected void LoadAdmissionDetail()
        {
            var ds = _am.FetchAdmissionDetail(admissionId);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                            "alert('Invalid Admmission. Please check');document.location.href='Admission.aspx';",
                                                            true);
            }
            else
            {
                var adm = ds.Tables[0].Rows[0];
                LabelAdmissionID.Text = adm["admissionID"].ToString();
                LabelName.Text = adm["Name"].ToString();
                LabelFatherName.Text = adm["FatherName"].ToString();
                LabelMotherName.Text = adm["MortherName"].ToString();
                LabelBirthday.Text = adm["Birthday"].ToString();
                LabelGender.Text = adm["Gender"].ToString();
                LabelResAddress.Text = adm["ResidentialAddress"].ToString();
                LabelPerAddress.Text = adm["PermanentAddress"].ToString();
                LabelSport.Text = adm["prevSportsDetails"].ToString();
                LabelAdmissionFor.Text = adm["admissionFor"].ToString();

                LabelUniversity.Text = adm["prevUniversity"].ToString();
                LabelEnrol.Text = adm["prevEnrolNumber"].ToString();
                LabelCenter.Text = adm["prevCenter"].ToString();
                LabelStream.Text = adm["prevStream"].ToString();
                LabelField.Text = adm["prevField"].ToString();
                LabelMark.Text = adm["prevMarks"].ToString();
                LabelOutOf.Text = adm["prevOutOf"].ToString();
                LabelClass.Text = adm["prevClass"].ToString();
                if (adm["prevClass"].ToString() == "true")
                {
                    LabelStatus.Text = "yes";
                }
                else
                {
                    LabelStatus.Text = "Waiting";
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admission.aspx");
        }

        protected void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (_am.AcceptAdmission(admissionId))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                            "alert('Admmission Accepted');document.location.href='Admission.aspx';",
                                                            true);
            }
        }
    }
}