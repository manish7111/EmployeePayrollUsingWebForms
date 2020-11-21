using EmployeeManagementBL;
using EmployeeManagementDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementPayrollSystem.Pages.Aspx
{
    public partial class DisplayEmployee : System.Web.UI.Page
    {
        //EmployeeBL repo = new EmployeeBL();
        public readonly IEmployeeBL repo;
        public DisplayEmployee(IEmployeeBL repo)
        {
            this.repo = repo;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet dataSet = new DataSet();
                dataSet = repo.GetAllEmployee();
                GridView.DataSource = dataSet;
                GridView.DataBind();
            }
        }
        protected void DeleteEmployee(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = sender as LinkButton;
                GridViewRow gridrow = lnk.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(GridView.DataKeys[gridrow.RowIndex].Values["EmpId"].ToString());
                repo.DeleteEmployee(id);
                Page.Response.Redirect(Page.Request.Url.ToString(), false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int emp = Convert.ToInt32(GridView.DataKeys[index].Values["EmpId"].ToString());
                    Response.Redirect("UpdateEmployee.aspx?id=" + emp, false);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}