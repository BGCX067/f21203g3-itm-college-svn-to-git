using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class RegistrationCompleted : System.Web.UI.Page
    {
        readonly AdmissionManage _am = new AdmissionManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UniqueID"] != null)
                {
                    if (Session["UniqueID"].ToString() != Request.QueryString["UniqueID"].ToString(CultureInfo.InvariantCulture))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='AdmissionStatus.aspx';", true);
                        return;
                    }
                    var uniqueId = Session["UniqueID"].ToString();
                    int admissionId = _am.GetAdmisionIdFromString(uniqueId);

                    GenerateStudentInformation(admissionId);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='AdmissionStatus.aspx';", true);
                }
            }
        }

        protected void GenerateStudentInformation(int admissionId)
        {
            var password = System.Web.Security.Membership.GeneratePassword(8, 0);
            var encryptPassword = _auth.EncodePassword(password);

            var ds = _am.FetchStudentDetail(admissionId);
            int regId = int.Parse(ds.Tables[0].Rows[0]["registrationID"].ToString());
            var enrol = "STUDENT" + regId.ToString("000000");

            if (_am.InsertStudentPassword(admissionId, encryptPassword))
            {
                EnrollNumber.Text = enrol;
                LabelPassword.Text = password;
            }
        }
    }
}