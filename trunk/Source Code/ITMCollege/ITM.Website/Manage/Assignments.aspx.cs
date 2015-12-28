using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITM.Services.Service;

namespace ITM.Website.Manage
{
    public partial class Assignments : System.Web.UI.Page
    {
        //Create new instance of service AssignmentManage
        readonly AssignmentManage assignment = new AssignmentManage();

        //Load assginment detail to GridView at 1st Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAssignmentList();
            }
        }

        //Load assignment detail to GridView
        protected void LoadAssignmentList()
        {
            listAssignment.DataSource = assignment.GetAssignment();
            listAssignment.DataBind();
        }

        protected void listAssignment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            listAssignment.PageIndex = e.NewPageIndex;
            LoadAssignmentList();
        }
    }
}