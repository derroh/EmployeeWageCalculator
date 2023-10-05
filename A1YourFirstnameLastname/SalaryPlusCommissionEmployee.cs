using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1YourFirstnameLastname
{
    public class SalaryPlusCommissionEmployee : CommissionEmployee
    {
        public decimal WeeklySalary { get; set; }

        public override decimal GrossEarnings => WeeklySalary + base.GrossEarnings;
    }
}
