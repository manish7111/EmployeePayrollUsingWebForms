using EmployeeManagementBL;
using EmployeeManagementDAL;
using EmployeeManagementModelLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementPayrollSystem.Pages.Aspx
{
    public partial class RegisterEmployee : System.Web.UI.Page
    {
        public readonly IEmployeeBL employeeRepo;
        public RegisterEmployee(IEmployeeBL employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        //readonly EmployeeRepo employeeRepo = new EmployeeRepo();
        readonly DisplayEmployeeDetails displayEmployee = new DisplayEmployeeDetails();
        public static int HR = 1;
        public static int SALES = 2;
        public static int FINANCE = 3;
        public static int ENGINEER = 4;
        public static int OTHER = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButton_CheckedChanged();
            SelectProfileImage();
            CheckBox_CheckedChanged();
        }
        protected void RadioButton_CheckedChanged()
        {
            if (male.Checked)
            {
                displayEmployee.Gender = 'M';
            }
            if (female.Checked)
            {
                displayEmployee.Gender = 'F';
            }
        }
        protected void SelectProfileImage()
        {
            if (profile1.Checked)
            {
                image1.ImageUrl = "../Assets/Ellipse -3.png";
                displayEmployee.Image = image1.ImageUrl;
                profile2.Checked = false;
                profile3.Checked = false;
                profile4.Checked = false;
            }
            if (profile2.Checked)
            {
                image2.ImageUrl = "../Assets/Ellipse -1.png";
                displayEmployee.Image = image2.ImageUrl;
                profile1.Checked = false;
                profile3.Checked = false;
                profile4.Checked = false;
            }
            if (profile3.Checked)
            {
                image3.ImageUrl = "../Assets/Ellipse -8.png";
                displayEmployee.Image = image3.ImageUrl;
                profile2.Checked = false;
                profile1.Checked = false;
                profile4.Checked = false;
            }
            if (profile4.Checked)
            {
                image4.ImageUrl = "../Assets/Ellipse -7.png";
                displayEmployee.Image = image4.ImageUrl;
                profile2.Checked = false;
                profile3.Checked = false;
                profile1.Checked = false;
            }
        }
        protected void CheckBox_CheckedChanged()
        {
            if (hr.Checked)
            {
                displayEmployee.DeptNo = HR;
                sales.Checked = false;
                finance.Checked = false;
                engineer.Checked = false;
                others.Checked = false;
            }
            if (sales.Checked)
            {
                displayEmployee.DeptNo = SALES;
                hr.Checked = false;
                finance.Checked = false;
                engineer.Checked = false;
                others.Checked = false;
            }
            if (finance.Checked)
            {
                displayEmployee.DeptNo = FINANCE;
                hr.Checked = false;
                sales.Checked = false;
                engineer.Checked = false;
                others.Checked = false;
            }
            if (engineer.Checked)
            {
                displayEmployee.DeptNo = ENGINEER;
                hr.Checked = false;
                sales.Checked = false;
                finance.Checked = false;
                others.Checked = false;
            }
            if (others.Checked)
            {
                displayEmployee.DeptNo = OTHER;
                hr.Checked = false;
                finance.Checked = false;
                engineer.Checked = false;
                sales.Checked = false;
            }
        }
        protected void SubmitButton(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");
            displayEmployee.EName = name.Text;
            var d = day.Items[day.SelectedIndex].Text;
            var m = month.Items[month.SelectedIndex].Text;
            var y = year.Items[year.SelectedIndex].Text;
            string dateTime = m + "/" + d + "/" + y;
            DateTime date = Convert.ToDateTime(dateTime, culture);
            displayEmployee.HireDate = date;
            displayEmployee.EmpSal = Convert.ToDouble(salary.Text);
            displayEmployee.SalaryMonth = m;
            displayEmployee.JobDiscription = notes.Text;
            if (displayEmployee.EName != null && displayEmployee.Gender != ' ' && displayEmployee.HireDate != null &&
               displayEmployee.DeptNo != 0 && displayEmployee.EmpSal > 0 && displayEmployee.SalaryMonth != null)
            {
                this.employeeRepo.AddEmployee(displayEmployee);
                //string message = "Employee has been added successfully.";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "')};";
                //ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                MessageBox("Employee has been added successfully.");
                myLabel.BackColor = Color.Green;
            }
            else
            {
                //string message = "Error while adding the employee.";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "')};";
                //ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", script, true);

                MessageBox("Error while adding the employee.");
                myLabel.BackColor = Color.Red;
            }
        }
        private void MessageBox(string strMsg)
        {
            myLabel.Text = strMsg;
        }
        protected void ResetButton(object sender, EventArgs e)
        {
            name.Text = "";
            male.Checked = false;
            female.Checked = false;
            profile1.Checked = false;
            profile2.Checked = false;
            profile3.Checked = false;
            profile4.Checked = false;
            hr.Checked = false;
            sales.Checked = false;
            finance.Checked = false;
            engineer.Checked = false;
            others.Checked = false;
            salary.Text = "";
            notes.Text = "";
        }
        protected void CancelButton(object sender, EventArgs e)
        {
            Response.Redirect("../Aspx/DisplayEmployee.aspx");
        }
    }
}