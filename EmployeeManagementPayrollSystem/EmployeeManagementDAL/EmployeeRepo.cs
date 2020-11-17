using EmployeeManagementModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDAL
{
    public class EmployeeRepo:IEmployeeRepo
    {
        static readonly string connect = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        readonly SqlConnection connection = new SqlConnection(connect);
        //------------------- Add and get ---------
        public DisplayEmployeeDetails AddEmployee(DisplayEmployeeDetails model)
        {
            Salary salary = new Salary();
            try
            {
                var sqlFormattedDate = model.HireDate.ToString("MM/dd/yyyy");
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployee", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EName", model.EName);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@HireDay", sqlFormattedDate);
                    command.Parameters.AddWithValue("@DeptNo", model.DeptNo);
                    command.Parameters.AddWithValue("@Email", model.Email ?? "");
                    command.Parameters.AddWithValue("@BirthDay", model.BirthDay ?? "");
                    command.Parameters.AddWithValue("@JobDiscription", model.JobDiscription ?? "");
                    command.Parameters.AddWithValue("@ProfileImage", model.Image ?? "");
                    this.connection.Open();
                    Object result = command.ExecuteScalar();
                    this.connection.Close();
                    if (result != null)
                    {
                        salary.EmpId = Convert.ToInt32(result.ToString());
                        salary.EmpSal = model.EmpSal;
                        salary.SalaryMonth = model.SalaryMonth;
                        this.AddEmployeeSalary(salary);
                        return model;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public Salary AddEmployeeSalary(Salary model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployeeSalary", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SalaryMonth", model.SalaryMonth);
                    command.Parameters.AddWithValue("@EmpSal", model.EmpSal);
                    command.Parameters.AddWithValue("@EmpId", model.EmpId);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return model;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public DisplayEmployeeDetails GetEmployeeById(int id)
        {
            try
            {
                using (this.connection)
                {
                    DisplayEmployeeDetails employee = new DisplayEmployeeDetails();
                    SqlCommand command = new SqlCommand("spGetEmployeeById", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpId", id);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employee.EmpId = Convert.ToInt32(dataReader["EmpId"]);
                            employee.EName = dataReader["EName"].ToString();
                            employee.Gender = Convert.ToChar(dataReader["Gender"]);
                            employee.DeptNo = Convert.ToInt32(dataReader["DeptNo"]);
                            employee.DeptName = dataReader["DeptName"].ToString();
                            employee.EmpSal = Convert.ToDouble(dataReader["EmpSal"]);
                            employee.HireDate = Convert.ToDateTime(dataReader["HireDay"]);
                            employee.Image = dataReader["ProfileImage"].ToString();
                        }
                        return employee;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        //----------------------------------------------------------------------
        //--------- Delete Employee --------------------------------------------
        public int DeleteEmployee(int empId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteEmployee", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(empId));
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return empId;
                    }
                    return empId;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        //----------------------------------------------------------------------
        //--------- Update Employee --------------------------------------------
        public DisplayEmployeeDetails UpdateEmployee(DisplayEmployeeDetails details)
        {
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    using(var transaction = this.connection.BeginTransaction())
                    {
                        SqlCommand employeeUpdate = new SqlCommand("spUpdateEmployee", this.connection,transaction);
                        employeeUpdate.CommandType = CommandType.StoredProcedure;
                        employeeUpdate.Parameters.AddWithValue("@EmpId", details.EmpId);
                        employeeUpdate.Parameters.AddWithValue("@EName", details.EName);
                        employeeUpdate.Parameters.AddWithValue("@Gender", details.Gender);
                        employeeUpdate.Parameters.AddWithValue("@HireDay", details.HireDate);
                        employeeUpdate.Parameters.AddWithValue("@DeptNo", details.DeptNo);
                        employeeUpdate.Parameters.AddWithValue("@JobDiscription", details.JobDiscription==null?"" : details.JobDiscription);
                        employeeUpdate.Parameters.AddWithValue("@SalaryMonth", details.SalaryMonth);
                        employeeUpdate.Parameters.AddWithValue("@EmpSal", details.EmpSal);
                        employeeUpdate.Parameters.AddWithValue("@ProfileImage", details.Image ?? "");
                        var result = employeeUpdate.ExecuteNonQuery();
                        transaction.Commit();
                        if (result != 0)
                        {
                            return details;
                        }
                        return null;
                    }
                   
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        //----------------------------------------------------------------------
        //--------- Get All Employees ------------------------------------------
        public DataSet GetAllEmployee()
        {
            try
            {
                DataSet dataset = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("spGetAllEmployees", this.connection);
                    adapter.Fill(dataset);
                    this.connection.Close();
                    return dataset;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
