using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class DepartementsInsert : System.Web.UI.Page
    {
        readonly DepartermentManage _departerment = new DepartermentManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Departements Insert";
            if (!IsPostBack)
            {
                // Check if user is admin
                try
                {
                    if (!_auth.IsAdmin(Session["role"].ToString()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                                    "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';",
                                                                    true);
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                                "alert('You do not have permission to use this function. Please login to continue');document.location.href='Login.aspx';",
                                                                true);
                }
            }
        }
        /// <summary>
        /// Handle ButtonSubmit click event
        /// Create new Departerments
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all fields are valid
            if (ValidateForm())
            {
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    var fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    var saveLocation = Server.MapPath("../Images/Departments") + "\\" + fn;
                    try
                    {
                        // Upload file
                        FileUploadImage.PostedFile.SaveAs(saveLocation);
                        int order = 9999;
                        try
                        {
                            order = int.Parse(txtOrder.Text);
                        }
                        catch (Exception)
                        {
                        }
                        if (_departerment.InsertDepartments(txtDepartmentName.Text, HttpUtility.HtmlEncode(txtDescription.Text), FileUploadImage.FileName, order))
                        {
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Departement inserted');document.location.href='Departments.aspx';", true);
                        }
                        else
                        {
                            ShowMessage("Departement not inserted");
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
        /// Cancel create new Departerments
        /// Redirect to DepartmentsManage
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departments.aspx");
        }
        /// <summary>
        /// Validate form
        /// </summary>
        /// <remarks></remarks>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtDepartmentName.Text))
            {
                ShowMessage("Departerment name cannot be blank. Re-enter");
                txtDepartmentName.Focus();
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
    }
}