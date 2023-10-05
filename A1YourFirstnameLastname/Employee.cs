using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1YourFirstnameLastname
{
    public abstract class Employee
    {
        public EmployeeType EmployeeType { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public abstract decimal GrossEarnings { get; }

        public decimal Tax => GrossEarnings * 0.2m;

        public decimal NetEarnings => GrossEarnings - Tax;
    }

}
