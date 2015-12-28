using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class ContentInsert : System.Web.UI.Page
    {
        //Create new instance of service ContentManage
        readonly ContentManage content = new ContentManage();
        readonly Authenticator _auth = new Authenticator();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!_auth.IsStaff(Session["role"].ToString()))
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

        /// <summary>
        /// Handle ButtonSubmit click event
        /// Create new Content
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all fields are valid
            if (ValidateForm())
            {
                //If all valid, start inserting content
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    var fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    var saveLocation = Server.MapPath("../Images/News") + "\\" + fn;
                    try
                    {
                        // Upload file
                        FileUploadImage.PostedFile.SaveAs(saveLocation);
                        if (content.InsertContent(txtTitle.Text, FileUploadImage.FileName, HttpUtility.HtmlEncode(txtText.Text),
                                                  listCategory.SelectedValue))
                        {
                            //If insert successfully, show message and reset all controls
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                                                                        "alert('Content inserted');document.location.href='Contents.aspx';",
                                                                        true);
                        }
                            //Show message if failed insertion
                        else
                        {
                            ShowMessage("Content not inserted");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
                }
                else
                {
                    ShowMessage("Please select Image to upload.");
                    return;
                }
            }
        }

        /// <summary>
        /// Handle ButtonCancel click event
        /// Back to Contents main page
        /// </summary>
        /// <remarks></remarks>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contents.aspx");
        }

        /// <summary>
        /// Validate form
        /// </summary>
        /// <remarks></remarks>
        /// <return>
        /// Boolean true if all texts are filled
        /// </return>
        protected Boolean ValidateForm()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                ShowMessage("Content title cannot be blank. Please enter");
                txtTitle.Focus();
                return false;
            }
            if (listCategory.SelectedItem.Text.Equals("Select Category"))
            {
                ShowMessage("Content category cannot be blank. Please enter");
                listCategory.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtText.Text))
            {
                ShowMessage("Content text cannot be blank. Please enter");
                txtText.Focus();
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
            // Register some inline script
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}