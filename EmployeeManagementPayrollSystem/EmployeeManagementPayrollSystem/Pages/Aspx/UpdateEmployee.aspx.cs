using EmployeeManagementBL;
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
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        public readonly IEmployeeBL employee;
        public UpdateEmployee(IEmployeeBL employee)
        {
            this.employee = employee;
        }
        DisplayEmployeeDetails updateEmployee = new DisplayEmployeeDetails();
        public static int HR = 1;
        public static int SALES = 2;
        public static int FINANCE = 3;
        public static int ENGINEER = 4;
        public static int OTHER = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            string emp = Request.QueryString["id"];
            int empId = Int16.Parse(emp);
            if (!IsPostBack)
            {
                BindTextBoxValues(empId);
            }

        }
        protected void BindTextBoxValues(int empId)
            {
            try
            {
                DisplayEmployeeDetails displayEmployee = employee.GetEmployeeById(empId);
                EmpId.Text = displayEmployee.EmpId.ToString();
                name.Text = displayEmployee.EName;
                if (displayEmployee.Image== "../Assets/Ellipse -3")
                {
                    profile1.Checked = true;
                }
                if (displayEmployee.Image == "../Assets/Ellipse -1")
                {
                    profile2.Checked = true;
                }
                if (displayEmployee.Image == "../Assets/Ellipse -8")
                {
                    profile3.Checked = true;
                }
                if (displayEmployee.Image == "../Assets/Ellipse -7")
                {
                    profile4.Checked = true;
                }
                if (displayEmployee.Gender == 'M')
                {
                    male.Checked = true;
                    female.Checked = false;
                }
                else
                {
                    male.Checked = false;
                    female.Checked = true;
                }
                    switch (displayEmployee.DeptName)
                    {
                        case "HR":
                            hr.Checked = true;
                            break;
                        case "Sales":
                            sales.Checked = true;
                            break;
                        case "Finance":
                            finance.Checked = true;
                            break;
                        case "Engineer":
                            engineer.Checked = true;
                            break;
                        case "Others":
                            others.Checked = true;
                            break;
                    }

                salary.Text = displayEmployee.EmpSal.ToString();
                string d = displayEmployee.HireDate.Day.ToString();
                int m = displayEmployee.HireDate.Month;
                string monthName = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(m);
                string y = displayEmployee.HireDate.Year.ToString();
                day.Items[day.SelectedIndex].Text = d.ToString();
                month.Items[month.SelectedIndex].Text = monthName.ToString();
                year.Items[year.SelectedIndex].Text = y.ToString();
                notes.Text = displayEmployee.JobDiscription;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (male.Checked)
            {
                updateEmployee.Gender = 'M';
            }
            if (female.Checked)
            {
                updateEmployee.Gender = 'F';
            }
        }
        protected void SelectProfileImage(object sender, System.EventArgs e)
        {
            if (profile1.Checked)
            {
                image1.ImageUrl = "../Assets/Ellipse -3.png";
                updateEmployee.Image = image1.ImageUrl;
                profile2.Checked = false;
                profile3.Checked = false;
                profile4.Checked = false;
            }
            if (profile2.Checked)
            {
                image2.ImageUrl = "../Assets/Ellipse -1.png";
                updateEmployee.Image = image2.ImageUrl;
                profile1.Checked = false;
                profile3.Checked = false;
                profile4.Checked = false;
            }
            if (profile3.Checked)
            {
                image3.ImageUrl = "../Assets/Ellipse -8.png";
                updateEmployee.Image = image3.ImageUrl;
                profile2.Checked = false;
                profile1.Checked = false;
                profile4.Checked = false;
            }
            if (profile4.Checked)
            {
                image4.ImageUrl = "../Assets/Ellipse -7.png";
                updateEmployee.Image = image4.ImageUrl;
                profile2.Checked = false;
                profile3.Checked = false;
                profile1.Checked = false;
            }
        }
        protected void CheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (hr.Checked)
            {
                if (sales.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (finance.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (engineer.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    finance.Checked = false;
                    others.Checked = false;
                }
                if (others.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    sales.Checked = false;
                }
            }
            if (sales.Checked)
            {
                if (hr.Checked)
                {
                    sales.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (finance.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (engineer.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    finance.Checked = false;
                    others.Checked = false;
                }
                if (others.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    sales.Checked = false;
                }
            }
            if (finance.Checked)
            {
                if (sales.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (hr.Checked)
                {
                    finance.Checked = false;
                    sales.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (engineer.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    finance.Checked = false;
                    others.Checked = false;
                }
                if (others.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    sales.Checked = false;
                }
            }
            if (engineer.Checked)
            {
                if (sales.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (finance.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (hr.Checked)
                {
                    engineer.Checked = false;
                    sales.Checked = false;
                    finance.Checked = false;
                    others.Checked = false;
                }
                if (others.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    sales.Checked = false;
                }
            }
            if (others.Checked)
            {
                if (sales.Checked)
                {
                    hr.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (finance.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    engineer.Checked = false;
                    others.Checked = false;
                }
                if (engineer.Checked)
                {
                    hr.Checked = false;
                    sales.Checked = false;
                    finance.Checked = false;
                    others.Checked = false;
                }
                if (hr.Checked)
                {
                    others.Checked = false;
                    finance.Checked = false;
                    engineer.Checked = false;
                    sales.Checked = false;
                }
            }
        }
        protected void SubmitButton(object sender, EventArgs e)
        {
            if (hr.Checked)
            {
                updateEmployee.DeptNo = HR;
            }
            if (sales.Checked)
            {
                updateEmployee.DeptNo = SALES;
            }
            if (finance.Checked)
            {
                updateEmployee.DeptNo = FINANCE;
            }
            if (engineer.Checked)
            {
                updateEmployee.DeptNo = ENGINEER;
            }
            if (others.Checked)
            {
                updateEmployee.DeptNo = OTHER;
            }
            if (profile1.Checked)
            {
                image1.ImageUrl = "../Assets/Ellipse -3.png";
                updateEmployee.Image = image1.ImageUrl;
            }
            if (profile2.Checked)
            {
                image1.ImageUrl = "../Assets/Ellipse -1.png";
                updateEmployee.Image = image2.ImageUrl;
            }
            if (profile3.Checked)
            {
                image1.ImageUrl = "../Assets/Ellipse -8.png";
                updateEmployee.Image = image3.ImageUrl;
            }
            if (profile4.Checked)
            {
                image1.ImageUrl = "../Assets/Ellipse -7.png";
                updateEmployee.Image = image4.ImageUrl;
            }
            CultureInfo culture = new CultureInfo("en-US");
            if (male.Checked)
            {
                updateEmployee.Gender = 'M';
            }
            if (female.Checked)
            {
                updateEmployee.Gender = 'F';
            }
            updateEmployee.EmpId = Convert.ToInt32(EmpId.Text);
            updateEmployee.EName = name.Text;
            updateEmployee.Gender = male.Checked ? 'M' : 'F';
            updateEmployee.EmpSal = Convert.ToDouble(salary.Text);
            var d = day.Items[day.SelectedIndex].Text;
            var m = month.Items[month.SelectedIndex].Text;
            var y = year.Items[year.SelectedIndex].Text;
            string dateTime = m + "/" + d + "/" + y;
            DateTime date = Convert.ToDateTime(dateTime, culture);
            updateEmployee.HireDate = date;
            updateEmployee.SalaryMonth = m;
            updateEmployee.JobDiscription = notes.Text;
            if (updateEmployee.EName != null && updateEmployee.Gender != ' ' && updateEmployee.HireDate != null &&
               updateEmployee.DeptNo != 0 && updateEmployee.EmpSal > 0 && updateEmployee.SalaryMonth != null)
            {
                this.employee.UpdateEmployee(updateEmployee);
                Response.Redirect("../Aspx/DisplayEmployee.aspx");
            }
            else
            {
                MessageBox("Error while Updating the employee.");
                myLabel.BackColor = Color.Red;
            }
        }
        private void MessageBox(string strMsg)
        {
            myLabel.Text = strMsg;
        }
        protected void CancelButton(object sender, EventArgs e)
        {
            Response.Redirect("../Aspx/DisplayEmployee.aspx");
        }
    }
}