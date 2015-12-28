using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;


namespace ITM.Website.Manage
{
    public partial class FacilitiesInsert : System.Web.UI.Page
    {
        readonly FacilitiesManage _faciliti = new FacilitiesManage();
        readonly Authenticator _auth = new Authenticator();

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Insert Facilities";
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
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    var fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    var saveLocation = Server.MapPath("../Images/Facilities") + "\\" + fn;
                    try
                    {
                        // Upload file
                        FileUploadImage.PostedFile.SaveAs(saveLocation);
                        if (_faciliti.InsertFacilities(txtFacilityName.Text, FileUploadImage.FileName, HttpUtility.HtmlEncode(txtDescription.Text)))
                        {
                            txtFacilityName.Text = null;
                            txtDescription.Text = null;
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Facilities inserted');document.location.href='Facilities.aspx';", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
                }
            }
        }
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtFacilityName.Text))
            {
                ShowMessage("FacilityName cannot be blank. Re-enter");
                txtFacilityName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                ShowMessage("FacilityDescription cannot be blank. Re-enter");
                txtDescription.Focus();
                return false;
            }
            return true;
        }
        

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Facilities.aspx");
        }
        protected void ShowMessage(string msg)
        {
            // Register some inline script:
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}