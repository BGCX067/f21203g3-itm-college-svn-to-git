using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;
using System.Data;
using System.Data.SqlClient;

namespace ITM.Website.Manage
{
    public partial class FacilitiesUpdate : System.Web.UI.Page
    {
        readonly FacilitiesManage faciliti = new FacilitiesManage();
        readonly Authenticator _auth = new Authenticator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Update Facilities";
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
                LoadFacilitieDetail();
            }
        }
        protected void LoadFacilitieDetail()
        {
            int facilitieId = int.Parse(Request.QueryString["ID"].ToString());
            DataSet ds = faciliti.FetchFacilities(facilitieId);
            txtFacilityID.Text = ds.Tables[0].Rows[0]["facilitieID"].ToString();
            txtFacilityName.Text = ds.Tables[0].Rows[0]["facilitieName"].ToString();
            FacilityImage.ImageUrl = "../Images/Facilities/" + ds.Tables[0].Rows[0]["facilitieImage"].ToString();
            txtDescription.Text = HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["facilitieDescription"].ToString());
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
                ShowMessage("Description cannot be blank. Re-enter");
                txtDescription.Focus();
                return false;
            }
            return true;

           }
           

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string fim = null;
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    var fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    var saveLocation = Server.MapPath("../Images/Facilities") + "\\" + fn;
                    try
                    {
                        // Upload file
                        FileUploadImage.PostedFile.SaveAs(saveLocation);
                        fim = FileUploadImage.FileName;
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
                }
                else
                {
                    fim = FacilityImage.ImageUrl;
                    fim = fim.Replace("../Images/Facilities/", null);
                }

                if (faciliti.UpdateFacilities(int.Parse(txtFacilityID.Text), txtFacilityName.Text, fim, HttpUtility.HtmlEncode(txtDescription.Text)))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Facilities Update');document.location.href='Facilities.aspx';", true);
                }
                else
                {
                    ShowMessage("Facilities not update");
                }
            }
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