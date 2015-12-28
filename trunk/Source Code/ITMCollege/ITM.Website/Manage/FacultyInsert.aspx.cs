using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class FacultyInsert : System.Web.UI.Page
    {
        readonly DepartermentManage _department = new DepartermentManage();
        readonly FacultyManage _faculty = new FacultyManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Faculty Insert";
            if (!IsPostBack)
            {
                // Check if user is admin
                try
                {
                    if (!_auth.IsAdmin(Session["role"].ToString()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';", true);
                }
                LoadDepartment();
            }
        }

        /// <summary>
        /// Load DepartmentName into Dropdownlist
        /// </summary>
        /// <remarks></remarks>
        protected void LoadDepartment()
        {
            departmentList.DataSource = _department.GetDepartments();
            departmentList.DataValueField = "departmentID";
            departmentList.DataTextField = "departmentName";
            departmentList.DataBind();
        }
        /// <summary>
        /// Handle ButtonSubmit click event
        /// Create new Faculty
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all fields are valid
            if (ValidateForm())
            {
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    string fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    string saveLocation = Server.MapPath("../Images/Faculty") + "\\" + fn;
                    try
                    {
                        // Upload file
                        FileUploadImage.PostedFile.SaveAs(saveLocation);
                        int depId = int.Parse(departmentList.SelectedValue);
                        if (_faculty.InsertFaculty(txtFacultyName.Text, HttpUtility.HtmlDecode(txtDescription.Text), int.Parse(txtOrder.Text), FileUploadImage.FileName, depId))
                        {
                            txtFacultyName.Text = null;
                            txtOrder.Text = null;
                            departmentList.SelectedValue = null;
                            txtDescription.Text = null;
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Faculty inserted');document.location.href='Faculty.aspx';", true);
                        }
                        else
                        {
                            ShowMessage("Faculty not inserted");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Handle ButtonCancel click event
        /// Cancel create new Faculty
        /// Redirect to FacultyManage
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Faculty.aspx");
        }
        /// <summary>
        /// Validate form
        /// </summary>
        /// <remarks></remarks>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtFacultyName.Text))
            {
                ShowMessage("Faculty name cannot be blank. Re-enter");
                txtFacultyName.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(txtFacultyImage.Text))
            //{
            //    ShowMessage("Faculty image cannot be blank. Re-enter");
            //    txtFacultyImage.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(txtOrder.Text))
            {
                ShowMessage("Faculty order cannot be blank. Re-enter");
                txtOrder.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                ShowMessage("Faculty description cannot be blank. Re-enter");
                txtDescription.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(departmentList.Text))
            {
                ShowMessage("Depatment cannot be blank. Re-enter");
                departmentList.Focus();
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
    }
}