using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
using System.Data;

namespace ITM.Website.Manage
{
    public partial class FacultyUpdate : System.Web.UI.Page
    {
        readonly FacultyManage _faculty = new FacultyManage();
        readonly DepartermentManage _department = new DepartermentManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Faculty Update";
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
                try
                {
                    int.Parse(Request.QueryString["ID"]);
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Faculty');document.location.href='Faculty.aspx';", true);
                    return;
                }
                LoadDepartment();
                LoadFacultyDetail();
            }
        }
        /// <summary>
        /// Load Faculty detail into field
        /// </summary>
        /// <remarks></remarks>
        protected void LoadFacultyDetail()
        {

            int facultyID = int.Parse(Request.QueryString["ID"].ToString());
            DataSet ds = _faculty.FetchFaculty(facultyID);
            txtFacultyID.Text = ds.Tables[0].Rows[0]["facultyID"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["facultyName"].ToString();
            txtDescription.Text = HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["facultyDescription"].ToString());
            facultyImage.ImageUrl = "../Images/Faculty/"+ds.Tables[0].Rows[0]["facultyImage"].ToString();
            txtOrder.Text = ds.Tables[0].Rows[0]["facultyOrder"].ToString();
            departmentlist.SelectedValue = ds.Tables[0].Rows[0]["departmentID"].ToString();
        }
        /// <summary>
        /// Load DepartmentName into Dropdownlist
        /// </summary>
        /// <remarks></remarks>
        protected void LoadDepartment()
        {
            departmentlist.DataSource = _department.GetDepartments();
            departmentlist.DataValueField = "departmentID";
            departmentlist.DataTextField = "departmentName";
            departmentlist.DataBind();
        }
        /// <summary>
        /// Handle ButtonSubmit click event
        /// Update Faculty
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string fim = null;
            if (ValidateForm())
            {
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    var fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    var saveLocation = Server.MapPath("../Images/Faculty") + "\\" + fn;
                    try
                    {
                        // Upload file
                        FileUploadImage.PostedFile.SaveAs(saveLocation);
                        fim = FileUploadImage.FileName;
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
                else
                {
                    fim = facultyImage.ImageUrl;
                    fim = fim.Replace("../Images/Faculty/", null);
                }

                var depId = int.Parse(departmentlist.SelectedValue);
                if (_faculty.UpdateFaculty(int.Parse(txtFacultyID.Text), txtName.Text, HttpUtility.HtmlEncode(txtDescription.Text), int.Parse(txtOrder.Text), fim, depId))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Faculty Updated');document.location.href='Faculty.aspx';", true);
                }
                else
                {
                    ShowMessage("Faculty not updated");
                }
            }
        }
        /// <summary>
        /// Validate form
        /// </summary>
        /// <remarks></remarks>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowMessage("Departerment name cannot be blank. Re-enter");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtOrder.Text))
            {
                ShowMessage("Departerment order cannot be blank. Re-enter");
                txtOrder.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                ShowMessage("Departerment description cannot be blank. Re-enter");
                txtDescription.Focus();
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
        /// <summary>
        /// Handle ButtonCancel click event
        /// Cancel Update Faculty
        /// Redirect to FacultyManage
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Faculty.aspx");
        }
    }
}