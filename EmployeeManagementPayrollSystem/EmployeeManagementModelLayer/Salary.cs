using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementModelLayer
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public string SalaryMonth { get; set; }
        public double EmpSal { get; set; }
        public int EmpId { get; set; }
    }
}
