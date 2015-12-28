using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class DepartmentUpdate : System.Web.UI.Page
    {
        DepartermentManage _department = new DepartermentManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Departements Update";
            if (!IsPostBack)
            {
                try
                {
                    int.Parse(Request.QueryString["ID"]);
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Department ID');document.location.href='Departments.aspx';", true);
                    return;
                }
                LoadDepartmentDetail();
            }
        }
        /// <summary>
        /// Load Department detail into field
        /// </summary>
        /// <remarks></remarks>
        protected void LoadDepartmentDetail()
        {
            int departmentID = int.Parse(Request.QueryString["ID"].ToString());
            DataSet ds =_department.FetchDepartments(departmentID);
            txtID.Text = ds.Tables[0].Rows[0]["departmentID"].ToString();
            txtDepartmentName.Text = ds.Tables[0].Rows[0]["departmentName"].ToString();
            txtDescription.Text = HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["departmentDescription"].ToString());
            depImage.ImageUrl = "../Images/Departments/"+ds.Tables[0].Rows[0]["departmentImage"].ToString();
            txtOrder.Text = ds.Tables[0].Rows[0]["departmentOrder"].ToString();
        }
        /// <summary>
        /// Handle ButtonSubmit click event
        /// Update Departerments
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string dim = null;
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    var fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    var saveLocation = Server.MapPath("../Images/Departments") + "\\" + fn;
                    try
                    {
                        // Upload file
                        FileUploadImage.PostedFile.SaveAs(saveLocation);
                        dim = FileUploadImage.FileName;
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
                }
                else
                {
                    dim = depImage.ImageUrl;
                    dim = dim.Replace("../Images/Departments/", null);
                }

                if (_department.UpdateDepartments(int.Parse(txtID.Text), txtDepartmentName.Text, HttpUtility.HtmlEncode(txtDescription.Text), dim, int.Parse(txtOrder.Text)))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Department updated');document.location.href='Departments.aspx';", true);
                }
                else
                {
                    ShowMessage("Departments not updated");
                }
            }
        }
        /// <summary>
        /// Handle ButtonCancel click event
        /// Cancel Update Departerments
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
    }
}