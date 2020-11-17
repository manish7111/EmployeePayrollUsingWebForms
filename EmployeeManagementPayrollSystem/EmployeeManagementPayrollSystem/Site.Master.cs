using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementPayrollSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btn_GetEmployees(object sender, EventArgs e)
        {
            Response.Redirect("Pages/Aspx/DisplayEmployee.aspx");
            //Server.Transfer("Pages/Aspx/DisplayEmployee.aspx");
        }

        
    }
}