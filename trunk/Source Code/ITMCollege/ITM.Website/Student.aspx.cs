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
    public partial class Student : System.Web.UI.Page
    {
        readonly StudentManage _student = new StudentManage();
        readonly AdmissionManage _am = new AdmissionManage();
        readonly Authenticator _authenticator = new Authenticator();
        private int studentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["student"] != null)
                {
                    studentId = _am.GetAdmisionIdFromString(Session["student"].ToString());
                    ViewStudentData();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Default.aspx';", true);
                }
            }
        }
        /// <summary>
        /// Active menu item
        /// </summary>
        protected void ViewStudentData()
        {
            try
            {
                switch (Request.QueryString["view"])
                {
                    case "Exam":
                        studentExam.CssClass = "active";
                        LoadExamTimeTable(studentId);
                        break;
                    case "Assignments":
                        studentAssignment.CssClass = "active";
                        LoadAssignments(studentId);
                        break;
                    case "ChangePassword":
                        studentChangePassword.CssClass = "active";
                        ShowChangePasswordForm();
                        break;
                    case "FeedBack":
                        studentFeedBack.CssClass = "active";
                        ShowFeedBackForm();
                        break;
                    case "Profile":
                    default:
                        studentProfile.CssClass = "active";
                        LoadStudentDetail();
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return;
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid access');document.location.href='Student.aspx';", true);
            }
        }

        /// <summary>
        /// Display Feedback Form
        /// </summary>
        protected void ShowFeedBackForm()
        {
            HideAllPanel();
            var courseDs = _student.FetchStudent(studentId);
            int mainCourse = int.Parse(courseDs.Tables[0].Rows[0]["specializedSubject"].ToString());
            int optionCourse = int.Parse(courseDs.Tables[0].Rows[0]["optionalSubject"].ToString());


            FeedbackCourseList.DataSource = _student.GetStudentCourse(mainCourse, optionCourse);
            FeedbackCourseList.DataTextField = "courseName";
            FeedbackCourseList.DataValueField = "courseID";
            FeedbackCourseList.DataBind();
            PanelFeedBack.Visible = true;
        }
        /// <summary>
        /// Display Change Password Form
        /// </summary>
        protected void ShowChangePasswordForm()
        {
            HideAllPanel();
            LabelEnrollNumber.Text = Session["student"].ToString();
            PanelChangePassword.Visible = true;

        }

        /// <summary>
        /// Load Assignment by Student
        /// </summary>
        /// <param name="std"></param>
        protected void LoadAssignments(int std)
        {
            HideAllPanel();
            PanelAssignment.Visible = true;
            MainAssignment.DataSource = _student.GetAssignmentList(std, "specialized");
            MainAssignment.DataBind();

            OptionalAssignment.DataSource = _student.GetAssignmentList(std, "optional");
            OptionalAssignment.DataBind();
        }

        /// <summary>
        /// Load Exam Time Table By Student
        /// Show Registered Course Exam Date
        /// </summary>
        /// <param name="std"></param>
        protected void LoadExamTimeTable(int std)
        {
            HideAllPanel();
            PanelExam.Visible = true;
            MainCourseView.DataSource = _student.GetExamTable(std, "specialized");
            MainCourseView.DataBind();
            OptioncalCourseView.DataSource = _student.GetExamTable(std, "optional");
            OptioncalCourseView.DataBind();
        }

        /// <summary>
        /// Load Student Detail
        /// </summary>
        protected void LoadStudentDetail()
        {
            HideAllPanel();
            PanelProfile.Visible = true;
            ProfileView.DataSource = _student.FetchStudent(studentId);
            ProfileView.DataBind();
        }

        /// <summary>
        /// Hide all panel content before show
        /// </summary>
        protected void HideAllPanel()
        {
            PanelAssignment.Visible = false;
            PanelChangePassword.Visible = false;
            PanelExam.Visible = false;
            PanelProfile.Visible = false;
            PanelFeedBack.Visible = false;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var registrationId = _am.GetAdmisionIdFromString(LabelEnrollNumber.Text);
                if (_student.ChangePassword(registrationId, _authenticator.EncodePassword(txtPassword.Text)))
                {
                    try
                    {
                        Session["student"] = null;
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Your new password has been updated');document.location.href='Default.aspx';", true);
                    }
                    catch (Exception)
                    {
                        ShowMessage("Unable to update your new password. Please try again later");
                    }
                }
            }
        }

        /// <summary>
        /// validate form data
        /// Handle ButtonSubmit click event
        /// </summary>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtCurrPassword.Text))
            {
                ShowMessage("Please enter your current password.");
                txtCurrPassword.Focus();
                return false;
            }

            // Check current password
            var registrationId = _am.GetAdmisionIdFromString(LabelEnrollNumber.Text);
            var ds = _student.StudentLogin(registrationId, _authenticator.EncodePassword(txtCurrPassword.Text));
            if (ds.Tables[0].Rows.Count == 0)
            {
                ShowMessage("Invalid current password. Re-enter");
                txtCurrPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowMessage("Your new password must be at least 5 characters long");
                txtPassword.Focus();
                return false;
            }
            else if (txtPassword.Text.Length > 32)
            {
                ShowMessage("Your new password must be less than 32 characters long");
                txtPassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtPassword2.Text)
            {
                ShowMessage("Password does not match");
                return false;
            }
            return true;
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

        protected void ButtonFeedBackSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFeedback.Text))
            {
                ShowMessage("Please enter your feedback");
                txtFeedback.Focus();
                return;
            }
            if (_student.SendFeedBack(txtFeedback.Text, Convert.ToInt32(FeedbackCourseList.SelectedValue)))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Your feedback have been sent');document.location.href='Student.aspx';", true);
            }
        }
    }
}