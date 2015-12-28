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
    public partial class ContentUpdate : System.Web.UI.Page
    {
        //Create new instance of service ContentManage
        readonly ContentManage _content = new ContentManage();
        readonly Authenticator _auth = new Authenticator();
        //Load content detail from session contentID transferred from Contents home page
        //Run only at 1st Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is admin
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

                //Change contentID from string to int
                try
                {
                    int.Parse(Request.QueryString["contentID"]);
                }
                //if error, show message and back to Contents home page
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Invalid Content ID');document.location.href='Contents.aspx';", true);
                    return;
                }
                //if no error, load content detail to ContentUpdate page
                LoadContentDetail();
            }
        }

        //Load content detail to ContentUpdate page from contentID
        protected void LoadContentDetail()
        {
            int contentID = int.Parse(Request.QueryString["contentID"].ToString());
            DataSet ds =_content.FetchContent(contentID);
            txtID.Text = ds.Tables[0].Rows[0]["contentID"].ToString();
            txtID.ReadOnly = true;
            txtID.Enabled = false;
            txtTitle.Text = ds.Tables[0].Rows[0]["contentTitle"].ToString();
            contentImage.ImageUrl = "../Images/News/"+ds.Tables[0].Rows[0]["contentImage"].ToString();
            listCategory.SelectedValue = ds.Tables[0].Rows[0]["contentCategory"].ToString();
            txtText.Text = HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["contentText"].ToString());
        }

        /// <summary>
        /// Handle ButtonSubmit click event
        /// Update content detail
        /// </summary>
        /// <remarks>txtID is readonly</remarks>
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if all texts are filled
            if (ValidateForm())
            {
                //if yes, start updating content
                string dim = null;
                if ((FileUploadImage.PostedFile != null) && (FileUploadImage.PostedFile.ContentLength > 0))
                {
                    var fn = System.IO.Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    var saveLocation = Server.MapPath("../Images/News") + "\\" + fn;
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
                    dim = contentImage.ImageUrl;
                    dim = dim.Replace("../Images/News/", null);
                }

                if (_content.UpdateContent(int.Parse(txtID.Text), txtTitle.Text, dim, HttpUtility.HtmlEncode(txtText.Text), listCategory.SelectedValue))
                {
                    //If successful, show message and back to Contents home page
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Content updated');document.location.href='Contents.aspx';", true);
                }
                //If fail, show message
                else
                {
                    ShowMessage("Content not updated");
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
            // Register some inline script:
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + msg + "')", true);
        }
    }
}