using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        readonly AdmissionManage _am = new AdmissionManage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UniqueID"] != null)
            {
                var uniqueId = Session["UniqueID"].ToString();
                var courseId = int.Parse(Request.QueryString["courseID"].ToString());
                int admissionId = _am.GetAdmisionIdFromString(uniqueId);

                if (IsRegistered(admissionId))
                {
                    if (RegisterOptionalSubject(admissionId, courseId, uniqueId))
                    {
                        Response.Redirect("RegistrationCompleted.aspx?UniqueID=" + uniqueId);
                    }
                }
                else
                {
                    RegisterSpecializedSubject(admissionId, courseId, uniqueId);
                }
            }
        }

        /// <summary>
        /// Check if registered
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        protected Boolean IsRegistered(int admissionId)
        {
            var ds = _am.GetStudent(admissionId);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        protected void RegisterSpecializedSubject(int admissionId, int courseId, string uniqueId)
        {
            if (_am.InsertSpecializedSubject(admissionId, courseId))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You have been registered Specialized Subject. Please select Optional Subject');document.location.href='ProceedSubmission.aspx?UniqueID="+uniqueId+"';", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Register Specialized Subject false. Please try again');document.location.href='ProceedSubmission.aspx?UniqueID=" + uniqueId + "';", true);
            }
        }
        protected Boolean RegisterOptionalSubject(int admissionId, int courseId, string uniqueId)
        {
            if (_am.InsertOptionalSubject(admissionId, courseId))
            {
                return true;
            }
            return false;
        }
    }
}