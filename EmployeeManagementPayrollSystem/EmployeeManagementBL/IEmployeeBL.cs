using EmployeeManagementModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBL
{
    public interface IEmployeeBL
    {
        DisplayEmployeeDetails AddEmployee(DisplayEmployeeDetails model);
        Salary AddEmployeeSalary(Salary model);
        DisplayEmployeeDetails GetEmployeeById(int id);
        int DeleteEmployee(int empId);
        DisplayEmployeeDetails UpdateEmployee(DisplayEmployeeDetails details);
        DataSet GetAllEmployee();
    }
}
