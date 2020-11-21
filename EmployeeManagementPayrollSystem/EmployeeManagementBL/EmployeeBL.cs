using EmployeeManagementDAL;
using EmployeeManagementModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBL
{
    public class EmployeeBL:IEmployeeBL
    {
        //= new EmployeeRepo()
        private readonly IEmployeeRepo repo ;
        public EmployeeBL(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public DisplayEmployeeDetails AddEmployee(DisplayEmployeeDetails model)
        {
            return this.repo.AddEmployee(model);
        }
        public Salary AddEmployeeSalary(Salary model)
        {
            return this.repo.AddEmployeeSalary(model);
        }
        public DisplayEmployeeDetails GetEmployeeById(int id)
        {
            return this.repo.GetEmployeeById(id);
        }
        public int DeleteEmployee(int empId)
        {
            return this.repo.DeleteEmployee(empId);
        }
        public DisplayEmployeeDetails UpdateEmployee(DisplayEmployeeDetails details)
        {
            return this.repo.UpdateEmployee(details);
        }
        public DataSet GetAllEmployee()
        {
            return this.repo.GetAllEmployee();
        }
    }
}
